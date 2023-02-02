namespace FrontEndAPI.Core.Interfaces {
    public interface IUsuarioQuery
    {
        bool existeUsuarioProCPF(string? cPF);
    }
}