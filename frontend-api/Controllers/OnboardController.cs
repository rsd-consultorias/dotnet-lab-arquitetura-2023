using FrontEndAPI.Core.Interfaces;
using FrontEndAPI.Core.Models;
using FrontEndAPI.Core.Types;
using FrontEndAPI.Infrastructure.Repositories.Contexts;
using FrontEndAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FrontEndAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/[controller]")]
    public class OnboardController : Controller
    {
        private readonly IOnboardingApplication _onboardApplication;
        private readonly IFuncionarioQuery _funcionarioQuery;
        private readonly ILogger _logger;
        private readonly LabArquiteturaDbContext _dbContext;

        public OnboardController(
            IOnboardingApplication consultaApplication,
            IFuncionarioQuery funcionarioQuery,
            ILogger<OnboardController> logger,
            LabArquiteturaDbContext dbContext)
        {
            _onboardApplication = consultaApplication;
            _funcionarioQuery = funcionarioQuery;
            _logger = logger;
            _dbContext = dbContext;
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
        public async Task<IActionResult> Salvar([FromBody] FuncionarioRequest funcionario)
        {
            var apiResponse = new ApiResponse<OnboardFuncionarioResult>();
            try
            {
                Task salvarTask = Task.Run(() =>
                {
                    apiResponse.Body = this._onboardApplication.OnboardFuncionario(funcionario.ToModel());
                    apiResponse.Status = Constants.STATUS_SUCCESS;

                    if (!apiResponse.Body.MaquinaPronta || !apiResponse.Body.ParametroFolhaHabilitado || !apiResponse.Body.UsuarioRedeCriado)
                    {
                        string msgQueue = $"CPF: {funcionario.CPF} => Maquina: {apiResponse.Body.MaquinaPronta}, Folha: {apiResponse.Body.ParametroFolhaHabilitado}, Usuário: {apiResponse.Body.UsuarioRedeCriado}";
                        _dbContext.Queues.Add(new Infrastructure.Repositories.Models.Queue()
                        {
                            Message = msgQueue,
                            Read = false,
                            Body = JsonSerializer.Serialize(funcionario),
                            Referrer = funcionario.Referrer
                        });
                        _dbContext.SaveChangesAsync();
                    }
                });

                if (!(await Task.WhenAny(salvarTask, Task.Delay(250)) == salvarTask))
                {
                    apiResponse.Status = Constants.STATUS_QUEUED;
                    return Ok(apiResponse);
                }

            }
            catch (Exception exception)
            {
                apiResponse.Status = Constants.STATUS_ERROR;
                apiResponse.Errors = new List<string> { exception.Message };
                _logger.LogError(new EventId(1000, "API"), exception, "Erro ao salvar funcionário");
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