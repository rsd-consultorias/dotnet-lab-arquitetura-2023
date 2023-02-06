namespace LabArquitetura.Core.Interfaces
{

    public interface IUsuarioQuery
    {
        bool ExisteUsuarioProCPF(string? cpf);
    }
}