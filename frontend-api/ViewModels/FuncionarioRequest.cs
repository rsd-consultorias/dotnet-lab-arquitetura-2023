using FrontEndAPI.Core.Models;

namespace FrontEndAPI.ViewModels;

public class FuncionarioRequest
{
    public string? CPF { get; set; }
    public string? Nome { get; set; }
    public string? EMail { get; set; }

    public FuncionarioRequest(){}

    public Funcionario ToModel() {
        return new Funcionario(this.CPF!, this.Nome!, this.EMail!);
    }
}