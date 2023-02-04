using FrontEndAPI.Core.DomainServices;
using FrontEndAPI.Core.Interfaces;
using FrontEndAPI.Core.Models;
using FrontEndAPI.Core.Types;

namespace FrontEndAPI.Core.ApplicationServices;

public sealed class OnboardingApplication : IOnboardingApplication
{
    private readonly IMaquinaQuery _maquinaQuery;
    private readonly IUsuarioQuery _usuarioQuery;
    private readonly IFuncionarioCommand _funcionarioCommand;
    private readonly IFolhaService _folhaService;
    private readonly IEMailService _emailService;
    private readonly ParametroFolhaDomainService _parametroFolhaDomainService;

    public OnboardingApplication(
        IMaquinaQuery maquinaQuery,
        IUsuarioQuery usuarioQuery,
        IFuncionarioCommand funcionarioCommand,
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

    public OnboardFuncionarioResult OnboardFuncionario(Funcionario funcionario)
    {
        var maquinaOk = false;
        var usuarioRedeOk = false;
        var parametroFolhaHabilitado = false;

        // Verificar se a maquina ja esta pronta
        maquinaOk = _maquinaQuery.ExisteMaquinaProCPF(funcionario.CPF);

        // Verificar se ja tem usuario de rede
        usuarioRedeOk = _usuarioQuery.ExisteUsuarioProCPF(funcionario.CPF);

        // Habilitar parametro X no sistema de folha se for elegível
        if (_parametroFolhaDomainService.PodeHabilitarFolha(funcionario.CPF!))
        {
            parametroFolhaHabilitado = _folhaService.HabilitaParametroProCPF(funcionario.CPF);
        }

        // Envia e-mail de boas vindas
        if (maquinaOk & usuarioRedeOk & parametroFolhaHabilitado)
        {
            _emailService.EnviarBoasVindas(funcionario);
        }

        var funcionarioSalvo = false;
        if (maquinaOk & usuarioRedeOk & parametroFolhaHabilitado)
        {

            funcionarioSalvo = _funcionarioCommand.Salvar(funcionario);
        }

        // Retornar resumo do onboarding
        return new OnboardFuncionarioResult
        {
            Funcionario = funcionario,
            MaquinaPronta = maquinaOk,
            UsuarioRedeCriado = usuarioRedeOk,
            ParametroFolhaHabilitado = parametroFolhaHabilitado,
            FuncionarioSalvo = funcionarioSalvo
        };
    }
}