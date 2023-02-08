using LabArquitetura.Core.Models;

namespace LabArquitetura.Core.Interfaces.Queries
{

    public interface IFuncionarioQuery<TModel> where TModel : Funcionario
    {
        IEnumerable<TModel> ListarTodos();
    }
}