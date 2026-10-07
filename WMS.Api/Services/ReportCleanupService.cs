using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Entities;

namespace WMS.Api.Services;

public class ReportCleanupService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<ReportCleanupService> _logger;
    private static readonly TimeSpan CheckInterval = TimeSpan.FromHours(24); // Runs daily

    public ReportCleanupService(
        IServiceScopeFactory scopeFactory,
        ILogger<ReportCleanupService> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Report Cleanup Hosted Service is starting.");

        using var timer = new PeriodicTimer(CheckInterval);

        // Run immediately on application startup, then repeat every 24 hours
        do
        {
            try
            {
                await CleanupOldReportsAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while executing report cleanup background job.");
            }
        }
        while (await timer.WaitForNextTickAsync(stoppingToken));
    }

    private async Task CleanupOldReportsAsync(CancellationToken cancellationToken)
    {
        using var scope = _scopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<WMSContext>();

        var cutoffDate = DateTimeOffset.UtcNow.AddDays(-7);

        // Find jobs created over 7 days ago
        var expiredJobs = await dbContext.ReportJobs
            .Where(job => job.CreatedAt < cutoffDate)
            .ToListAsync(cancellationToken);

        if (!expiredJobs.Any())
        {
            _logger.LogInformation("Report Cleanup: No expired reports found (> 7 days).");
            return;
        }

        _logger.LogInformation("Report Cleanup: Found {Count} expired report jobs to process.", expiredJobs.Count);

        foreach (var job in expiredJobs)
        {
            // 1. Delete physical file from disk if it exists
            if (!string.IsNullOrWhiteSpace(job.FilePath))
            {
                try
                {
                    var absolutePath = Path.Combine(Directory.GetCurrentDirectory(), job.FilePath);
                    if (File.Exists(absolutePath))
                    {
                        File.Delete(absolutePath);
                        _logger.LogInformation("Deleted report file: {FilePath}", absolutePath);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Could not delete physical file for Job #{JobId} at {FilePath}", job.Id, job.FilePath);
                }
            }

            // 2. Remove job record from database
            dbContext.ReportJobs.Remove(job);
        }

        // 3. Save database changes
        await dbContext.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Report Cleanup: Successfully removed {Count} report records from database.", expiredJobs.Count);
    }
}