using FrontEndAPI.Core.Interfaces;
using FrontEndAPI.Core.Models;

namespace FrontEndAPI.Infrastructure.Services;

public sealed class EMailService : IEMailService
{
    public void EnviarBoasVindas(Funcionario funcionario)
    {
        // Chamar API do MailChimp
        Console.WriteLine($"Enviando email para {funcionario.EMail}");
    }
}
