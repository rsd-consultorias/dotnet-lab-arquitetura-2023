namespace FolhaWorker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public string Status { get; set; } = string.Empty;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
        Task.FromResult(ExecuteAsync(new CancellationToken { }));
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            this.Status = string.Format("Worker running at Start: {0}", DateTimeOffset.UtcNow);
            _logger.LogInformation(Status);
            await Task.Delay(3000, stoppingToken);

            this.Status = string.Format("Worker running at A: {0}", DateTimeOffset.UtcNow);
            _logger.LogInformation(Status);
            await Task.Delay(3000, stoppingToken);

            this.Status = string.Format("Worker running at B: {0}", DateTimeOffset.UtcNow);
            _logger.LogInformation(Status);
            await Task.Delay(3000, stoppingToken);

            this.Status = string.Format("Worker running at C: {0}", DateTimeOffset.UtcNow);
            _logger.LogInformation(Status);
            await Task.Delay(3000, stoppingToken);

            this.Status = string.Format("Worker running at Finish: {0}", DateTimeOffset.UtcNow);
            _logger.LogInformation(Status);

            await Task.Delay(1000, stoppingToken);
        }
    }
}
