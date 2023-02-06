using LabArquitetura.Core.Models;

namespace LabArquitetura.Core.Interfaces
{

    public interface IEMailService
    {
        void EnviarBoasVindas(Funcionario funcionario);
    }
}