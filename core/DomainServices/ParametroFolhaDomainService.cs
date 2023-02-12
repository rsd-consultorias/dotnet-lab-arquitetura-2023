namespace LabArquitetura.Core.DomainServices
{
    public sealed class ParametroFolhaDomainService
    {
        public bool PodeHabilitarFolha(string cpf)
        {
            return cpf.Length == 11;
        }
    }
}