namespace LabArquitetura.Core.Models
{

    public abstract class Funcionario
    {
        public abstract string? CPF { get; protected set; }
        public abstract string? Nome { get; protected set; }
        public abstract string? EMail { get; protected set; }

        public Funcionario()
        { }

        public Funcionario(string cpf, string nome, string email)
        {
            CPF = cpf;
            Nome = nome;
            EMail = email;
        }
    }
}