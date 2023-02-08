using System;
using LabArquitetura.Infrastructure.Repositories.Contexts;
using LabArquitetura.Infrastructure.Repositories.Models;
using LabArquitetura.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LabArquitetura.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/v1/funcionarios")]
    public class FuncionariosController : Controller
    {
        private readonly LabArquiteturaDbContext _dbContext;

        public FuncionariosController(LabArquiteturaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public ApiResponse<FuncionarioDbModel> BuscarPorId([FromRoute] Guid id)
        {
            var response = new ApiResponse<FuncionarioDbModel>();
            response.Body = _dbContext.Funcionarios.First(x => id.Equals(x.Id));

            return response;
        }
    }
}

