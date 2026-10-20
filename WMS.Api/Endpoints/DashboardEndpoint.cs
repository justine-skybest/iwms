using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WMS.Api.Data;
using WMS.Api.Dtos.Dashboard;
using WMS.Api.Entities;

namespace WMS.Api.Endpoints;

public static class DashboardEndpoint
{
    public static RouteGroupBuilder MapDashboardEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("dashboard");

        group.MapGet("/summary", async (int? warehouseId, WMSContext dbContext, CancellationToken ct) =>
        {
            int? activeWarehouseId = (warehouseId.HasValue && warehouseId.Value > 0) ? warehouseId : null;

            var today = DateOnly.FromDateTime(DateTime.Today);
            var expiringSoonCutoff = today.AddDays(30);
            var todayStart = DateTime.Today;
            var todayEnd = todayStart.AddDays(1);

            // Helper expression for warehouse matching (handles both racked and standalone bins)
            Expression<Func<Bin, bool>> binWarehouseFilter = b =>
                activeWarehouseId == null ||
                b.WarehouseId == activeWarehouseId ||
                (b.Rack != null && b.Rack.WarehouseId == activeWarehouseId);

            // 1. Core Summary Counts
            var totalWarehouses = await dbContext.Warehouses.CountAsync(ct);

            var totalPallets = await dbContext.Pallets
                .Where(p => activeWarehouseId == null || p.WarehouseId == activeWarehouseId)
                .CountAsync(ct);

            // Pallets with products that have NO current ACTIVE check-in
            var pendingCheckInPallets = await dbContext.Pallets
                .Where(p => activeWarehouseId == null || p.WarehouseId == activeWarehouseId)
                .Where(p => p.ReceivedProducts != null && p.ReceivedProducts.Any())
                .Where(p => !dbContext.CheckIns.Any(ci => ci.IsActive && ci.PalletId == p.Id))
                .CountAsync(ct);

            // Loose items with NO current ACTIVE check-in
            var pendingCheckInItems = await dbContext.ReceivedProducts
                .Where(rp => rp.PalletId == null)
                .Where(rp => rp.Receiving != null && (activeWarehouseId == null || rp.Receiving.WarehouseId == activeWarehouseId))
                .Where(rp => !rp.CheckIns.Any(ci => ci.IsActive))
                .CountAsync(ct);

            var totalBins = await dbContext.Bins
                .Where(binWarehouseFilter)
                .CountAsync(ct);

            // Bins containing an ACTIVE check-in
            var occupiedBins = await dbContext.Bins
                .Where(binWarehouseFilter)
                .Where(b => b.CheckIns.Any(ci => ci.IsActive))
                .CountAsync(ct);

            // On-shelf stock condition: Product is in an ACTIVE CheckIn (direct or via Pallet) with remaining unpicked quantity
            Expression<Func<ReceivedProduct, bool>> isOnShelfStock = rp =>
                (rp.CheckIns.Any(ci => ci.IsActive) || (rp.Pallet != null && rp.Pallet.CheckIns.Any(ci => ci.IsActive))) &&
                rp.Quantity > dbContext.PickedProducts
                    .Where(pp => pp.ReceivedProductId == rp.Id)
                    .Sum(pp => (int?)pp.QuantityPicked ?? 0);

            var expiringSoonCount = await dbContext.ReceivedProducts
                .Where(rp => rp.Receiving != null && (activeWarehouseId == null || rp.Receiving.WarehouseId == activeWarehouseId))
                .Where(isOnShelfStock)
                .Where(rp => rp.ExpirationDate >= today && rp.ExpirationDate <= expiringSoonCutoff)
                .CountAsync(ct);

            var expiredCount = await dbContext.ReceivedProducts
                .Where(rp => rp.Receiving != null && (activeWarehouseId == null || rp.Receiving.WarehouseId == activeWarehouseId))
                .Where(isOnShelfStock)
                .Where(rp => rp.ExpirationDate < today)
                .CountAsync(ct);

            // 2. Today's Activity
            var todayReceivings = await dbContext.Receivings
                .Include(r => r.Products)
                .Where(r => activeWarehouseId == null || r.WarehouseId == activeWarehouseId)
                .Where(r => r.DateReceived >= todayStart && r.DateReceived < todayEnd)
                .AsNoTracking()
                .ToListAsync(ct);

            var todayReceivingCBM = todayReceivings
                .SelectMany(r => r.Products ?? Enumerable.Empty<ReceivedProduct>())
                .Sum(p => p.TotalCbm);

            var todayPickedQuantity = await dbContext.PickedProducts
                .Where(pp => pp.DatePicked >= todayStart && pp.DatePicked < todayEnd)
                .Where(pp => activeWarehouseId == null || (pp.ManualPicking != null && pp.ManualPicking.WarehouseId == activeWarehouseId))
                .SumAsync(pp => (int?)pp.QuantityPicked, ct) ?? 0;

            // 3. Recent Transactions & Expiring Products
            var recentReceivings = await dbContext.Receivings
                .Where(r => activeWarehouseId == null || r.WarehouseId == activeWarehouseId)
                .OrderByDescending(r => r.DateReceived)
                .Take(5)
                .Select(r => new RecentReceivingDto(
                    r.Id,
                    r.Series,
                    r.Warehouse!.Name,
                    r.Shipper,
                    r.DateReceived
                ))
                .AsNoTracking()
                .ToListAsync(ct);

            var expiringProductEntities = await dbContext.ReceivedProducts
                .Include(rp => rp.Product)
                .Include(rp => rp.Receiving!)
                    .ThenInclude(r => r.Warehouse)
                .Include(rp => rp.CheckIns.Where(ci => ci.IsActive))
                .Include(rp => rp.Pallet!)
                    .ThenInclude(p => p.CheckIns.Where(ci => ci.IsActive))
                .Where(rp => rp.Receiving != null && (activeWarehouseId == null || rp.Receiving.WarehouseId == activeWarehouseId))
                .Where(isOnShelfStock)
                .Where(rp => rp.ExpirationDate <= expiringSoonCutoff)
                .OrderBy(rp => rp.ExpirationDate)
                .Take(10)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync(ct);

            var expiringProductIds = expiringProductEntities.Select(rp => rp.Id).ToList();

            var expiringPickedTotals = await dbContext.PickedProducts
                .Where(pp => expiringProductIds.Contains(pp.ReceivedProductId))
                .GroupBy(pp => pp.ReceivedProductId)
                .Select(g => new { ReceivedProductId = g.Key, TotalPicked = g.Sum(pp => pp.QuantityPicked) })
                .ToDictionaryAsync(x => x.ReceivedProductId, x => x.TotalPicked, ct);

            var expiringProducts = expiringProductEntities.Select(rp =>
            {
                var qtyPicked = expiringPickedTotals.GetValueOrDefault(rp.Id, 0);
                var remainingQty = rp.Quantity - qtyPicked;

                return new ExpiringProductDto(
                    rp.Product?.Name ?? "",
                    rp.Receiving?.Series ?? "",
                    rp.ExpirationDate,
                    remainingQty,
                    rp.Receiving?.Warehouse?.Name ?? ""
                );
            }).ToList();

            // 4. Aging Inventory (Oldest received on-shelf stock, loading only ACTIVE check-in bins)
            var agingProductEntities = await dbContext.ReceivedProducts
                .Include(rp => rp.Product)
                .Include(rp => rp.Receiving!)
                    .ThenInclude(r => r.Warehouse)
                .Include(rp => rp.CheckIns.Where(ci => ci.IsActive))
                    .ThenInclude(ci => ci.Bins)
                        .ThenInclude(b => b.BinNames)
                .Include(rp => rp.Pallet!)
                    .ThenInclude(p => p.CheckIns.Where(ci => ci.IsActive))
                        .ThenInclude(ci => ci.Bins)
                            .ThenInclude(b => b.BinNames)
                .Where(rp => rp.Receiving != null && (activeWarehouseId == null || rp.Receiving.WarehouseId == activeWarehouseId))
                .Where(isOnShelfStock)
                .OrderBy(rp => rp.Receiving!.DateReceived)
                .Take(10)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync(ct);

            var agingProductIds = agingProductEntities.Select(rp => rp.Id).ToList();

            var agingPickedTotals = await dbContext.PickedProducts
                .Where(pp => agingProductIds.Contains(pp.ReceivedProductId))
                .GroupBy(pp => pp.ReceivedProductId)
                .Select(g => new { ReceivedProductId = g.Key, TotalPicked = g.Sum(pp => pp.QuantityPicked) })
                .ToDictionaryAsync(x => x.ReceivedProductId, x => x.TotalPicked, ct);

            var agingInventory = agingProductEntities
                .Select(rp =>
                {
                    // Filter explicitly for ACTIVE check-ins to prevent reading old historical placements
                    var activeCheckIns = rp.CheckIns.Where(ci => ci.IsActive)
                        .Concat(rp.Pallet?.CheckIns.Where(ci => ci.IsActive) ?? Enumerable.Empty<CheckIn>())
                        .ToList();

                    var earliestCheckIn = activeCheckIns.Count > 0
                        ? activeCheckIns.Min(ci => ci.CheckInDate)
                        : (rp.Receiving?.DateReceived ?? DateTime.Today);

                    var binNames = activeCheckIns
                        .SelectMany(ci => ci.Bins)
                        .Select(b => b.BinNames?.BinName)
                        .Where(name => !string.IsNullOrEmpty(name))
                        .Distinct();

                    var qtyPicked = agingPickedTotals.GetValueOrDefault(rp.Id, 0);

                    return new AgingInventoryDto(
                        rp.Product?.Name ?? "",
                        rp.Receiving?.Series ?? "",
                        rp.Receiving?.Warehouse?.Name ?? "",
                        string.Join(", ", binNames),
                        rp.Quantity - qtyPicked,
                        (todayStart - earliestCheckIn.Date).Days
                    );
                })
                .OrderByDescending(dto => dto.DaysInStorage)
                .ToList();

            // 5. Top Products On-Hand
            var topProductItems = await dbContext.ReceivedProducts
                .Where(rp => rp.Receiving != null && (activeWarehouseId == null || rp.Receiving.WarehouseId == activeWarehouseId))
                .Where(isOnShelfStock)
                .Select(rp => new
                {
                    ProductName = rp.Product!.Name,
                    rp.Quantity,
                    TotalPicked = dbContext.PickedProducts
                        .Where(pp => pp.ReceivedProductId == rp.Id)
                        .Sum(pp => (int?)pp.QuantityPicked ?? 0)
                })
                .AsNoTracking()
                .ToListAsync(ct);

            var topProducts = topProductItems
                .GroupBy(x => x.ProductName)
                .Select(g => new TopProductDto(
                    g.Key,
                    g.Sum(x => x.Quantity - x.TotalPicked)
                ))
                .OrderByDescending(x => x.OnHandQuantity)
                .Take(10)
                .ToList();

            // 6. 7-Day Activity Trend
            var trendStart = today.AddDays(-6);
            var trendStartDateTime = trendStart.ToDateTime(TimeOnly.MinValue);

            var receivingsForTrend = await dbContext.Receivings
                .Include(r => r.Products)
                .Where(r => activeWarehouseId == null || r.WarehouseId == activeWarehouseId)
                .Where(r => r.DateReceived >= trendStartDateTime && r.DateReceived < todayEnd)
                .AsNoTracking()
                .ToListAsync(ct);

            var pickedProductsForTrend = await dbContext.PickedProducts
                .Where(pp => pp.DatePicked >= trendStartDateTime && pp.DatePicked < todayEnd)
                .Where(pp => activeWarehouseId == null || (pp.ManualPicking != null && pp.ManualPicking.WarehouseId == activeWarehouseId))
                .AsNoTracking()
                .ToListAsync(ct);

            var receivedQuantityByDate = receivingsForTrend
                .SelectMany(r => (r.Products ?? Enumerable.Empty<ReceivedProduct>()).Select(p => new { Date = DateOnly.FromDateTime(r.DateReceived), p.Quantity }))
                .GroupBy(x => x.Date)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.Quantity));

            var pickedQuantityByDate = pickedProductsForTrend
                .GroupBy(pp => DateOnly.FromDateTime(pp.DatePicked))
                .ToDictionary(g => g.Key, g => g.Sum(pp => pp.QuantityPicked));

            var activityTrend = Enumerable.Range(0, 7)
                .Select(offset => trendStart.AddDays(offset))
                .Select(date => new DailyActivityDto(
                    date,
                    receivedQuantityByDate.GetValueOrDefault(date, 0),
                    pickedQuantityByDate.GetValueOrDefault(date, 0)
                ))
                .ToList();

            // 7. Warehouse Breakdown
            var allWarehouses = await dbContext.Warehouses.AsNoTracking().ToListAsync(ct);

            var palletCountsByWarehouse = await dbContext.Pallets
                .GroupBy(p => p.WarehouseId)
                .Select(g => new { WarehouseId = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.WarehouseId, x => x.Count, ct);

            // Supports both racked and standalone bins, checking ACTIVE check-ins for occupancy
            var binCountsByWarehouse = await dbContext.Bins
                .GroupBy(b => b.Rack != null ? b.Rack.WarehouseId : b.WarehouseId)
                .Select(g => new
                {
                    WarehouseId = g.Key,
                    Total = g.Count(),
                    Occupied = g.Count(b => b.CheckIns.Any(ci => ci.IsActive))
                })
                .ToDictionaryAsync(x => x.WarehouseId, x => x, ct);

            var pendingPalletCountsByWarehouse = await dbContext.Pallets
                .Where(p => p.ReceivedProducts != null && p.ReceivedProducts.Any())
                .Where(p => !dbContext.CheckIns.Any(ci => ci.IsActive && ci.PalletId == p.Id))
                .GroupBy(p => p.WarehouseId)
                .Select(g => new { WarehouseId = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.WarehouseId, x => x.Count, ct);

            var pendingItemCountsByWarehouse = await dbContext.ReceivedProducts
                .Where(rp => rp.PalletId == null && rp.Receiving != null && !rp.CheckIns.Any(ci => ci.IsActive))
                .GroupBy(rp => rp.Receiving!.WarehouseId)
                .Select(g => new { WarehouseId = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.WarehouseId, x => x.Count, ct);

            var warehouseBreakdown = allWarehouses.Select(w => new WarehouseBreakdownDto(
                w.Id,
                w.Name,
                palletCountsByWarehouse.GetValueOrDefault(w.Id, 0),
                binCountsByWarehouse.TryGetValue(w.Id, out var binStats) ? binStats.Total : 0,
                binCountsByWarehouse.TryGetValue(w.Id, out var binStatsOcc) ? binStatsOcc.Occupied : 0,
                pendingPalletCountsByWarehouse.GetValueOrDefault(w.Id, 0),
                pendingItemCountsByWarehouse.GetValueOrDefault(w.Id, 0)
            )).ToList();

            return Results.Ok(new DashboardSummaryDto(
                totalWarehouses,
                totalPallets,
                pendingCheckInPallets,
                pendingCheckInItems,
                totalBins,
                occupiedBins,
                expiringSoonCount,
                expiredCount,
                todayReceivings.Count,
                todayReceivingCBM ?? 0m,
                todayPickedQuantity,
                recentReceivings,
                expiringProducts,
                agingInventory,
                activityTrend,
                warehouseBreakdown,
                topProducts
            ));
        })
        .WithName("GetDashboardSummary")
        .WithSummary("Get dashboard summary statistics")
        .Produces<DashboardSummaryDto>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status500InternalServerError);

        return group;
    }
}