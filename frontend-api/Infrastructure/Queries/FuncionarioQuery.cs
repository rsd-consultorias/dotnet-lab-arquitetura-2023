using FrontEndAPI.Core.Interfaces;
using FrontEndAPI.Core.Models;
using FrontEndAPI.Infrastructure.Repositories.Contexts;

namespace FrontEndAPI.Infrastructure.Queries;
public sealed class FuncionarioQuery : IFuncionarioQuery
{
    private readonly LabArquiteturaDbContext _context;
    public FuncionarioQuery(LabArquiteturaDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Funcionario> ListarTodos()
    {
        return _context.Funcionarios.Where<Funcionario>(x => x.Nome != "");
    }
}
