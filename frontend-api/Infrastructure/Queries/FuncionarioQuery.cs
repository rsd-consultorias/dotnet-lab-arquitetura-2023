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

        var lista = new List<Funcionario>();
        lista.Add(new Funcionario("123456456", "DB Funcionario de Testes", "fute@teste.com"));
        lista.Add(new Funcionario("123456456", "Funcionario de Testes", "fute@teste.com"));
        lista.Add(new Funcionario("123456456", "Funcionario de Testes", "fute@teste.com"));
        lista.Add(new Funcionario("123456456", "Funcionario de Testes", "fute@teste.com"));

        lista.ForEach(func => _context.Funcionarios.Add(func));
        _context.SaveChanges();
    }

    public IEnumerable<Funcionario> ListarTodos()
    {
        return _context.Funcionarios.Where<Funcionario>(x => x.Nome != "");
    }
}
