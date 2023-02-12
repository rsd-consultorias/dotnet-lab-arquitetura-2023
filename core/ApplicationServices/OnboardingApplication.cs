using LabArquitetura.Core.DomainServices;
using LabArquitetura.Core.Interfaces.ApplicationServices;
using LabArquitetura.Core.Interfaces.Queries;
using LabArquitetura.Core.Interfaces.Commands;
using LabArquitetura.Core.Interfaces.Services;
using LabArquitetura.Core.Models;
using LabArquitetura.Core.Types;

namespace LabArquitetura.Core.ApplicationServices
{
    public sealed class OnboardingApplication<TModel> : IOnboardingApplication<TModel> where TModel : Funcionario
    {
        private readonly IMaquinaQuery _maquinaQuery;
        private readonly IUsuarioQuery _usuarioQuery;
        private readonly IFuncionarioCommand<TModel> _funcionarioCommand;
        private readonly IFolhaService _folhaService;
        private readonly IEMailService _emailService;
        private readonly ParametroFolhaDomainService _parametroFolhaDomainService;

        public OnboardingApplication(
            IMaquinaQuery maquinaQuery,
            IUsuarioQuery usuarioQuery,
            IFuncionarioCommand<TModel> funcionarioCommand,
            IFolhaService folhaService,
            IEMailService emailService)
        {
            _maquinaQuery = maquinaQuery;
            _usuarioQuery = usuarioQuery;
            _folhaService = folhaService;
            _emailService = emailService;
            _funcionarioCommand = funcionarioCommand;

            _parametroFolhaDomainService = new ParametroFolhaDomainService();
        }

        public OnboardFuncionarioResult<TModel> OnboardFuncionario(TModel funcionario)
        {
            bool parametroFolhaHabilitado = false;

            // Verificar se a maquina ja esta pronta
            bool maquinaOk = _maquinaQuery.ExisteMaquinaProCPF(funcionario.CPF);

            // Verificar se ja tem usuario de rede
            bool usuarioRedeOk = _usuarioQuery.ExisteUsuarioProCPF(funcionario.CPF);

            // Habilitar parametro X no sistema de folha se for elegível
            if (_parametroFolhaDomainService.PodeHabilitarFolha(funcionario.CPF!))
            {
                parametroFolhaHabilitado = _folhaService.HabilitaParametroProCPF(funcionario.CPF);
            }

            bool funcionarioSalvo = false;
            if (maquinaOk & usuarioRedeOk & parametroFolhaHabilitado)
            {

                funcionarioSalvo = _funcionarioCommand.Salvar(funcionario).Success;
            }

            // Envia e-mail de boas vindas
            if (maquinaOk & usuarioRedeOk & parametroFolhaHabilitado & funcionarioSalvo)
            {
                _emailService.EnviarBoasVindas(funcionario);
            }

            // Retornar resumo do onboarding
            return new OnboardFuncionarioResult<TModel>
            {
                Funcionario = funcionario,
                MaquinaPronta = maquinaOk,
                UsuarioRedeCriado = usuarioRedeOk,
                ParametroFolhaHabilitado = parametroFolhaHabilitado,
                FuncionarioSalvo = funcionarioSalvo
            };
        }
    }
}