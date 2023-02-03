using FrontEndAPI.Core.Interfaces;
using FrontEndAPI.Core.Models;

namespace FrontEndAPI.Core.ApplicationServices;

public sealed class OutraConsultaApplication : IOutraConsultaApplication
{
    private readonly IOnboardingApplication _consultaApplication;

    public OutraConsultaApplication(IOnboardingApplication consultaApplication)
    {
        _consultaApplication = consultaApplication;
    }
}
