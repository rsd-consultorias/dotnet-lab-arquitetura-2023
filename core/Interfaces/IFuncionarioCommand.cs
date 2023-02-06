using LabArquitetura.Core.Models;

namespace LabArquitetura.Core.Interfaces
{

    public interface IFuncionarioCommand<TModel> where TModel : Funcionario
    {
        bool Salvar(TModel funcionario);
    }
}