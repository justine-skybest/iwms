using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;

namespace WMS.Api.Endpoints;

public record InventoryCheckItemDto(
    int ReceivedProductId,
    string ProductName,
    string? TypeOfPackage,
    string? Measurement,
    decimal Weight,
    int Quantity,
    string? CBM,
    decimal TotalWeight,
    DateOnly? ExpirationDate,
    string? ReceivingSeries,
    string? Remarks,
    bool IsPalletized,
    int? PalletNumber
);

public record InventoryInspectionResultDto(
    bool Found,
    string? InspectionType, // "Pallet" or "Bin"
    int? EntityId,
    string Title,
    string WarehouseName,
    string? BinLocation,
    string? Rack,
    string? Bay,
    string? Level,
    List<InventoryCheckItemDto> Items,
    string? ErrorMessage
);

public static class InventoryEndpoint
{
    public static RouteGroupBuilder MapInventoryEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("inventory").WithTags("Inventory");

        group.MapGet("/inspect/{code}/{warehouseId:int}", async (string code, int warehouseId, WMSContext dbContext) =>
        {
            var trimmedCode = code.Trim();
            if (string.IsNullOrWhiteSpace(trimmedCode) || warehouseId <= 0)
            {
                return Results.Ok(new InventoryInspectionResultDto(false, null, null, "", "", null, null, null, null, [], "Invalid search code or warehouse ID."));
            }

            int.TryParse(trimmedCode, out var numericCode);

            // -----------------------------------------------------------------
            // 1. TRY DETECTING AS PALLET (By HashCode or PalletNumber)
            // -----------------------------------------------------------------
            var pallet = await dbContext.Pallets
                .Include(p => p.Warehouse)
                .Include(p => p.ReceivedProducts!)
                    .ThenInclude(rp => rp.Product)
                .Include(p => p.ReceivedProducts!)
                    .ThenInclude(rp => rp.Receiving)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.WarehouseId == warehouseId &&
                    (p.PalletHashCode == numericCode || p.PalletNumber == numericCode));

            if (pallet is not null)
            {
                // Retrieve check-in location for this pallet
                var checkIn = await dbContext.CheckIns
                    .Include(ci => ci.Bins)
                        .ThenInclude(b => b.Rack)
                    .Include(ci => ci.Bins)
                        .ThenInclude(b => b.Bay)
                    .Include(ci => ci.Bins)
                        .ThenInclude(b => b.Level)
                    .Include(ci => ci.Bins)
                        .ThenInclude(b => b.BinNames)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(ci => ci.PalletId == pallet.Id);

                var bin = checkIn?.Bins.FirstOrDefault();

                var palletItems = (pallet.ReceivedProducts ?? []).Select(rp => new InventoryCheckItemDto(
                    rp.Id,
                    rp.Product?.Name ?? "Unknown",
                    rp.Product?.TypeOfPackage,
                    rp.Product?.Measurement,
                    rp.Product?.Weight ?? 0,
                    rp.Quantity,
                    rp.CBM,
                    (rp.Product?.Weight ?? 0) * rp.Quantity,
                    rp.ExpirationDate,
                    rp.Receiving?.Series,
                    rp.Remarks,
                    true,
                    pallet.PalletNumber
                )).ToList();

                return Results.Ok(new InventoryInspectionResultDto(
                    Found: true,
                    InspectionType: "Pallet",
                    EntityId: pallet.Id,
                    Title: $"Pallet #{pallet.PalletNumber}",
                    WarehouseName: pallet.Warehouse?.Name ?? "N/A",
                    BinLocation: bin?.BinNames?.BinName ?? "Not Checked In",
                    Rack: bin?.Rack?.Name,
                    Bay: bin?.Bay?.BayNumber.ToString(),
                    Level: bin?.Level?.LevelNumber.ToString(),
                    Items: palletItems,
                    ErrorMessage: null
                ));
            }

            // -----------------------------------------------------------------
            // 2. TRY DETECTING AS BIN (By HashCode, Bin ID, or Bin Name)
            // -----------------------------------------------------------------
            var binEntity = await dbContext.Bins
                .Include(b => b.Rack)
                    .ThenInclude(r => r!.Warehouse)
                .Include(b => b.Bay)
                .Include(b => b.Level)
                .Include(b => b.BinNames)
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Rack!.WarehouseId == warehouseId &&
                    (b.BinHashCode == numericCode || b.Id == numericCode || b.BinNames!.BinName == trimmedCode));

            if (binEntity is not null)
            {
                // Find all check-ins targeting this bin (both palletized and loose item check-ins)
                var checkIns = await dbContext.CheckIns
                    .Include(ci => ci.Pallet)
                    .Include(ci => ci.ReceivedProducts)
                        .ThenInclude(rp => rp.Product)
                    .Include(ci => ci.ReceivedProducts)
                        .ThenInclude(rp => rp.Receiving)
                    .Where(ci => ci.Bins.Any(b => b.Id == binEntity.Id))
                    .AsNoTracking()
                    .ToListAsync();

                var binItems = checkIns.SelectMany(ci => ci.ReceivedProducts.Select(rp => new InventoryCheckItemDto(
                    rp.Id,
                    rp.Product?.Name ?? "Unknown",
                    rp.Product?.TypeOfPackage,
                    rp.Product?.Measurement,
                    rp.Product?.Weight ?? 0,
                    rp.Quantity,
                    rp.CBM,
                    (rp.Product?.Weight ?? 0) * rp.Quantity,
                    rp.ExpirationDate,
                    rp.Receiving?.Series,
                    rp.Remarks,
                    ci.PalletId.HasValue,
                    ci.Pallet?.PalletNumber
                ))).ToList();

                return Results.Ok(new InventoryInspectionResultDto(
                    Found: true,
                    InspectionType: "Bin",
                    EntityId: binEntity.Id,
                    Title: $"Bin: {binEntity.BinNames?.BinName ?? binEntity.Id.ToString()}",
                    WarehouseName: binEntity.Rack?.Warehouse?.Name ?? "N/A",
                    BinLocation: binEntity.BinNames?.BinName,
                    Rack: binEntity.Rack?.Name,
                    Bay: binEntity.Bay?.BayNumber.ToString(),
                    Level: binEntity.Level?.LevelNumber.ToString(),
                    Items: binItems,
                    ErrorMessage: null
                ));
            }

            return Results.Ok(new InventoryInspectionResultDto(false, null, null, "", "", null, null, null, null, [], $"No Pallet or Bin found matching '{trimmedCode}'."));
        })
        .WithName("InspectInventoryCode")
        .WithSummary("Inspect inventory contents by scanning a Pallet or Bin QR code")
        .WithDescription("Unified inventory inspector. Resolves Pallets or Bins and returns all items stored inside.")
        .Produces<InventoryInspectionResultDto>(StatusCodes.Status200OK);

        return group;
    }
}