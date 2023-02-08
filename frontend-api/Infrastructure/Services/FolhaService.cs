using LabArquitetura.Core.Interfaces.Services;

namespace LabArquitetura.Infrastructure.Services
{

    public sealed class FolhaService : IFolhaService
    {
        private readonly Serilog.ILogger _logger;

        public FolhaService(Serilog.ILogger logger)
        {
            _logger = logger;
        }

        public bool HabilitaParametroProCPF(string? cpf)
        {
            _logger.Information($"Verificando parâmetros da folha para o CPF {cpf}");

            // Chamar API da ADP
            return true;
        }
    }
}