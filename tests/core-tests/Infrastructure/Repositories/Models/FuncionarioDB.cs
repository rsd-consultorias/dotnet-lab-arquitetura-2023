using LabArquitetura.Core.Models;

namespace LabArquitetura.Infrastructure.DBContexts.Models
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
