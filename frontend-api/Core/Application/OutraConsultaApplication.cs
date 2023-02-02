using FrontEndAPI.Core.Interfaces;

namespace FrontEndAPI.Core.Application
{
    public sealed class OutraConsultaApplication: IOutraConsultaApplication
    {
        private readonly IConsultaApplication _consultaApplication;

        public OutraConsultaApplication(IConsultaApplication consultaApplication)
        {
            _consultaApplication = consultaApplication;
            System.Console.WriteLine("OutraConsultaAplicacao.... ctor");
        }

        public string Test() {
            return _consultaApplication.Test();
        }
    }
}