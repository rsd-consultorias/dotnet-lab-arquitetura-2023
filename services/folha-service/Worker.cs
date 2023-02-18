using Core.ApplicationServices;
using FolhaService.Services;
using LabArquitetura.Core.Infrastrucuture.Queries;
using LabArquitetura.Core.Types;

namespace FolhaWorker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IProcessamentoFolhaApplication _processamentoFolhaApplication;

    private readonly ServiceStatus _serviceStatus;

    public string Status { get; set; } = string.Empty;

    public Worker(ILogger<Worker> logger,
        ServiceStatus serviceStatus,
        IProcessamentoFolhaApplication processamentoFolhaApplication)
    {
        _logger = logger;
        _processamentoFolhaApplication = processamentoFolhaApplication;
        _serviceStatus = serviceStatus;
    }

    private void LogProgresso(UInt16 percentual, string mensagem)
    {
        _serviceStatus.Status = mensagem;
        _serviceStatus.Progress = percentual;
        this.Status = $"{percentual}% - {mensagem}";
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _processamentoFolhaApplication.RodarFolhaNoPeriodo(new Periodo { Inicio = DateTime.Now }, "", LogProgresso);

            await Task.Delay(60000, stoppingToken);
        }
    }
}
