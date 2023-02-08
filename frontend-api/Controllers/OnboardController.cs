using LabArquitetura.Core.Interfaces;
using LabArquitetura.Core.Types;
using LabArquitetura.Infrastructure.Repositories.Models;
using LabArquitetura.Infrastructure.Repositories.Contexts;
using LabArquitetura.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LabArquitetura.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/[controller]")]
    public class OnboardController : Controller
    {
        private readonly IOnboardingApplication<FuncionarioDbModel> _onboardApplication;
        private readonly IFuncionarioQuery<FuncionarioDbModel> _funcionarioQuery;
        private readonly ILogger _logger;
        private readonly LabArquiteturaDbContext _dbContext;

        public OnboardController(
            IOnboardingApplication<FuncionarioDbModel> consultaApplication,
            IFuncionarioQuery<FuncionarioDbModel> funcionarioQuery,
            ILogger<OnboardController> logger,
            LabArquiteturaDbContext dbContext)
        {
            _onboardApplication = consultaApplication;
            _funcionarioQuery = funcionarioQuery;
            _logger = logger;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Listar todos os funcionários Ativos
        /// </summary>
        [HttpGet("todos")]
        public IEnumerable<FuncionarioDbModel>? ListarTodos()
        {
            return _funcionarioQuery.ListarTodos();
        }

        /// <summary>Salva os dados do funcionário</summary>
        [HttpPost]
        public async Task<IActionResult> Salvar([FromBody] FuncionarioRequest funcionario)
        {
            ApiResponse<OnboardFuncionarioResult<FuncionarioDbModel>> apiResponse = new();
            bool enqueue = false;
            try
            {
                Task<ApiResponse<OnboardFuncionarioResult<FuncionarioDbModel>>> salvarTask = Task<ApiResponse<OnboardFuncionarioResult<FuncionarioDbModel>>>.Factory.StartNew(() =>
                {
                    if (funcionario.CPF!.Contains("999"))
                    {
                        Thread.Sleep(5000);
                    }

                    ApiResponse<OnboardFuncionarioResult<FuncionarioDbModel>> apiResponseTemp = new()
                    {
                        Body = _onboardApplication.OnboardFuncionario(funcionario.ToModel())
                    };

                    if ((!apiResponseTemp.Body!.MaquinaPronta || !apiResponseTemp.Body!.ParametroFolhaHabilitado || !apiResponseTemp.Body!.UsuarioRedeCriado) && enqueue)
                    {
                        string msgQueue = $"CPF: {funcionario.CPF} => Maquina: {apiResponseTemp.Body.MaquinaPronta}, Folha: {apiResponseTemp.Body.ParametroFolhaHabilitado}, Usuário: {apiResponseTemp.Body.UsuarioRedeCriado}";
                        _ = _dbContext.Queues.Add(new QueueDbModel()
                        {
                            Message = msgQueue,
                            Read = false,
                            Body = JsonSerializer.Serialize(funcionario),
                            Referrer = funcionario.Referrer,
                            ActionType = Constants.ACTION_RETRY
                        });
                    }
                    else
                    {
                        if (enqueue)
                        {
                            _ = _dbContext.Queues.Add(new QueueDbModel()
                            {
                                Message = $"CPF: {funcionario.CPF!} incluído com sucesso",
                                Read = false,
                                Referrer = funcionario.Referrer,
                                ActionType = Constants.ACTION_INFORM
                            });
                        }
                    }
                    _dbContext.SaveChangesAsync();
                    apiResponseTemp.Status = Constants.STATUS_SUCCESS;
                    return apiResponseTemp;
                });

                if (!(await Task.WhenAny(salvarTask, Task.Delay(500)) == salvarTask))
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
        public IEnumerable<FuncionarioDbModel>? ListarPorSetor([FromRoute] string setor)
        {
            return _funcionarioQuery.ListarTodos();
        }
    }
}