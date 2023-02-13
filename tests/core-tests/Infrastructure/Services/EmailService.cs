using LabArquitetura.Core.Infrastrucuture.Services;
using LabArquitetura.Core.Models;

namespace LabArquitetura.Infrastructure.Services
{
    public sealed class EMailService : IEMailService
    {
        public void EnviarBoasVindas(Funcionario funcionario)
        {
            // Chamar API do MailChimp
            Console.WriteLine($"Enviando email para {funcionario.EMail}");
        }
    }
}