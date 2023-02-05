namespace FrontEndAPI.Core.DomainServices;
public sealed class ParametroFolhaDomainService
{
    public bool PodeHabilitarFolha(string cpf)
    {
        return cpf.Length == 11 & cpf.StartsWith("347");
    }
}