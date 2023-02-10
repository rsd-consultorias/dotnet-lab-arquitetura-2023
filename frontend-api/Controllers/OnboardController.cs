using LabArquitetura.Core.Interfaces.ApplicationServices;
using LabArquitetura.Core.Interfaces.Queries;
using LabArquitetura.Core.Types;
using LabArquitetura.Infrastructure.Repositories.Models;
using LabArquitetura.Infrastructure.Repositories.Contexts;
using LabArquitetura.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using LabArquitetura.Core.Interfaces.Commands;
using Microsoft.Extensions.DependencyInjection;
using LabArquitetura.Infrastructure.Commands;

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
        private readonly IServiceScopeFactory _scopeFactory;

        public OnboardController(
            IOnboardingApplication<FuncionarioDbModel> consultaApplication,
            IFuncionarioQuery<FuncionarioDbModel> funcionarioQuery,
            ILogger<OnboardController> logger,
            LabArquiteturaDbContext dbContext,
            IServiceScopeFactory scopeFactory)
        {
            _onboardApplication = consultaApplication;
            _funcionarioQuery = funcionarioQuery;
            _logger = logger;
            _dbContext = dbContext;
            _scopeFactory = scopeFactory;
        }

        /// <summary>Salva os dados do funcionário</summary>
        [HttpPost]
        public async Task<IActionResult> SalvarAsync([FromBody] FuncionarioRequest funcionario)
        {
            ApiResponse<OnboardFuncionarioResult<FuncionarioDbModel>> apiResponse = new();
            bool enqueue = false;
            try
            {
                var salvarTask = Task<ApiResponse<OnboardFuncionarioResult<FuncionarioDbModel>>>.Factory.StartNew(() =>
                {
                    if (funcionario.CPF!.Contains("999")) Thread.Sleep(2000);
                    // Necessário para rodar de forma assíncrona
                    var scope = _scopeFactory.CreateAsyncScope();
                    var ctx = scope.ServiceProvider.GetRequiredService<LabArquiteturaDbContext>();
                    var ctxOnboardApplication = scope.ServiceProvider.GetRequiredService<IOnboardingApplication<FuncionarioDbModel>>();
                    // Fim: Necessário para rodar de forma assíncrona

                    ApiResponse<OnboardFuncionarioResult<FuncionarioDbModel>> apiResponseTemp = new()
                    {
                        Body = ctxOnboardApplication.OnboardFuncionario(funcionario.ToModel())
                    };

                    if ((!apiResponseTemp.Body!.MaquinaPronta || !apiResponseTemp.Body!.ParametroFolhaHabilitado || !apiResponseTemp.Body!.UsuarioRedeCriado) && enqueue)
                    {
                        string msgQueue = $"CPF: {funcionario.CPF} => Maquina: {apiResponseTemp.Body.MaquinaPronta}, Folha: {apiResponseTemp.Body.ParametroFolhaHabilitado}, Usuário: {apiResponseTemp.Body.UsuarioRedeCriado}";
                        _ = ctx.Queues.Add(new QueueDbModel()
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
                            _ = ctx.Queues.Add(new QueueDbModel()
                            {
                                Message = $"CPF: {funcionario.CPF!} incluído com sucesso",
                                Read = false,
                                Referrer = funcionario.Referrer,
                                ActionType = Constants.ACTION_INFORM
                            });
                        }
                    }
                    ctx.SaveChanges();
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
                    return Ok(await salvarTask);
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