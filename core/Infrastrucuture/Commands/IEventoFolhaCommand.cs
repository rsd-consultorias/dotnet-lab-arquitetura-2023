using System;
using LabArquitetura.Core.Types;
using LabArquitetura.Core.Models;

namespace LabArquitetura.Core.Infrastrucuture.Commands
{
	public interface IEventoFolhaCommand
	{
        CommandResponse RegistrarEvento(EventoFolha eventoFolha);
	}
}
