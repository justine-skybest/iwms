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

    public CheckInCleanupService(
        WMSContext dbContext,
        ILogger<CheckInCleanupService> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<CheckInCleanupReport> CleanupStaleCheckInsAsync(
        int batchSize = 100,
        CancellationToken cancellationToken = default)
    {
        if (batchSize <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(batchSize),
                "Batch size must be greater than zero.");
        }

        var deactivatedNoProducts = 0;
        var deactivatedFullyPicked = 0;
        var stillActiveCount = 0;

        // Snapshot the active CheckIn IDs so processing is performed in batches.
        var activeCheckInIds = await _dbContext.CheckIns
            .AsNoTracking()
            .Where(ci => ci.IsActive)
            .OrderBy(ci => ci.Id)
            .Select(ci => ci.Id)
            .ToListAsync(cancellationToken);

        var totalScanned = activeCheckInIds.Count;

        _logger.LogInformation(
            "Beginning CheckIn cleanup audit for {Count} active CheckIns.",
            totalScanned);

        for (var i = 0; i < activeCheckInIds.Count; i += batchSize)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var currentBatchIds = activeCheckInIds
                .Skip(i)
                .Take(batchSize)
                .ToList();

            var checkIns = await _dbContext.CheckIns
                .Include(ci => ci.ReceivedProducts)
                .Include(ci => ci.Pallet)
                    .ThenInclude(pallet => pallet!.ReceivedProducts)
                .Where(ci => currentBatchIds.Contains(ci.Id) && ci.IsActive)
                .ToListAsync(cancellationToken);

            // Products can be attached directly to a CheckIn or indirectly through its pallet.
            var productsByCheckIn = checkIns.ToDictionary(
                ci => ci.Id,
                ci => ci.ReceivedProducts
                    .Concat(ci.Pallet?.ReceivedProducts
                        ?? Enumerable.Empty<ReceivedProduct>())
                    .DistinctBy(product => product.Id)
                    .ToList());

            var batchProductIds = productsByCheckIn.Values
                .SelectMany(products => products)
                .Select(product => product.Id)
                .Distinct()
                .ToList();

            // Pick quantities are scoped to the CheckIn that was picked.
            var pickedDictionary = batchProductIds.Count == 0
                ? new Dictionary<(int CheckInId, int ReceivedProductId), int>()
                : await _dbContext.PickedProducts
                    .AsNoTracking()
                    .Where(pp =>
                        pp.ManualPicking != null &&
                        pp.ManualPicking.CheckInId.HasValue &&
                        currentBatchIds.Contains(pp.ManualPicking.CheckInId.Value) &&
                        batchProductIds.Contains(pp.ReceivedProductId))
                    .GroupBy(pp => new
                    {
                        CheckInId = pp.ManualPicking!.CheckInId!.Value,
                        pp.ReceivedProductId
                    })
                    .Select(group => new
                    {
                        group.Key.CheckInId,
                        group.Key.ReceivedProductId,
                        TotalPicked = group.Sum(pp => (int?)pp.QuantityPicked) ?? 0
                    })
                    .ToDictionaryAsync(
                        item => (item.CheckInId, item.ReceivedProductId),
                        item => item.TotalPicked,
                        cancellationToken);

            foreach (var checkIn in checkIns)
            {
                var products = productsByCheckIn[checkIn.Id];


                if (!checkIn.ReceivedProducts.Any() &&
                    !checkIn.PalletId.HasValue)
                {
                    deactivatedNoProducts++;
                    checkIn.IsActive = false;
                    checkIn.CheckOutDate = DateTime.UtcNow;
                    checkIn.Notes = AppendNote(
                        checkIn.Notes,
                        "Cleanup: Deactivated because no items present in this checked in.");
                }

                // Case 2: Every product currently assigned to this CheckIn is fully picked.
                var allProductsFullyPicked = products.All(product =>
                {
                    pickedDictionary.TryGetValue(
                        (checkIn.Id, product.Id),
                        out var totalPicked);

                    return totalPicked >= product.Quantity;
                });

                if (allProductsFullyPicked)
                {
                    DeactivateCheckIn(
                        checkIn,
                        "Cleanup: Deactivated because all assigned items were fully picked.");

                    deactivatedFullyPicked++;
                    continue;
                }

                // Case 3: At least one product still has available quantity.
                stillActiveCount++;
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        _logger.LogInformation(
            "CheckIn cleanup complete. Scanned: {Scanned}, No products: {NoProducts}, Fully picked: {FullyPicked}, Still active: {Active}.",
            totalScanned,
            deactivatedNoProducts,
            deactivatedFullyPicked,
            stillActiveCount);

        return new CheckInCleanupReport(
            totalScanned,
            deactivatedNoProducts,
            deactivatedFullyPicked,
            stillActiveCount);
    }

    private static void DeactivateCheckIn(CheckIn checkIn, string reason)
    {
        checkIn.IsActive = false;
        checkIn.CheckOutDate = DateTime.UtcNow;
        checkIn.Notes = AppendNote(checkIn.Notes, reason);
    }

    private static string AppendNote(string? existingNotes, string newNote)
    {
        return string.IsNullOrWhiteSpace(existingNotes)
            ? newNote
            : $"{existingNotes} | {newNote}";
    }
}
