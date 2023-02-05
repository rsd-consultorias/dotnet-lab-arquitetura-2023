using FrontEndAPI.Core.Interfaces;
using FrontEndAPI.Core.Models;
using FrontEndAPI.Core.Types;
using FrontEndAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FrontEndAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/[controller]")]
    public class OnboardController : Controller
    {
        private readonly IOnboardingApplication _onboardApplication;
        private readonly IFuncionarioQuery _funcionarioQuery;

        public OnboardController(
            IOnboardingApplication consultaApplication,
            IFuncionarioQuery funcionarioQuery)
        {
            _onboardApplication = consultaApplication;
            _funcionarioQuery = funcionarioQuery;
        }

        [HttpGet()]
        public OnboardFuncionarioResult? Get()
        {
            return this._onboardApplication.OnboardFuncionario(new Funcionario(cpf: "1234567890", nome: "Funcionario de Testes", email: "fute@teste.com"));
        }

        /// <summary>
        /// Listar todos os funcionários Ativos
        /// </summary>
        [HttpGet("todos")]
        public IEnumerable<Funcionario>? GetAllActive()
        {
            return _funcionarioQuery.ListarTodos();
        }

        /// <summary>Salva os dados do funcionário</summary>
        [HttpPost]
        public IActionResult Salvar([FromBody] FuncionarioRequest funcionario)
        {
            var apiResponse = new ApiResponse<OnboardFuncionarioResult>();
            try
            {
                apiResponse.Body = this._onboardApplication.OnboardFuncionario(funcionario.ToModel());
                apiResponse.Success = true;
            }
            catch (Exception exception)
            {
                apiResponse.Errors = new List<string> { exception.Message };
            }
            return Ok(apiResponse);
        }

        /// <summary>
        /// Listar todos os funcionários Ativos por setor
        /// </summary>
        [HttpGet("{setor}/todos")]
        public IEnumerable<Funcionario>? GetAllBySetor(string setor)
        {
            return _funcionarioQuery.ListarTodos();
        }
    }
}