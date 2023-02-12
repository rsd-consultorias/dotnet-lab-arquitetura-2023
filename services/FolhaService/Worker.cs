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
            this.Status = string.Format("Worker running at Start: {0}", DateTimeOffset.UtcNow);
            _logger.LogInformation(Status);
            _serviceStatus.Status = Status;
            await Task.Delay(60000, stoppingToken);

            this.Status = string.Format("Worker running at A: {0}", DateTimeOffset.UtcNow);
            _logger.LogInformation(Status);
            _serviceStatus.Status = Status;
            await Task.Delay(60000, stoppingToken);

            this.Status = string.Format("Worker running at B: {0}", DateTimeOffset.UtcNow);
            _logger.LogInformation(Status);
            _serviceStatus.Status = Status;
            await Task.Delay(60000, stoppingToken);

            this.Status = string.Format("Worker running at C: {0}", DateTimeOffset.UtcNow);
            _logger.LogInformation(Status);
            _serviceStatus.Status = Status;
            await Task.Delay(60000, stoppingToken);

            this.Status = string.Format("Worker running at Finish: {0}", DateTimeOffset.UtcNow);
            _serviceStatus.Status = Status;
            _logger.LogInformation(Status);

            await Task.Delay(1000, stoppingToken);
        }
    }
}
