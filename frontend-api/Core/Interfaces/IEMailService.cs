using FrontEndAPI.Core.Models;

namespace FrontEndAPI.Core.Interfaces;

public interface IEMailService
{
    void EnviarBoasVindas(Funcionario funcionario);
}
