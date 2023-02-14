using LabArquitetura.Core.Types;
using LabArquitetura.Core.Models;

namespace LabArquitetura.Core.Infrastrucuture.Commands
{

    public interface IFuncionarioCommand<TModel> where TModel : Funcionario
    {
        public CommandResponse<TModel> Salvar(TModel funcionario);
    }
}