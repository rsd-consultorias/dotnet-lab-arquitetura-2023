namespace FrontEndAPI.Core.DomainServices;
public sealed class ParametroFolhaDomainService
{
    public bool PodeHabilitarFolha(string cpf)
    {
        Thread.Sleep(5000);
        return cpf.Length == 11 & cpf.StartsWith("347");
    }
}