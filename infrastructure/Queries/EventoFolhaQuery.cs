using System;
using LabArquitetura.Core.Infrastrucuture.Queries;
using LabArquitetura.Core.Models;
using LabArquitetura.Core.Types;
using LabArquitetura.Infrastructure.DBContexts.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LabArquitetura.Core.Infrastrucuture.Queries
{
    public class EventoFolhaQuery : IEventoFolhaQuery
    {
        private readonly LabArquiteturaDbContext _context;

        public EventoFolhaQuery(LabArquiteturaDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<EventoFolha>> ListarEventosPorFuncionarioIdEPeriodo(Guid funcionarioId, Periodo periodo)
        {
            var eventos = _context.EventosFolha.AsNoTracking().Where(x => funcionarioId.Equals(x.FuncionarioId)).AsEnumerable();

            return Task.FromResult(eventos);
        }

        public Task<IEnumerable<EventoFolha>> ListarEventosPorPeriodo(Periodo periodo)
        {
            throw new NotImplementedException();
        }
    }
}

