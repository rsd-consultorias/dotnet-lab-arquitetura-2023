using core.Types;
using LabArquitetura.Core.Models;

namespace LabArquitetura.Core.Interfaces.Commands
{

    public interface IFuncionarioCommand<TModel> where TModel : Funcionario
    {
        public CommandResponse<TModel> Salvar(TModel funcionario);
    }
}