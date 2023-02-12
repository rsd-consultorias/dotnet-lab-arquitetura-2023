using core.Types;
using Grpc.Net.ClientFactory;
using LabArquitetura.Core.Interfaces.Services;
using static FolhaServiceGRPC.FolhaServiceStatus;

namespace LabArquitetura.Infrastructure.Services
{

    public sealed class FolhaService : IFolhaService
    {
        private readonly Serilog.ILogger _logger;
        private readonly FolhaServiceStatusClient _folhaServiceStatusClient;

        public FolhaService(
            FolhaServiceStatusClient folhaServiceStatusClient,
            Serilog.ILogger logger)
        {
            _folhaServiceStatusClient = folhaServiceStatusClient;
            _logger = logger;
        }

        public bool HabilitaParametroProCPF(string? cpf)
        {
            _logger.Information($"Verificando parâmetros da folha para o CPF {cpf}");

            // Chamar API da ADP
            return true;
        }

        public async Task<ServiceStatusResponse> GetStatusProcessamento()
        {
            var response = await _folhaServiceStatusClient.GetStatusAsync(new FolhaServiceGRPC.FolhaServiceStatusRequest
            {
                Cpf = ""
            });

            return new ServiceStatusResponse { Status = response.Status!, Progress = response.Progress! };
        }
    }
}