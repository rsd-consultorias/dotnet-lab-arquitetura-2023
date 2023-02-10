using System.ComponentModel;
using LabArquitetura.Core.Models;

namespace LabArquitetura.Infrastructure.Repositories.Models
{
    public class FuncionarioDbModel : Funcionario
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime? DataAlteracao { get; set; }

        public FuncionarioDbModel()
        {
        }

        public FuncionarioDbModel(string cpf, string nome, string email)
        {
            CPF = cpf;
            Nome = nome;
            EMail = email;
        }
    }
}
