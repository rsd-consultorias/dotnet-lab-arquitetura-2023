using LabArquitetura.Core.Types;
using LabArquitetura.Core.Infrastrucuture.Commands;
using LabArquitetura.Infrastructure.DBContexts.Models;

namespace LabArquitetura.Infrastructure.Commands
{
    public class FuncionarioCommand : IFuncionarioCommand<FuncionarioDB>
    {
        public CommandResponse<FuncionarioDB> Salvar(FuncionarioDB funcionario)
        {
            var response = new CommandResponse<FuncionarioDB>();
            response.Data = funcionario;
            response.Success = true;

            return response;
        }
    }
}