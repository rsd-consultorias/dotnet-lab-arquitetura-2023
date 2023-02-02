using FrontEndAPI.Core.Interfaces;
using FrontEndAPI.Core.Models;

namespace FrontEndAPI.Core.Application;

public sealed class OutraConsultaApplication : IOutraConsultaApplication
{
    private readonly IConsultaApplication _consultaApplication;

    public OutraConsultaApplication(IConsultaApplication consultaApplication)
    {
        _consultaApplication = consultaApplication;
        System.Console.WriteLine("OutraConsultaAplicacao.... ctor");
    }

    public Entidade Test(Int32 id)
    {
        return _consultaApplication.Test(id);
    }
}
