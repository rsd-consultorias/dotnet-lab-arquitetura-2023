using LabArquitetura.Core.Infrastrucuture.Queries;
using LabArquitetura.Core.Models;
using LabArquitetura.Infrastructure.DBContexts.Models;

namespace LabArquitetura.Infrastructure.Queries
{
    public sealed class FuncionarioQuery : IFuncionarioQuery
    {
        public FuncionarioQuery()
        {
        }

        public IEnumerable<Funcionario> ListarTodos()
        {
            var lista = new List<Funcionario>
        {
            new FuncionarioDB("123456456", "DB Funcionario de Testes", "fute@teste.com"),
            new FuncionarioDB("123456456", "Funcionario de Testes", "fute@teste.com"),
            new FuncionarioDB("123456456", "Funcionario de Testes", "fute@teste.com"),
            new FuncionarioDB("123456456", "Funcionario de Testes", "fute@teste.com")
        };

            return lista;
        }
    }
}