using System;
using LabArquitetura.Extensions;
using LabArquitetura.Infrastructure.Repositories.Contexts;
using LabArquitetura.Infrastructure.Repositories.Models;
using LabArquitetura.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabArquitetura.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/[controller]")]
    public class FuncionariosController : Controller
    {
        private readonly LabArquiteturaDbContext _dbContext;

        public FuncionariosController(LabArquiteturaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Listar todos os funcionários Ativos
        /// </summary>
        [HttpGet("")]
        public PaginatedResult<FuncionarioDbModel>? ListarTodos([FromQuery] int? page = 1)
        {
            return _dbContext.Funcionarios.AsNoTracking().OrderBy(x => x.Nome).Paginate(page!);
        }

        [HttpGet("{id}")]
        public ApiResponse<FuncionarioDbModel> BuscarPorId([FromRoute] Guid id)
        {
            var response = new ApiResponse<FuncionarioDbModel>();
            response.Body = _dbContext.Funcionarios.AsNoTracking().First(x => id.Equals(x.Id));

            return response;
        }

        [HttpPost("")]
        public ApiResponse<FuncionarioDbModel> Alterar([FromBody] FuncionarioDbModel funcionario)
        {
            var response = new ApiResponse<FuncionarioDbModel>();

            try
            {
                funcionario.DataAlteracao = DateTime.UtcNow;
                var updated = _dbContext.Funcionarios.Update(funcionario);
                response.Body = updated.Entity;
                response.Status = "Success";
                _dbContext.SaveChanges();
            }
            catch (Exception exception)
            {
                response.Status = "Error";
                response.Errors = new List<string> { exception.Message };
            }

            return response;
        }

        [HttpDelete("{id}")]
        public ApiResponse<bool> Excluir([FromRoute] Guid id)
        {
            var response = new ApiResponse<bool>();

            try
            {
                var funcionarioToRemove = _dbContext.Funcionarios.First(x => id.Equals(x.Id));
                var deleted = _dbContext.Funcionarios.Remove(funcionarioToRemove);
                _dbContext.SaveChanges();
                response.Status = "Success";
            }
            catch (Exception ex)
            {
                response.Status = "Error";
                response.Errors = new List<string> { ex.Message };
            }

            return response;
        }
    }
}

