using LabArquitetura.Infrastructure.Repositories.Models;

namespace LabArquitetura.Infrastructure.Commands
{
    public class FuncionarioCommand : IFuncionarioCommand<FuncionarioDB>
    {
        public bool Salvar(FuncionarioDB funcionario)
        {
            return true;
        }
    }
}