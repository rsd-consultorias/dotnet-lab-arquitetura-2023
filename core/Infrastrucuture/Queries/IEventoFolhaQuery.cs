using System;
using LabArquitetura.Core.Types;
using LabArquitetura.Core.Models;

namespace core.Infrastrucuture.Queries
{
	public interface IEventoFolhaQuery
    {
        Task<IEnumerable<EventoFolha>> ListarEventosProcessados(Periodo periodo);
        Task<IEnumerable<EventoFolha>> ListarEventosNaoProcessados(Periodo periodo);
        Task<IEnumerable<EventoFolha>> ListarEventosProcessadosPorFuncionarioId(Guid funcionarioId, Periodo periodo);
        Task<IEnumerable<EventoFolha>> ListarEventosNaoProcessadosPorFuncionarioId(Guid funcionarioId, Periodo periodo);
    }
}

