using FrontEndAPI.Core.Interfaces;

namespace FrontEndAPI.Infrastructure.Queries;

public sealed class UsuarioQuery : IUsuarioQuery
{
    public bool ExisteUsuarioProCPF(string? cpf)
    {
        // Buscar no AD
        return true;
    }
}
