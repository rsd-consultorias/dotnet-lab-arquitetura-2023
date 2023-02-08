using core.Types;
using LabArquitetura.Core.Interfaces;
using LabArquitetura.Core.Interfaces.Commands;
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

        public CommandResponse<FuncionarioDbModel> Salvar(FuncionarioDbModel funcionario)
        {
            var response = new CommandResponse<FuncionarioDbModel>();

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