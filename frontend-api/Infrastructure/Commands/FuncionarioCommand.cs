using core.Types;
using LabArquitetura.Core.Infrastrucuture;
using LabArquitetura.Core.Infrastrucuture.Commands;
using LabArquitetura.Core.Models;
using LabArquitetura.Infrastructure.DbContexts.Contexts;
using LabArquitetura.Infrastructure.DbContexts.Models;

namespace LabArquitetura.Infrastructure.Commands
{
    public class FuncionarioCommand : IFuncionarioCommand<Funcionario>
    {
        private readonly LabArquiteturaDbContext _context;

        public FuncionarioCommand(LabArquiteturaDbContext context)
        {
            _context = context;
        }

        public CommandResponse<Funcionario> Salvar(Funcionario funcionario)
        {
            var response = new CommandResponse<Funcionario>();

            try
            {
                _context.Funcionarios.Add(funcionario);
                var result = _context.SaveChanges(true);
                response.Success = result > 0;
            }
            catch (Exception exception)
            {
                response.Errors = new List<string> { exception.Message };
            }

            response.Data = funcionario;

            return response;
        }
    }
}