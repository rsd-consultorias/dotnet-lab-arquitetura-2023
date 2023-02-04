using FrontEndAPI.Infrastructure.Commands;

namespace core_tests;

[TestFixture]
public class Tests
{
    private ParametroFolhaDomainService? _parametroFolhaDomainService;
    private IMaquinaQuery? _maquinaQuery;
    private IUsuarioQuery? _usuarioQuery;
    private IFuncionarioCommand _funcionarioCommand;
    private IFolhaService? _folhaService;
    private IEMailService? _emailService;
    private OnboardingApplication? _onboardingApplication;

    [SetUp]
    public void Setup()
    {
        _parametroFolhaDomainService = new ParametroFolhaDomainService();
        _maquinaQuery = new MaquinaQuery();
        _usuarioQuery = new UsuarioQuery();
        _funcionarioCommand = new FuncionarioCommand();
        _folhaService = new FolhaService();
        _emailService = new EMailService();

        _onboardingApplication = new OnboardingApplication(
            _maquinaQuery!,
            _usuarioQuery!,
            _funcionarioCommand!,
            _folhaService!,
            _emailService!);
    }

    [Test]
    [Description("Verificar cpf diferente com 11 dígitos")]
    [TestCaseSource(typeof(FuncionariosSource), nameof(FuncionariosSource.Validos))]
    public void Test_PodeHabilitarFolha_Cpf_Valido(Funcionario funcionario)
    {
        Assert.IsTrue(_parametroFolhaDomainService!.PodeHabilitarFolha(funcionario.CPF!), "Deve retornar true para CPF com 11 caracteres");
    }

    [Test]
    [Description("Verificar cpf diferente de 11 dígitos")]
    [TestCaseSource(typeof(FuncionariosSource), nameof(FuncionariosSource.Invalidos))]
    public void Test_PodeHabilitarFolha_Cpf_Invalido(Funcionario funcionario)
    {
        Assert.IsFalse(_parametroFolhaDomainService!.PodeHabilitarFolha(funcionario.CPF!), "Deve retornar false para CPF diferente de 11 caracteres");
    }

    [Test]
    [TestCaseSource(typeof(FuncionariosSource), nameof(FuncionariosSource.Validos))]
    public void Test_REQ_01_Cenario_01(Funcionario funcionario)
    {
        var result = _onboardingApplication!.OnboardFuncionario(funcionario);

        Assert.IsNotNull(result, "Deve retornar um objeto com o resultado do onboarding");
        Assert.IsTrue(result.MaquinaPronta, "Deve retornar maquina pronta");
        Assert.IsTrue(result.ParametroFolhaHabilitado, "Deve retornar parametro folha habilitado");
        Assert.IsTrue(result.UsuarioRedeCriado, "Deve retornar usuario rede criado");
    }
}