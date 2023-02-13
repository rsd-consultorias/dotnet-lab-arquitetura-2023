using LabArquitetura.Core.Models;

namespace LabArquitetura.Core.Infrastrucuture.Services
{

    public interface IEMailService
    {
        void EnviarBoasVindas(Funcionario funcionario);
    }
}