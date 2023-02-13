namespace LabArquitetura.Core.Infrastrucuture.Queries
{

    public interface IMaquinaQuery
    {
        bool ExisteMaquinaProCPF(string? cPF);
    }
}