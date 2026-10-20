using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Entities;

namespace WMS.Api.Services;


public record CheckInCleanupReport(
    int TotalScanned,
    int DeactivatedWithNoProducts,
    int DeactivatedFullyPicked,
    int StillActiveCount
);

public interface ICheckInCleanupService
{
    Task<CheckInCleanupReport> CleanupStaleCheckInsAsync(
        int batchSize = 100,
        CancellationToken cancellationToken = default);
}

public class CheckInCleanupService : ICheckInCleanupService
{
    private readonly WMSContext _dbContext;
    private readonly ILogger<CheckInCleanupService> _logger;

    public CheckInCleanupService(WMSContext dbContext, ILogger<CheckInCleanupService> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<CheckInCleanupReport> CleanupStaleCheckInsAsync(
        int batchSize = 100,
        CancellationToken cancellationToken = default)
    {
        int totalScanned = 0;
        int deactivatedNoProducts = 0;
        int deactivatedFullyPicked = 0;
        int stillActiveCount = 0;

        // Fetch candidate active check-ins IDs
        var activeCheckInIds = await _dbContext.CheckIns
            .Where(ci => ci.IsActive)
            .OrderBy(ci => ci.Id)
            .Select(ci => ci.Id)
            .ToListAsync(cancellationToken);

        totalScanned = activeCheckInIds.Count;
        _logger.LogInformation("Beginning check-in cleanup audit for {Count} active check-ins.", totalScanned);

        for (int i = 0; i < activeCheckInIds.Count; i += batchSize)
        {
            var currentBatchIds = activeCheckInIds.Skip(i).Take(batchSize).ToList();

            var checkIns = await _dbContext.CheckIns
                .Include(ci => ci.ReceivedProducts)
                .Include(ci => ci.Pallet)
                    .ThenInclude(p => p!.ReceivedProducts)
                .Where(ci => currentBatchIds.Contains(ci.Id))
                .ToListAsync(cancellationToken);

            // Fetch distinct product IDs in this batch
            var batchProductIds = checkIns
                .SelectMany(ci => ci.ReceivedProducts
                    .Concat(ci.Pallet?.ReceivedProducts ?? Enumerable.Empty<ReceivedProduct>()))
                .Select(p => p.Id)
                .Distinct()
                .ToList();

            // Fetch all picked products for this batch in one round-trip
            var pickedDictionary = await _dbContext.PickedProducts
                .AsNoTracking()
                .Where(pp => pp.ManualPicking != null &&
                             pp.ManualPicking.CheckInId.HasValue &&
                             currentBatchIds.Contains(pp.ManualPicking.CheckInId.Value) &&
                             batchProductIds.Contains(pp.ReceivedProductId))
                .GroupBy(pp => new
                {
                    CheckInId = pp.ManualPicking!.CheckInId!.Value,
                    pp.ReceivedProductId
                })
                .Select(g => new
                {
                    g.Key.CheckInId,
                    g.Key.ReceivedProductId,
                    TotalPicked = g.Sum(pp => (int?)pp.QuantityPicked) ?? 0
                })
                .ToDictionaryAsync(
                    x => (x.CheckInId, x.ReceivedProductId),
                    x => x.TotalPicked,
                    cancellationToken);

            foreach (var checkIn in checkIns)
            {
                var products = checkIn.ReceivedProducts
                    .Concat(checkIn.Pallet?.ReceivedProducts ?? Enumerable.Empty<ReceivedProduct>())
                    .DistinctBy(p => p.Id)
                    .ToList();

                // Case 1: Check-in has no products
                if (products.Count == 0)
                {
                    checkIn.IsActive = false;
                    checkIn.CheckOutDate = checkIn.CheckInDate; // Use original check-in date as checkout timestamp
                    checkIn.Notes = AppendNote(checkIn.Notes, "Cleanup: Deactivated due to 0 products assigned.");
                    deactivatedNoProducts++;
                    continue;
                }

                // Case 2: Check if every product is fully picked
                bool allDepleted = products.All(p =>
                {
                    pickedDictionary.TryGetValue((checkIn.Id, p.Id), out var picked);
                    return picked >= p.Quantity;
                });

                if (allDepleted)
                {
                    checkIn.IsActive = false;
                    checkIn.CheckOutDate = DateTime.UtcNow;
                    checkIn.Notes = AppendNote(checkIn.Notes, "Cleanup: Deactivated as all items were picked.");
                    deactivatedFullyPicked++;
                }
                else
                {
                    stillActiveCount++;
                }
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        _logger.LogInformation(
            "Cleanup complete. No Products: {NoProducts}, Fully Picked: {Picked}, Still Active: {Active}",
            deactivatedNoProducts, deactivatedFullyPicked, stillActiveCount);

        return new CheckInCleanupReport(
            totalScanned,
            deactivatedNoProducts,
            deactivatedFullyPicked,
            stillActiveCount
        );
    }

    private static string AppendNote(string? existingNotes, string newNote) =>
        string.IsNullOrWhiteSpace(existingNotes) ? newNote : $"{existingNotes} | {newNote}";
}
