using FrontEndAPI.Core.Interfaces;

namespace FrontEndAPI.Infrastructure.Services {
    public sealed class FolhaService : IFolhaService
    {
        public bool HabilitaParametroProCPF(string? cPF)
        {
            // Chamar API da ADP
            return true;
        }
    }
}