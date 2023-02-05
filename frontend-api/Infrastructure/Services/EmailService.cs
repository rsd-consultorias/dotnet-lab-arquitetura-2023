using FrontEndAPI.Core.Interfaces;
using FrontEndAPI.Core.Models;

namespace FrontEndAPI.Infrastructure.Services;

public sealed class EMailService : IEMailService
{
    private readonly Serilog.ILogger _logger;

    public EMailService(Serilog.ILogger logger)
    {
        _logger = logger;
    }

    public void EnviarBoasVindas(Funcionario funcionario)
    {
        // Chamar API do MailChimp
        _logger.Information($"Enviando email de boas vindas para {funcionario.EMail}");
    }
}
