using LabArquitetura.Core.Models;
using LabArquitetura.Core.Types;

namespace LabArquitetura.Core.ApplicationServices
{

    public interface IOnboardingApplication<TModel> where TModel : Funcionario
    {
        OnboardFuncionarioResult<TModel> OnboardFuncionario(TModel funcionario);
    }
}