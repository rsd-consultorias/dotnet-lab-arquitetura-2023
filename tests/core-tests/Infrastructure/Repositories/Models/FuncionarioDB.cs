using LabArquitetura.Core.Models;

namespace LabArquitetura.Infrastructure.Repositories.Models
{
	public class FuncionarioDB : Funcionario
    {
		public int Id { get; set; }

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
