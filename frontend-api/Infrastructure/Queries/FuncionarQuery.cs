using FrontEndAPI.Core.Interfaces;
using FrontEndAPI.Core.Models;

namespace FrontEndAPI.Infrastructure.Queries {
    public sealed class FuncionarioQuery : IFuncionarioQuery
    {
        public IEnumerable<Funcionario> ListarTodos()
        {
            var lista = new List<Funcionario>();
            lista.Add(new Funcionario("123456456", "Funcionario de Testes", "fute@teste.com"));
            lista.Add(new Funcionario("123456456", "Funcionario de Testes", "fute@teste.com"));
            lista.Add(new Funcionario("123456456", "Funcionario de Testes", "fute@teste.com"));
            lista.Add(new Funcionario("123456456", "Funcionario de Testes", "fute@teste.com"));

            return lista;
        }
    }
}