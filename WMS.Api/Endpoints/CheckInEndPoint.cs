using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Dtos;
using WMS.Api.Dtos.CheckIn;
using WMS.Api.Entities;
using WMS.Api.Mapping;
using WMS.Api.Services;

namespace WMS.Api.Endpoints;

public static class CheckInEndPoint
{
    const string GetCheckInEndpoint = "GetCheckIn";

    public static RouteGroupBuilder MapCheckInEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("checkin").WithParameterValidation();

        // -----------------------------------------------------------------------------
        // GET / (v1)
        // -----------------------------------------------------------------------------
        group.MapGet("/", async (WMSContext dbContext) =>
                await dbContext.CheckIns
                        .Include(checkedin => checkedin.Bins)
                        .Include(checkedin => checkedin.Pallet)
                        .Select(checkedin => checkedin.ToCheckInSummaryDto())
                        .AsNoTracking()
                        .ToListAsync()
        );

        // -----------------------------------------------------------------------------
        // GET /v2?search=&page=&pageSize=
        // -----------------------------------------------------------------------------
        group.MapGet("/v2", async (
            WMSContext dbContext,
            string? search = null,
            int? warehouseId = null,
            int page = 1,
            int pageSize = 50,
            CancellationToken cancellationToken = default) =>
        {
            const int maxPageSize = 500;
            page = Math.Max(page, 1);
            pageSize = Math.Clamp(pageSize, 1, maxPageSize);

            var query = dbContext.CheckIns
                .Include(ci => ci.Bins)
                    .ThenInclude(bin => bin.Rack!)
                        .ThenInclude(rack => rack!.Warehouse)
                .Include(ci => ci.Bins)
                    .ThenInclude(bin => bin.Bay)
                .Include(ci => ci.Bins)
                    .ThenInclude(bin => bin.Level)
                .Include(ci => ci.Bins)
                    .ThenInclude(bin => bin.BinNames)
                .Include(ci => ci.Pallet)
                    .ThenInclude(pallet => pallet!.Warehouse)
                .Include(ci => ci.Pallet)
                    .ThenInclude(pallet => pallet!.ReceivedProducts)
                        .ThenInclude(rp => rp!.Product)
                .Include(ci => ci.ReceivedProducts)
                    .ThenInclude(rp => rp.Product)
                .Include(ci => ci.ReceivedProducts)
                    .ThenInclude(rp => rp.Pallet)
                .AsNoTracking();

            if (warehouseId.HasValue)
            {
                query = query.Where(ci =>
                    (ci.Pallet != null && ci.Pallet.WarehouseId == warehouseId.Value) ||
                    ci.Bins.Any(b => b.Rack!.WarehouseId == warehouseId.Value));
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                // NOTE: assumes pallet number and the pallet's warehouse name
                // are the meaningful search targets, matching the "Pallet" /
                // "Warehouse" columns shown on the check-ins dashboard table.
                query = query.Where(ci =>
                    ci.Pallet != null && (
                        ci.Pallet.PalletNumber.ToString().Contains(search) ||
                        (ci.Pallet.Warehouse != null && ci.Pallet.Warehouse.Name.Contains(search))));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderByDescending(ci => ci.CheckInDate)
                .ThenByDescending(ci => ci.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(ci => ci.ToCheckInSummaryDto())
                .ToListAsync(cancellationToken);

            var response = new PaginatedResponse<CheckInSummaryDto>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return Results.Ok(response);
        })
        .Produces<PaginatedResponse<CheckInSummaryDto>>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // GET /Bin/{id} (v1)
        // -----------------------------------------------------------------------------
        group.MapGet("/Bin/{id}", async (WMSContext dbContext, int id) =>
            await dbContext.CheckIns
                .Where(ci => ci.Bins.Any(b => b.Id == id))
                .Include(ci => ci.Pallet)
                .Include(ci => ci.ReceivedProducts)
                    .ThenInclude(rp => rp.Product)
                .AsNoTracking()
                .Select(ci => ci.ToDisplayCheckinProductsDto())
                .ToListAsync()
        );

        // -----------------------------------------------------------------------------
        // GET /v2/Bin/{id}?search=&page=&pageSize=
        // -----------------------------------------------------------------------------
        group.MapGet("/v2/Bin/{id}", async (
            int id,
            WMSContext dbContext,
            string? search = null,
            int page = 1,
            int pageSize = 50,
            CancellationToken cancellationToken = default) =>
        {
            const int maxPageSize = 500;
            page = Math.Max(page, 1);
            pageSize = Math.Clamp(pageSize, 1, maxPageSize);

            var query = dbContext.CheckIns
                .Where(ci => ci.Bins.Any(b => b.Id == id))
                .Include(ci => ci.Pallet)
                .Include(ci => ci.ReceivedProducts)
                    .ThenInclude(rp => rp.Product)
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                // Already scoped to one bin, so search matches pallet number
                // or any received product's name.
                query = query.Where(ci =>
                    (ci.Pallet != null && ci.Pallet.PalletNumber.ToString().Contains(search)) ||
                    ci.ReceivedProducts.Any(rp => rp.Product != null && rp.Product.Name.Contains(search)));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(ci => ci.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(ci => ci.ToDisplayCheckinProductsDto())
                .ToListAsync(cancellationToken);

            var response = new PaginatedResponse<DisplayCheckInProductsDto>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return Results.Ok(response);
        })
        .Produces<PaginatedResponse<DisplayCheckInProductsDto>>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // Single Item & Mutation Endpoints
        // -----------------------------------------------------------------------------
        group.MapGet("/{id}", async (int id, WMSContext dbContext) => {
            CheckIn? checkIn = await dbContext.CheckIns.FindAsync(id);

            return checkIn is null ? Results.NotFound() : Results.Ok(checkIn.ToCheckInDetailsDto());
        }).WithName(GetCheckInEndpoint);

        group.MapPost("/", async (
                    CreateCheckInDto newCheckIn,
                    WMSContext dbContext,
                    IAuditLogService auditLogService) =>
        {
            var bins = await dbContext.Bins
                .Where(b => newCheckIn.BinIds.Contains(b.Id))
                .Include(b => b.BinNames)
                .Include(b => b.Level)
                .Include(b => b.Bay)
                .Include(b => b.Rack)
                    .ThenInclude(r => r!.Warehouse)
                .ToListAsync();

            if (bins.Count != newCheckIn.BinIds.Count)
            {
                return Results.BadRequest("One or more BinIds are invalid.");
            }

            var receivedProducts = await dbContext.ReceivedProducts
                    .Include(rp => rp.Product)
                    .Where(rp => newCheckIn.ReceivedProductIds!.Contains(rp.Id) || newCheckIn.PalletId == rp.PalletId)
                    .ToListAsync();

            if (newCheckIn.PalletId is null && receivedProducts.Count != newCheckIn.ReceivedProductIds!.Count)
            {
                return Results.BadRequest("One or more ReceivedProductIds are invalid.");
            }

            CheckIn checkIn = newCheckIn.ToEntity(bins, receivedProducts);
            dbContext.CheckIns.Add(checkIn);
            await dbContext.SaveChangesAsync();

            // --- ADD AUDIT LOG ENTRY ---
            string binList = string.Join(", ", bins.Select(b => b.Id));
            string typeDesc = newCheckIn.PalletId.HasValue ? $"Pallet ID {newCheckIn.PalletId}" : $"{receivedProducts.Count} individual item(s)";

            await auditLogService.LogAsync(
                category: nameof(CheckIn),
                action: "Created",
                description: $"Checked in {typeDesc} to Bin(s) [{binList}] via '{newCheckIn.CheckInType}' process.",
                details: new
                {
                    CheckInId = checkIn.Id,
                    newCheckIn.CheckInType,
                    PalletId = newCheckIn.PalletId ?? 0,
                    TargetBins = bins.Select(b => new
                    {
                        BinLocation = $"{b.Rack!.Name} / Bay {b.Bay!.BayNumber} / Level {b.Level!.LevelNumber} / {b.BinNames!.BinName}"
                    }).ToList(),
                    TotalItemsCheckedIn = receivedProducts.Count,
                    newCheckIn.CheckInDate,
                    Notes = string.IsNullOrWhiteSpace(newCheckIn.Notes) ? "—" : newCheckIn.Notes,
                    Items = receivedProducts.Select(rp => new
                    {
                        rp.Id,
                        ProductName = rp.Product?.Name ?? $"Product #{rp.ProductId}",
                        rp.Quantity,
                        rp.LotNumber
                    })
                }
            );

            return Results.CreatedAtRoute(GetCheckInEndpoint, new { id = checkIn.Id }, checkIn.ToCheckInDetailsDto());
        });

        return group;
    }
}