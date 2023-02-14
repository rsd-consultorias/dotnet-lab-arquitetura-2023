using LabArquitetura.Core.Models;
using LabArquitetura.Infrastructure.DBContexts.Models;

namespace LabArquitetura.ViewModels
{

    public class FuncionarioRequest : ApiRequest
    {
        public string? CPF { get; set; }
        public string? Nome { get; set; }
        public string? EMail { get; set; }

        public FuncionarioRequest() { }

        public Funcionario ToModel()
        {
            return new Funcionario(CPF!, Nome!, EMail!);
        }
    }
}