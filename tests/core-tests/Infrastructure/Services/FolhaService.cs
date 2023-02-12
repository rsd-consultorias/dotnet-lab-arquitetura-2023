using LabArquitetura.Core.Interfaces.Services;

namespace LabArquitetura.Infrastructure.Services
{
    public sealed class FolhaService : IFolhaService
    {
        public Task<string> GetStatusProcessamento()
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