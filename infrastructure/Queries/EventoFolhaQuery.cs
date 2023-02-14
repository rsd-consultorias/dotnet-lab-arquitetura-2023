using System;
using core.Infrastrucuture.Queries;
using LabArquitetura.Core.Models;
using LabArquitetura.Core.Types;

namespace LabArquitetura.Core.Infrastrucuture.Queries
{
	public class EventoFolhaQuery : IEventoFolhaQuery
    {
		public EventoFolhaQuery()
		{
		}

        public Task<IEnumerable<EventoFolha>> ListarEventosNaoProcessados(Periodo periodo)
        {
            return null;
        }

        public Task<IEnumerable<EventoFolha>> ListarEventosNaoProcessadosPorFuncionarioId(Guid funcionarioId, Periodo periodo)
        {
            return null;
        }

        public Task<IEnumerable<EventoFolha>> ListarEventosProcessados(Periodo periodo)
        {
            return null;
        }

        public Task<IEnumerable<EventoFolha>> ListarEventosProcessadosPorFuncionarioId(Guid funcionarioId, Periodo periodo)
        {
            return null;
        }
    }
}

