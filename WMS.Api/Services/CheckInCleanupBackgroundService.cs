namespace WMS.Api.Services;

public class CheckInCleanupBackgroundService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<CheckInCleanupBackgroundService> _logger;

    // Default interval: runs every 1 hour (adjust as needed)
    private readonly TimeSpan _period = TimeSpan.FromHours(1);

    public CheckInCleanupBackgroundService(
        IServiceScopeFactory scopeFactory,
        IConfiguration configuration,
        ILogger<CheckInCleanupBackgroundService> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;

        var minutes = configuration.GetValue("CheckInCleanup:IntervalInMinutes", 60);
        _period = TimeSpan.FromMinutes(minutes);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Check-in cleanup background service initialized with interval: {Period}.", _period);

        // Optional: initial delay to prevent running during application startup contention
        await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);

        using var timer = new PeriodicTimer(_period);

        while (!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
        {
            try
            {
                _logger.LogInformation("Scheduled check-in cleanup starting...");

                // Create a distinct scope for each execution to ensure DB contexts are properly disposed
                using (var scope = _scopeFactory.CreateScope())
                {
                    var cleanupService = scope.ServiceProvider.GetRequiredService<ICheckInCleanupService>();
                    var report = await cleanupService.CleanupStaleCheckInsAsync(batchSize: 100, stoppingToken);

                    _logger.LogInformation(
                        "Scheduled cleanup completed: {Scanned} scanned, {NoProducts} empty deactivated, {FullyPicked} fully picked deactivated, {Active} remaining active.",
                        report.TotalScanned,
                        report.DeactivatedWithNoProducts,
                        report.DeactivatedFullyPicked,
                        report.StillActiveCount);
                }
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                // Graceful host shutdown requested
                break;
            }
            catch (Exception ex)
            {
                // Catch any exception so the background worker does not crash the application host
                _logger.LogError(ex, "An unhandled error occurred during background check-in cleanup.");
            }
        }

        _logger.LogInformation("Check-in cleanup background service is stopping.");
    }
}
