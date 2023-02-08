using LabArquitetura.Core.Interfaces.Services;

namespace LabArquitetura.Infrastructure.Services
{
    public sealed class FolhaService : IFolhaService
    {
        public bool HabilitaParametroProCPF(string? cpf)
        {
            // Chamar API da ADP
            return true;
        }
    }
}