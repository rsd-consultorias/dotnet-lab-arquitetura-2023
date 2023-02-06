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
            bool enqueue = false;
            try
            {
                var salvarTask = Task<ApiResponse<OnboardFuncionarioResult>>.Factory.StartNew(() =>
                {
                    var apiResponseTemp = new ApiResponse<OnboardFuncionarioResult>();
                    apiResponseTemp.Body = this._onboardApplication.OnboardFuncionario(funcionario.ToModel());

                    if ((!apiResponseTemp.Body!.MaquinaPronta || !apiResponseTemp.Body!.ParametroFolhaHabilitado || !apiResponseTemp.Body!.UsuarioRedeCriado) && enqueue)
                    {
                        string msgQueue = $"CPF: {funcionario.CPF} => Maquina: {apiResponseTemp.Body.MaquinaPronta}, Folha: {apiResponseTemp.Body.ParametroFolhaHabilitado}, Usuário: {apiResponseTemp.Body.UsuarioRedeCriado}";
                        _dbContext.Queues.Add(new Infrastructure.Repositories.Models.Queue()
                        {
                            Message = msgQueue,
                            Read = false,
                            Body = JsonSerializer.Serialize(funcionario),
                            Referrer = funcionario.Referrer
                        });
                        _dbContext.SaveChanges();
                    }
                    apiResponseTemp.Status = Constants.STATUS_SUCCESS;
                    return apiResponseTemp;
                });

                if (!(await Task.WhenAny(salvarTask, Task.Delay(250)) == salvarTask))
                {
                    enqueue = true;
                    apiResponse.Status = Constants.STATUS_QUEUED;
                    return Ok(apiResponse);
                }
                else
                {
                    return Ok(salvarTask.Result);
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