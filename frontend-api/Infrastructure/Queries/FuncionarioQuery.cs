using LabArquitetura.Core.Interfaces.Queries;
using LabArquitetura.Infrastructure.Repositories.Models;
using LabArquitetura.Infrastructure.Repositories.Contexts;
using LabArquitetura.Core.Models;

namespace LabArquitetura.Infrastructure.Queries
{
    public sealed class FuncionarioQuery : IFuncionarioQuery<Funcionario>
    {
        private readonly LabArquiteturaDbContext _context;
        public FuncionarioQuery(LabArquiteturaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Funcionario> ListarTodos()
        {
            return _context.Funcionarios.AsQueryable().Where(x => x.Nome != "");
        }
    }
}