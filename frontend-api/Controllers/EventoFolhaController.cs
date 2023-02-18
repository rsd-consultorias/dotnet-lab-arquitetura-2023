using System;
using LabArquitetura.Core.Infrastrucuture.Commands;
using LabArquitetura.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LabArquitetura.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/v1/[controller]")]
    public class EventoFolhaController : Controller
    {
        private readonly IEventoFolhaCommand _eventoFolhaCommand;

        public EventoFolhaController(IEventoFolhaCommand eventoFolhaCommand)
        {
            _eventoFolhaCommand = eventoFolhaCommand;
        }

        [HttpPost]
        public ApiResponse<bool> RegistrarEvento(EventoFolhaRequest eventoFolhaRequest)
        {
            var success = _eventoFolhaCommand.RegistrarEvento(eventoFolhaRequest.ToModel()).Success;
            return ApiResponse<bool>.CreateQueuedResponse(success, eventoFolhaRequest.Referrer);
        }
    }
}

