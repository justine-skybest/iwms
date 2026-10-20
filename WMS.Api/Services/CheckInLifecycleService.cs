using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Entities;

namespace WMS.Api.Services
{
    public static class CheckInLifecycleService
    {
        public static async Task<bool> CheckAndCloseIfEmptiedAsync(
            WMSContext dbContext,
            int checkInId,
            CancellationToken cancellationToken = default)
        {
            var checkIn = await dbContext.CheckIns
                .Include(ci => ci.ReceivedProducts)
                .Include(ci => ci.Pallet)
                    .ThenInclude(p => p!.ReceivedProducts)
                .FirstOrDefaultAsync(ci => ci.Id == checkInId && ci.IsActive, cancellationToken);

            if (checkIn is null)
            {
                return false;
            }

            // 1. Gather all products linked directly or via Pallet
            var products = checkIn.ReceivedProducts
                .Concat(checkIn.Pallet?.ReceivedProducts ?? Enumerable.Empty<ReceivedProduct>())
                .DistinctBy(p => p.Id)
                .ToList();

            // 2. If it has no products assigned, mark inactive immediately
            if (products.Count == 0)
            {
                checkIn.IsActive = false;
                checkIn.CheckOutDate = DateTime.UtcNow;
                checkIn.Notes = AppendNote(checkIn.Notes, "Auto-checked out: No products assigned to pallet/check-in.");
                await dbContext.SaveChangesAsync(cancellationToken);
                return true;
            }

            // 3. Sum total picked quantities for this check-in
            var productIds = products.Select(p => p.Id).ToList();
            var pickedTotals = await dbContext.PickedProducts
                .AsNoTracking()
                .Where(pp => pp.ManualPicking != null &&
                             pp.ManualPicking.CheckInId.HasValue &&
                             pp.ManualPicking.CheckInId.Value == checkInId &&
                             productIds.Contains(pp.ReceivedProductId))
                .GroupBy(pp => pp.ReceivedProductId)
                .Select(g => new
                {
                    ReceivedProductId = g.Key,
                    TotalPicked = g.Sum(pp => (int?)pp.QuantityPicked) ?? 0
                })
                .ToDictionaryAsync(x => x.ReceivedProductId, x => x.TotalPicked, cancellationToken);

            // 4. Check if every single product is completely picked
            bool allProductsDepleted = products.All(p =>
            {
                pickedTotals.TryGetValue(p.Id, out var totalPicked);
                return totalPicked >= p.Quantity;
            });

            if (allProductsDepleted)
            {
                checkIn.IsActive = false;
                checkIn.CheckOutDate = DateTime.UtcNow;
                checkIn.Notes = AppendNote(checkIn.Notes, "Auto-checked out: All items completely picked.");
                await dbContext.SaveChangesAsync(cancellationToken);
                return true;
            }

            return false;
        }

        private static string AppendNote(string? existingNotes, string newNote) =>
            string.IsNullOrWhiteSpace(existingNotes) ? newNote : $"{existingNotes} | {newNote}";
    }
}
