using core.Types;
using LabArquitetura.Core.Interfaces.Commands;
using LabArquitetura.Infrastructure.Repositories.Models;

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