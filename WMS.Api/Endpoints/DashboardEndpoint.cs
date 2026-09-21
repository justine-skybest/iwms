using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Dtos.Dashboard;
using WMS.Api.Entities;

namespace WMS.Api.Endpoints;

public static class DashboardEndpoint
{
    public static RouteGroupBuilder MapDashboardEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("dashboard");

        group.MapGet("/summary", async (int? warehouseId, WMSContext dbContext) =>
        {
            int? activeWarehouseId = (warehouseId.HasValue && warehouseId.Value > 0) ? warehouseId : null;

            var today = DateOnly.FromDateTime(DateTime.Now);
            var expiringSoonCutoff = today.AddDays(30);
            var todayStart = DateTime.Today;
            var todayEnd = todayStart.AddDays(1);

            // 1. Core Summary Counts
            var totalWarehouses = await dbContext.Warehouses.CountAsync();

            var totalPallets = await dbContext.Pallets
                .Where(p => activeWarehouseId == null || p.WarehouseId == activeWarehouseId)
                .CountAsync();

            var pendingCheckInPallets = await dbContext.Pallets
                .Where(p => activeWarehouseId == null || p.WarehouseId == activeWarehouseId)
                .Where(p => p.ReceivedProducts != null && p.ReceivedProducts.Any())
                .Where(p => !dbContext.CheckIns.Any(ci => ci.PalletId == p.Id))
                .CountAsync();

            var pendingCheckInItems = await dbContext.ReceivedProducts
                .Where(rp => rp.PalletId == null)
                .Where(rp => rp.Receiving != null && (activeWarehouseId == null || rp.Receiving.WarehouseId == activeWarehouseId))
                .Where(rp => !rp.CheckIns.Any())
                .CountAsync();

            var totalBins = await dbContext.Bins
                .Where(b => activeWarehouseId == null || b.Rack!.WarehouseId == activeWarehouseId)
                .CountAsync();

            var occupiedBins = await dbContext.Bins
                .Where(b => activeWarehouseId == null || b.Rack!.WarehouseId == activeWarehouseId)
                .Where(b => b.CheckIns.Any())
                .CountAsync();

            // On-shelf stock condition
            Expression<Func<ReceivedProduct, bool>> isOnShelfStock = rp =>
                rp.CheckIns.Any() &&
                rp.Quantity > dbContext.PickedProducts
                    .Where(pp => pp.ReceivedProductId == rp.Id)
                    .Sum(pp => (int?)pp.QuantityPicked ?? 0);

            var expiringSoonCount = await dbContext.ReceivedProducts
                .Where(rp => rp.Receiving != null && (activeWarehouseId == null || rp.Receiving.WarehouseId == activeWarehouseId))
                .Where(isOnShelfStock)
                .Where(rp => rp.ExpirationDate >= today && rp.ExpirationDate <= expiringSoonCutoff)
                .CountAsync();

            var expiredCount = await dbContext.ReceivedProducts
                .Where(rp => rp.Receiving != null && (activeWarehouseId == null || rp.Receiving.WarehouseId == activeWarehouseId))
                .Where(isOnShelfStock)
                .Where(rp => rp.ExpirationDate < today)
                .CountAsync();

            // 2. Today's Activity
            var todayReceivings = await dbContext.Receivings
                .Include(r => r.Products)
                .Where(r => activeWarehouseId == null || r.WarehouseId == activeWarehouseId)
                .Where(r => r.DateReceived >= todayStart && r.DateReceived < todayEnd)
                .AsNoTracking()
                .ToListAsync();

            var todayReceivingCBM = todayReceivings
                .SelectMany(r => r.Products)
                .Sum(p => decimal.TryParse(p.CBM, out var cbm) ? cbm : 0);

            var todayPickedQuantity = await dbContext.PickedProducts
                .Where(pp => pp.DatePicked >= todayStart && pp.DatePicked < todayEnd)
                .SumAsync(pp => (int?)pp.QuantityPicked) ?? 0;

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
                .ToListAsync();

            var expiringProducts = await dbContext.ReceivedProducts
                .Where(rp => rp.Receiving != null && (activeWarehouseId == null || rp.Receiving.WarehouseId == activeWarehouseId))
                .Where(isOnShelfStock)
                .Where(rp => rp.ExpirationDate <= expiringSoonCutoff)
                .OrderBy(rp => rp.ExpirationDate)
                .Take(10)
                .Select(rp => new ExpiringProductDto(
                    rp.Product!.Name,
                    rp.Receiving!.Series,
                    rp.ExpirationDate,
                    rp.Quantity,
                    rp.Receiving.Warehouse!.Name
                ))
                .AsNoTracking()
                .ToListAsync();

            // 4. Aging Inventory (MySQL compatible via Split Query)
            var agingProductEntities = await dbContext.ReceivedProducts
                .Include(rp => rp.Product)
                .Include(rp => rp.Receiving!)
                    .ThenInclude(r => r.Warehouse)
                .Include(rp => rp.CheckIns)
                    .ThenInclude(ci => ci.Bins)
                        .ThenInclude(b => b.BinNames)
                .Where(rp => rp.Receiving != null && (activeWarehouseId == null || rp.Receiving.WarehouseId == activeWarehouseId))
                .Where(isOnShelfStock)
                .OrderBy(rp => rp.CheckIns.Min(ci => ci.CheckInDate))
                .Take(10)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();

            var agingProductIds = agingProductEntities.Select(rp => rp.Id).ToList();

            var agingPickedTotals = await dbContext.PickedProducts
                .Where(pp => agingProductIds.Contains(pp.ReceivedProductId))
                .GroupBy(pp => pp.ReceivedProductId)
                .Select(g => new { ReceivedProductId = g.Key, TotalPicked = g.Sum(pp => pp.QuantityPicked) })
                .ToDictionaryAsync(x => x.ReceivedProductId, x => x.TotalPicked);

            var agingInventory = agingProductEntities.Select(rp =>
            {
                var earliestCheckIn = rp.CheckIns.Min(ci => ci.CheckInDate);
                var binNames = rp.CheckIns
                    .SelectMany(ci => ci.Bins)
                    .Select(b => b.BinNames?.BinName)
                    .Where(name => !string.IsNullOrEmpty(name))
                    .Distinct();

                var qtyPicked = agingPickedTotals.GetValueOrDefault(rp.Id, 0);

                return new AgingInventoryDto(
                    rp.Product!.Name,
                    rp.Receiving!.Series,
                    rp.Receiving.Warehouse!.Name,
                    string.Join(", ", binNames),
                    rp.Quantity - qtyPicked,
                    (todayStart - earliestCheckIn.Date).Days
                );
            }).ToList();

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
                .ToListAsync();

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
                .ToListAsync();

            var pickedProductsForTrend = await dbContext.PickedProducts
                .Where(pp => pp.DatePicked >= trendStartDateTime && pp.DatePicked < todayEnd)
                .Where(pp => activeWarehouseId == null || (pp.ManualPicking != null && pp.ManualPicking.WarehouseId == activeWarehouseId))
                .AsNoTracking()
                .ToListAsync();

            var receivedQuantityByDate = receivingsForTrend
                .SelectMany(r => r.Products.Select(p => new { Date = DateOnly.FromDateTime(r.DateReceived), p.Quantity }))
                .GroupBy(x => x.Date)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.Quantity));

            var pickedQuantityByDate = pickedProductsForTrend
                .GroupBy(pp => DateOnly.FromDateTime(pp.DatePicked))
                .ToDictionary(g => g.Key, g => g.Sum(pp => pp.QuantityPicked));

            var activityTrend = Enumerable.Range(0, 7)
                .Select(offset => trendStart.AddDays(offset))
                .Select(date => new DailyActivityDto(
                    date,
                    receivedQuantityByDate.GetValueOrDefault(date),
                    pickedQuantityByDate.GetValueOrDefault(date)
                ))
                .ToList();

            // 7. Warehouse Breakdown
            var allWarehouses = await dbContext.Warehouses.AsNoTracking().ToListAsync();

            var palletCountsByWarehouse = await dbContext.Pallets
                .GroupBy(p => p.WarehouseId)
                .Select(g => new { WarehouseId = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.WarehouseId, x => x.Count);

            var binCountsByWarehouse = await dbContext.Bins
                .Where(b => b.Rack != null)
                .GroupBy(b => b.Rack!.WarehouseId)
                .Select(g => new { WarehouseId = g.Key, Total = g.Count(), Occupied = g.Count(b => b.CheckIns.Any()) })
                .ToDictionaryAsync(x => x.WarehouseId, x => x);

            var pendingPalletCountsByWarehouse = await dbContext.Pallets
                .Where(p => p.ReceivedProducts != null && p.ReceivedProducts.Any())
                .Where(p => !dbContext.CheckIns.Any(ci => ci.PalletId == p.Id))
                .GroupBy(p => p.WarehouseId)
                .Select(g => new { WarehouseId = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.WarehouseId, x => x.Count);

            var pendingItemCountsByWarehouse = await dbContext.ReceivedProducts
                .Where(rp => rp.PalletId == null && rp.Receiving != null && !rp.CheckIns.Any())
                .GroupBy(rp => rp.Receiving!.WarehouseId)
                .Select(g => new { WarehouseId = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.WarehouseId, x => x.Count);

            var warehouseBreakdown = allWarehouses.Select(w => new WarehouseBreakdownDto(
                w.Id,
                w.Name,
                palletCountsByWarehouse.GetValueOrDefault(w.Id),
                binCountsByWarehouse.TryGetValue(w.Id, out var binStats) ? binStats.Total : 0,
                binCountsByWarehouse.TryGetValue(w.Id, out var binStatsOcc) ? binStatsOcc.Occupied : 0,
                pendingPalletCountsByWarehouse.GetValueOrDefault(w.Id),
                pendingItemCountsByWarehouse.GetValueOrDefault(w.Id)
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
                todayReceivingCBM,
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
        .WithDescription("Retrieves aggregated metrics, inventory health, activity trends, and warehouse breakdown for the dashboard.")
        .Produces<DashboardSummaryDto>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status500InternalServerError);

        return group;
    }
}