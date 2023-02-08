using LabArquitetura.Core.Models;

namespace LabArquitetura.Core.Interfaces.Services
{

    public interface IEMailService
    {
        void EnviarBoasVindas(Funcionario funcionario);
    }
}