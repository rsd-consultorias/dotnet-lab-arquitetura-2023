using LabArquitetura.Core.Interfaces.Services;
using LabArquitetura.Core.Models;

namespace LabArquitetura.Infrastructure.Services
{

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
}