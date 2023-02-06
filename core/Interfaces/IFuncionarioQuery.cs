using LabArquitetura.Core.Models;

namespace LabArquitetura.Core.Interfaces
{

    public interface IFuncionarioQuery<TModel> where TModel : Funcionario
    {
        IEnumerable<TModel> ListarTodos();
    }
}