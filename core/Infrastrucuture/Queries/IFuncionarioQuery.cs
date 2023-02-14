using LabArquitetura.Core.Models;

namespace LabArquitetura.Core.Infrastrucuture.Queries
{

    public interface IFuncionarioQuery
    {
        IEnumerable<Funcionario> ListarTodos();
    }
}