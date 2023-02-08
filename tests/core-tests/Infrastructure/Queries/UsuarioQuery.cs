using LabArquitetura.Core.Interfaces.Queries;

namespace LabArquitetura.Infrastructure.Queries
{
    public sealed class UsuarioQuery : IUsuarioQuery
    {
        public bool ExisteUsuarioProCPF(string? cpf)
        {
            // Buscar no AD
            return true;
        }
    }
}