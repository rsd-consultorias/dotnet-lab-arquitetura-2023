namespace LabArquitetura.Core.Infrastrucuture.Queries
{

    public interface IUsuarioQuery
    {
        bool ExisteUsuarioProCPF(string? cpf);
    }
}