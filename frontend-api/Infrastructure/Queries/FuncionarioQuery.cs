using LabArquitetura.Core.Interfaces.Queries;
using LabArquitetura.Infrastructure.Repositories.Models;
using LabArquitetura.Infrastructure.Repositories.Contexts;

namespace LabArquitetura.Infrastructure.Queries
{
    public sealed class FuncionarioQuery : IFuncionarioQuery<FuncionarioDbModel>
    {
        private readonly LabArquiteturaDbContext _context;
        public FuncionarioQuery(LabArquiteturaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<FuncionarioDbModel> ListarTodos()
        {
            return _context.Funcionarios.AsQueryable().Where(x => x.Nome != "");
        }
    }
}