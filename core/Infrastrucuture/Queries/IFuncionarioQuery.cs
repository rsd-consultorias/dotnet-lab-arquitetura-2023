using LabArquitetura.Core.Models;

namespace LabArquitetura.Core.Infrastrucuture.Queries
{

    public interface IFuncionarioQuery<TModel> where TModel : Funcionario
    {
        IEnumerable<TModel> ListarTodos();
    }
}