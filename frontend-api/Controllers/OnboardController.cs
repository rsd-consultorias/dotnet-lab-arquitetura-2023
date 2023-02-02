using FrontEndAPI.Core.Interfaces;
using FrontEndAPI.Core.Models;
using FrontEndAPI.Core.Types;
using Microsoft.AspNetCore.Mvc;

namespace FrontEndAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/rh/[controller]")]
    public class OnboardController : ControllerBase
    {
        private readonly IConsultaApplication _consultaApplication;
        private readonly IFuncionarioQuery _funcionarioQuery;

        public OnboardController(
            IConsultaApplication consultaApplication,
            IFuncionarioQuery funcionarioQuery)
        {
            _consultaApplication = consultaApplication;
            _funcionarioQuery = funcionarioQuery;
        }

        [HttpGet]
        [Route("/")]
        public OnboardFuncionarioResult? Get()
        {
            return this._consultaApplication.OnboardFuncionario(new Funcionario(cpf: "1234567890", nome: "Funcionario de Testes", email: "fute@teste.com"));
        }

        /// <summary>
        /// Listar todos os funcionários Ativos
        /// </summary>
        [HttpGet]
        [Route("/todos")]
        public IEnumerable<Funcionario>? GetAllActive()
        {
            return _funcionarioQuery.ListarTodos();
        }

        /// <summary>
        /// Listar todos os funcionários Ativos por setor
        /// </summary>
        [HttpGet]
        [Route("/{setor}/todos")]
        public IEnumerable<Funcionario>? GetAllBySetor(string setor)
        {
            return _funcionarioQuery.ListarTodos();
        }
    }
}