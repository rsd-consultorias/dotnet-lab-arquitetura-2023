using LabArquitetura.Core.Types;

namespace LabArquitetura.Core.Infrastrucuture.Services
{

    public interface IFolhaService
    {
        bool HabilitaParametroProCPF(string? cPF);
        Task<ServiceStatusResponse> GetStatusProcessamento();
    }
}