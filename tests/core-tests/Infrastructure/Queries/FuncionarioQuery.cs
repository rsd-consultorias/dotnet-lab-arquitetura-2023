using LabArquitetura.Infrastructure.Repositories.Models;

namespace LabArquitetura.Infrastructure.Queries
{
    public sealed class FuncionarioQuery : IFuncionarioQuery<FuncionarioDB>
    {
        public FuncionarioQuery()
        {
        }

        public IEnumerable<FuncionarioDB> ListarTodos()
        {
            var lista = new List<FuncionarioDB>
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