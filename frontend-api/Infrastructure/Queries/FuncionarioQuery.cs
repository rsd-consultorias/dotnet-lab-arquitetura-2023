using LabArquitetura.Core.Infrastrucuture.Queries;
using LabArquitetura.Infrastructure.DbContexts.Models;
using LabArquitetura.Infrastructure.DbContexts.Contexts;
using LabArquitetura.Core.Models;
using Microsoft.EntityFrameworkCore;
using LabArquitetura.Extensions;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            return _context.Funcionarios.AsNoTracking()
            .Include(x => x.Documentos)
            .Include(x => x.Enderecos)
                .OrderBy(x => x.Nome);
        }
    }
}