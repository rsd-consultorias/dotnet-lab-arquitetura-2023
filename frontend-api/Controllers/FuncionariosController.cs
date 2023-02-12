﻿using System;
using LabArquitetura.Core.Interfaces.Services;
using LabArquitetura.Core.Models;
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
        private readonly IFolhaService _folhaService;

        public FuncionariosController(
            IFolhaService folhaService,
            LabArquiteturaDbContext dbContext)
        {
            _folhaService = folhaService;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Listar todos os funcionários Ativos
        /// </summary>
        [HttpGet("")]
        public PaginatedResult<Funcionario>? ListarTodos([FromQuery] int? page = 1, [FromQuery] string? filter = null)
        {

            var searchTerms = new List<SearchTerm> {
                //new SearchTerm("cpf", "Contains", "347"),
                //new SearchTerm("cpf", "EndsWith", "4")
            };

            return _dbContext.Funcionarios.AsNoTracking()
                .OrderBy(x => x.Nome).FilterAndPaginate(searchTerms, page!);
        }

        [HttpGet("{id}")]
        public ApiResponse<Funcionario> BuscarPorId([FromRoute] Guid id)
        {
            var response = new ApiResponse<Funcionario>();
            response.Body = _dbContext.Funcionarios.AsNoTracking().First(x => id.Equals(x.Id));

            return response;
        }

        [HttpPost("")]
        public ApiResponse<Funcionario> Alterar([FromBody] Funcionario funcionario, [FromQuery] string? returnUrl = null)
        {
            var response = new ApiResponse<Funcionario>();
            response.ReturnUrl = returnUrl!;

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
        public ApiResponse<bool> Excluir([FromRoute] Guid id, [FromQuery] string? returnUrl = null)
        {
            var response = new ApiResponse<bool>();
            response.ReturnUrl = returnUrl!;

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

        [HttpGet("status-folha")]
        public async Task<ApiResponse<string>> StatusFolha()
        {
            return new ApiResponse<string> {
                Body = await _folhaService.GetStatusProcessamento(),
                Status = "Success"
            };
        }
    }
}
