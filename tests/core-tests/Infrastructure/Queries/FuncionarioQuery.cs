using FrontEndAPI.Core.Interfaces;
using FrontEndAPI.Core.Models;
using FrontEndAPI.Infrastructure.Repositories.Contexts;

namespace FrontEndAPI.Infrastructure.Queries;
public sealed class FuncionarioQuery : IFuncionarioQuery
{
    public FuncionarioQuery()
    {
    }

    public IEnumerable<Funcionario> ListarTodos()
    {
        var lista = new List<Funcionario>();
        lista.Add(new Funcionario("123456456", "DB Funcionario de Testes", "fute@teste.com"));
        lista.Add(new Funcionario("123456456", "Funcionario de Testes", "fute@teste.com"));
        lista.Add(new Funcionario("123456456", "Funcionario de Testes", "fute@teste.com"));
        lista.Add(new Funcionario("123456456", "Funcionario de Testes", "fute@teste.com"));

        return lista;
    }
}
