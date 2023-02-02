using FrontEndAPI.Core.Interfaces;
using FrontEndAPI.Core.Models;

namespace FrontEndAPI.Core.Application
{
    public sealed class ConsultaApplication : IConsultaApplication
    {
        private UInt16 _contador;
        private readonly IEntidadeQuery _entidadeQuery;

        public ConsultaApplication(IEntidadeQuery entidadeQuery)
        {
            _entidadeQuery = entidadeQuery;
            System.Console.WriteLine("ConsultaAplicacao... ctor");
        }

        public Entidade Test(Int32 id)
        {
            this._contador++;
            System.Console.WriteLine($"Contador: {_contador}");
            return this._entidadeQuery.BuscarPorId(id);
        }
    }
}