namespace LabArquitetura.Core.Interfaces.Queries
{

    public interface IUsuarioQuery
    {
        bool ExisteUsuarioProCPF(string? cpf);
    }
}