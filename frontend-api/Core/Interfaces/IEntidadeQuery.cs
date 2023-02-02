using FrontEndAPI.Core.Models;

namespace FrontEndAPI.Core.Interfaces;

public interface IEntidadeQuery
{
    Entidade BuscarPorId(Int32 id);
    List<Entidade> BuscarEntidadesAtivas();
}
