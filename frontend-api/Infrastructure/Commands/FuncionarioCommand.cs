using LabArquitetura.Core.Interfaces;
using LabArquitetura.Infrastructure.Repositories.Contexts;
using LabArquitetura.Infrastructure.Repositories.Models;

namespace LabArquitetura.Infrastructure.Commands
{
    public class FuncionarioCommand : IFuncionarioCommand<FuncionarioDbModel>
    {
        private readonly LabArquiteturaDbContext _context;

        public FuncionarioCommand(LabArquiteturaDbContext context)
        {
            _context = context;
        }

        public bool Salvar(FuncionarioDbModel funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            _context.SaveChangesAsync();

            return true;
        }
    }
}