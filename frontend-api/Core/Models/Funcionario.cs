namespace FrontEndAPI.Core.Models;

public class Funcionario
{
    public int Id { get; set; }
    public string? CPF { get; private set; }
    public string? Nome { get; private set; }
    public string? EMail { get; private set; }

    public Funcionario(string cpf, string nome, string email)
    {
        CPF = cpf;
        Nome = nome;
        EMail = email;
    }
}
