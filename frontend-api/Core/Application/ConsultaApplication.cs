using FrontEndAPI.Core.Interfaces;

namespace FrontEndAPI.Core.Application
{
    public sealed class ConsultaApplication : IConsultaApplication
    {
        private UInt16 _contador;

        public ConsultaApplication()
        {
            System.Console.WriteLine("ConsultaAplicacao... ctor");
        }

        public String Test()
        {
            this._contador++;
            System.Console.WriteLine($"Contador: {_contador}");
            return $"OK {_contador}";
        }
    }
}