using LabArquitetura.Core.Infrastrucuture.Queries;
using LabArquitetura.Core.Infrastrucuture.Commands;
using LabArquitetura.Core.Infrastrucuture.Services;
using LabArquitetura.Infrastructure.Commands;
using LabArquitetura.Infrastructure.DBContexts.Models;

namespace core_tests
{
    [TestFixture]
    public class Tests
    {
        private ParametroFolhaDomainService? _parametroFolhaDomainService;
        private IMaquinaQuery? _maquinaQuery;
        private IUsuarioQuery? _usuarioQuery;
        private IFuncionarioCommand<FuncionarioDB>? _funcionarioCommand;
        private IFolhaService? _folhaService;
        private IEMailService? _emailService;
        private OnboardingApplication<FuncionarioDB>? _onboardingApplication;

        [SetUp]
        public void Setup()
        {
            _parametroFolhaDomainService = new ParametroFolhaDomainService();
            _maquinaQuery = new MaquinaQuery();
            _usuarioQuery = new UsuarioQuery();
            _funcionarioCommand = new FuncionarioCommand();
            _folhaService = new FolhaService();
            _emailService = new EMailService();

            _onboardingApplication = new OnboardingApplication<FuncionarioDB>(
                _maquinaQuery!,
                _usuarioQuery!,
                _funcionarioCommand!,
                _folhaService!,
                _emailService!);
        }

        [Test]
        [Description("Verificar cpf diferente com 11 dígitos")]
        [TestCaseSource(typeof(FuncionariosSource), nameof(FuncionariosSource.Validos))]
        public void Test_PodeHabilitarFolha_Cpf_Valido(FuncionarioDB funcionario)
        {
            Assert.That(_parametroFolhaDomainService!.PodeHabilitarFolha(funcionario.CPF!), Is.True, "Deve retornar true para CPF com 11 caracteres");
        }

        [Test]
        [Description("Verificar cpf diferente de 11 dígitos")]
        [TestCaseSource(typeof(FuncionariosSource), nameof(FuncionariosSource.Invalidos))]
        public void Test_PodeHabilitarFolha_Cpf_Invalido(FuncionarioDB funcionario)
        {
            Assert.That(_parametroFolhaDomainService!.PodeHabilitarFolha(funcionario.CPF!), Is.False, "Deve retornar false para CPF diferente de 11 caracteres");
        }

        [Test]
        [TestCaseSource(typeof(FuncionariosSource), nameof(FuncionariosSource.Validos))]
        public void Test_REQ_01_Cenario_01(FuncionarioDB funcionario)
        {
            var result = _onboardingApplication!.OnboardFuncionario(funcionario);

            Assert.That(result, Is.Not.Null, "Deve retornar um objeto com o resultado do onboarding");
            Assert.That(result.MaquinaPronta, Is.True, "Deve retornar maquina pronta");
            Assert.That(result.ParametroFolhaHabilitado, Is.True, "Deve retornar parametro folha habilitado");
            Assert.That(result.UsuarioRedeCriado, Is.True, "Deve retornar usuario rede criado");
            Assert.That(result.FuncionarioSalvo, Is.True, "Deve retornar que o funcionário foi salvo");
        }
    }
}