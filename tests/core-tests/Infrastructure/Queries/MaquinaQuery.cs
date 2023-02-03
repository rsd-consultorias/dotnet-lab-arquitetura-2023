using FrontEndAPI.Core.Interfaces;

namespace FrontEndAPI.Infrastructure.Queries;

public sealed class MaquinaQuery : IMaquinaQuery
{
    public bool ExisteMaquinaProCPF(string? cPF)
    {
        // Buscar na aplicação de CMDB do Service Desk
        return true;
    }
}
