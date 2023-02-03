using FrontEndAPI.Core.Models;
using FrontEndAPI.Core.Types;

namespace FrontEndAPI.Core.Interfaces;

public interface IOnboardingApplication
{
    OnboardFuncionarioResult OnboardFuncionario(Funcionario funcionario);
}
