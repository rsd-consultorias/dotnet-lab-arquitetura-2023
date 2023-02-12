using FolhaService.Services;

namespace FolhaWorker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private ServiceStatus _serviceStatus;

    public string Status { get; set; } = string.Empty;

    public Worker(ILogger<Worker> logger, ServiceStatus serviceStatus)
    {
        _logger = logger;
        _serviceStatus = serviceStatus;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _serviceStatus.Progress = 0;
            _serviceStatus.Status = string.Empty;
            await Task.Delay(6000, stoppingToken);
            this.Status = string.Format("Worker running at Start: {0}", DateTimeOffset.UtcNow);
            _logger.LogInformation(Status);
            _serviceStatus.Status = Status;
            _serviceStatus.Progress = 10;
            await Task.Delay(6000, stoppingToken);

            this.Status = string.Format("Worker running at A: {0}", DateTimeOffset.UtcNow);
            _logger.LogInformation(Status);
            _serviceStatus.Status = Status;

            for (var i = 10; i < 40; i++)
            {
                _serviceStatus.Progress = i;
                await Task.Delay(6000 / 30, stoppingToken);
            }

            this.Status = string.Format("Worker running at B: {0}", DateTimeOffset.UtcNow);
            _logger.LogInformation(Status);
            _serviceStatus.Status = Status;

            for (var i = 40; i < 60; i++)
            {
                _serviceStatus.Progress = i;
                await Task.Delay(6000 / 20, stoppingToken);
            }

            this.Status = string.Format("Worker running at C: {0}", DateTimeOffset.UtcNow);
            _logger.LogInformation(Status);
            _serviceStatus.Status = Status;

            for (var i = 60; i < 90; i++)
            {
                _serviceStatus.Progress = i;
                await Task.Delay(6000 / 30, stoppingToken);
            }

            this.Status = string.Format("Worker running at Finishing: {0}", DateTimeOffset.UtcNow);
            _serviceStatus.Status = Status;
            _logger.LogInformation(Status);

            for (var i = 90; i <= 100; i++)
            {
                _serviceStatus.Progress = i;
                await Task.Delay(6000 / 10, stoppingToken);
            }
            this.Status = string.Format("Worker running Finish: {0}", DateTimeOffset.UtcNow);
            _serviceStatus.Status = Status;

            await Task.Delay(10000, stoppingToken);
        }
    }
}
