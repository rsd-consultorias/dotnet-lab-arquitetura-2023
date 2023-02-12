using core.Types;

namespace LabArquitetura.Core.Interfaces.Services
{

    public interface IFolhaService
    {
        bool HabilitaParametroProCPF(string? cPF);
        Task<ServiceStatusResponse> GetStatusProcessamento();
    }
}