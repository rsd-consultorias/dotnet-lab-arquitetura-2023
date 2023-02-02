using FrontEndAPI.Core.Interfaces;

namespace FrontEndAPI.Infrastructure.Queries
{
    public sealed class UsuarioQuery : IUsuarioQuery
    {
        public bool existeUsuarioProCPF(string? cPF)
        {
            // Buscar no AD
            return true;
        }
    }
}