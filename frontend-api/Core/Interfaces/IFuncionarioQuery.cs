using FrontEndAPI.Core.Models;

namespace FrontEndAPI.Core.Interfaces {
    public interface IFuncionarioQuery {
        IEnumerable<Funcionario> ListarTodos();
    }
}