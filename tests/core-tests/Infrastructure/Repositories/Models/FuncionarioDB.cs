using LabArquitetura.Core.Models;

namespace LabArquitetura.Infrastructure.DbContexts.Models
{
	public class FuncionarioDB : Funcionario
    {
        public FuncionarioDB()
        {

        }

        public FuncionarioDB(string cpf, string nome, string email)
        {
            CPF = cpf;
            Nome = nome;
            EMail = email;
        }
    }
}
