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
        private readonly IOnboardingApplication _consultaApplication;
        private readonly IFuncionarioQuery _funcionarioQuery;

        public OnboardController(
            IOnboardingApplication consultaApplication,
            IFuncionarioQuery funcionarioQuery)
        {
            _consultaApplication = consultaApplication;
            _funcionarioQuery = funcionarioQuery;
        }

        [HttpGet()]
        public OnboardFuncionarioResult? Get()
        {
            return this._consultaApplication.OnboardFuncionario(new Funcionario(cpf: "1234567890", nome: "Funcionario de Testes", email: "fute@teste.com"));
        }

        /// <summary>
        /// Listar todos os funcionários Ativos
        /// </summary>
        [HttpGet("todos")]
        public IEnumerable<Funcionario>? GetAllActive()
        {
            return _funcionarioQuery.ListarTodos();
        }

        [HttpPost]
        public IActionResult Salvar([FromBody] FuncionarioRequest funcionario)
        {
            Console.WriteLine("==================");
            Console.WriteLine(funcionario.Nome);
            Console.WriteLine(funcionario.CPF);
            Console.WriteLine(funcionario.EMail);
            Console.WriteLine("==================");
            return Ok(this._consultaApplication.OnboardFuncionario(funcionario.ToModel()));
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