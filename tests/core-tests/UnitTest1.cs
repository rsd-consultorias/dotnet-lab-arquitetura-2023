using FrontEndAPI.Core.DomainServices;

namespace core_tests;

[TestFixture]
public class Tests
{
    private ParametroFolhaDomainService _parametroFolhaDomainService;

    [SetUp]
    public void Setup()
    {
        _parametroFolhaDomainService = new ParametroFolhaDomainService();
    }

    [Test]
    [TestCase("12345678901")]
    [TestCase("12345678902")]
    [TestCase("12345654901")]
    public void PodeHabilitarFolha_Cpf_Valido(string cpf)
    {
        Assert.IsTrue(_parametroFolhaDomainService.PodeHabilitarFolha(cpf), "Deve retornar true para CPF com 11 caracteres");
    }

    [Test]
    [TestCase("1234567890")]
    [TestCase("1237890")]
    [TestCase("12345690")]
    [TestCase("1234567430")]
    public void PodeHabilitarFolha_Cpf_Invalido(string cpf)
    {
        Assert.IsFalse(_parametroFolhaDomainService.PodeHabilitarFolha(cpf), "Deve retornar false para CPF diferente de 11 caracteres");
    }
}