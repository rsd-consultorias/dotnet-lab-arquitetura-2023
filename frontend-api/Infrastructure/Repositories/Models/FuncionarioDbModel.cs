using LabArquitetura.Core.Models;

namespace LabArquitetura.Infrastructure.Repositories.Models
{
    public class FuncionarioDbModel : Funcionario
    {
        public Guid Id { get; set; }

        public FuncionarioDbModel()
        {
            Id = Guid.NewGuid();
        }

        public FuncionarioDbModel(string cpf, string nome, string email)
        {
            Id = Guid.NewGuid();
            CPF = cpf;
            Nome = nome;
            EMail = email;
        }
    }
}
