using FrontEndAPI.Core.Models;
using FrontEndAPI.Core.Types;

namespace FrontEndAPI.Core.Interfaces
{

    public interface IConsultaApplication
    {
        Entidade Test(Int32 id);
        OnboardFuncionarioResult OnboardFuncionario(Funcionario funcionario);
    }
}