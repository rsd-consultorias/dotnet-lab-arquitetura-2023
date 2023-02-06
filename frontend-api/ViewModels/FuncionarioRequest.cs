using LabArquitetura.Infrastructure.Repositories.Models;

namespace LabArquitetura.ViewModels
{

    public class FuncionarioRequest : ApiRequest
    {
        public string? CPF { get; set; }
        public string? Nome { get; set; }
        public string? EMail { get; set; }

        public FuncionarioRequest() { }
        public FuncionarioDbModel ToModel()

        {
            return new FuncionarioDbModel(CPF!, Nome!, EMail!);
        }
    }
}