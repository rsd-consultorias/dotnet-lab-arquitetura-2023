using core.Types;
using LabArquitetura.Core.Infrastrucuture.Services;

namespace LabArquitetura.Infrastructure.Services
{
    public sealed class FolhaService : IFolhaService
    {
        public Task<ServiceStatusResponse> GetStatusProcessamento()
        {
            throw new NotImplementedException();
        }

        public bool HabilitaParametroProCPF(string? cpf)
        {
            // Chamar API da ADP
            return true;
        }
    }
}