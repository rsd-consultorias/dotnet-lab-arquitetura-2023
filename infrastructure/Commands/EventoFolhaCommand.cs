using System;
using LabArquitetura.Core.Models;
using LabArquitetura.Core.Types;
using LabArquitetura.Infrastructure.DBContexts.Contexts;

namespace LabArquitetura.Core.Infrastrucuture.Commands
{
	public class EventoFolhaCommand: IEventoFolhaCommand
    {
        private readonly LabArquiteturaDbContext _context;

        public EventoFolhaCommand(LabArquiteturaDbContext context)
        {
            _context = context;
        }

        public CommandResponse RegistrarEvento(EventoFolha eventoFolha)
        {
            var response = new CommandResponse();
            response.Success = true;
            _context.EventosFolha.AddAsync(eventoFolha).GetAwaiter().GetResult();
            _context.SaveChangesAsync().GetAwaiter().GetResult();
            return response;
        }
    }
}

