namespace LabArquitetura.Core.Models
{

    public abstract class Funcionario
    {
        public string? CPF { get; set; }
        public string? Nome { get; set; }
        public string? EMail { get; set; }

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