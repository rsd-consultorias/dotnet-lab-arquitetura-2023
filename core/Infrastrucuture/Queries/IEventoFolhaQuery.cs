using System;
using LabArquitetura.Core.Types;
using LabArquitetura.Core.Models;

namespace LabArquitetura.Core.Infrastrucuture.Queries
{
    public interface IEventoFolhaQuery
    {
        Task<IEnumerable<EventoFolha>> ListarEventosPorPeriodo(Periodo periodo);
        Task<IEnumerable<EventoFolha>> ListarEventosPorFuncionarioIdEPeriodo(Guid funcionarioId, Periodo periodo);
    }
}

