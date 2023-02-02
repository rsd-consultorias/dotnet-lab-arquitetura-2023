using FrontEndAPI.Core.Interfaces;
using FrontEndAPI.Core.Models;

namespace FrontEndAPI.Infrastructure.Queries
{
    public sealed class EntidadeQuery : IEntidadeQuery
    {
        public List<Entidade> BuscarEntidadesAtivas()
        {
            throw new NotImplementedException();
        }

        public Entidade BuscarPorId(int id)
        {
            return new Entidade
            {
                Id = id,
                Nome = "Teste de Teste",
                Ativa = true
            };
        }
    }
}