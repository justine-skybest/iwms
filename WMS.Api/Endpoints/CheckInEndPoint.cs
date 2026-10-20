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
        // GET / (v1) - Optional isActive filter
        // -----------------------------------------------------------------------------
        group.MapGet("/", async (WMSContext dbContext, bool? isActive = null) =>
        {
            var query = dbContext.CheckIns
                .Include(checkedin => checkedin.Bins)
                .Include(checkedin => checkedin.Pallet)
                .AsNoTracking();

            if (isActive.HasValue)
            {
                query = query.Where(ci => ci.IsActive == isActive.Value);
            }

            return await query
                .OrderByDescending(ci => ci.CheckInDate)
                .Select(checkedin => checkedin.ToCheckInSummaryDto())
                .ToListAsync();
        });

        // -----------------------------------------------------------------------------
        // GET /v2?search=&warehouseId=&isActive=&page=&pageSize=
        // -----------------------------------------------------------------------------
        group.MapGet("/v2", async (
            WMSContext dbContext,
            string? search = null,
            int? warehouseId = null,
            bool? isActive = null,
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
                .Include(ci => ci.Bins)
                    .ThenInclude(bin => bin.Warehouse)
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

            if (isActive.HasValue)
            {
                query = query.Where(ci => ci.IsActive == isActive.Value);
            }

            if (warehouseId.HasValue)
            {
                query = query.Where(ci =>
                    (ci.Pallet != null && ci.Pallet.WarehouseId == warehouseId.Value) ||
                    ci.Bins.Any(b =>
                        b.WarehouseId == warehouseId.Value ||
                        (b.Rack != null && b.Rack.WarehouseId == warehouseId.Value)));
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
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
        // GET /Bin/{id} (v1) - Filters active inventory by default & includes pallet items
        // -----------------------------------------------------------------------------
        group.MapGet("/Bin/{id:int}", async (
            int id,
            WMSContext dbContext,
            bool activeOnly = true,
            CancellationToken ct = default) =>
        {
            var query = dbContext.CheckIns
                .Where(ci => ci.Bins.Any(b => b.Id == id));

            if (activeOnly)
            {
                query = query.Where(ci => ci.IsActive);
            }

            return await query
                .Include(ci => ci.Pallet)
                    .ThenInclude(p => p!.ReceivedProducts)
                        .ThenInclude(rp => rp.Product)
                .Include(ci => ci.ReceivedProducts)
                    .ThenInclude(rp => rp.Product)
                .AsNoTracking()
                .Select(ci => ci.ToDisplayCheckinProductsDto())
                .ToListAsync(ct);
        });

        // -----------------------------------------------------------------------------
        // GET /v2/Bin/{id}?search=&activeOnly=&page=&pageSize=
        // -----------------------------------------------------------------------------
        group.MapGet("/v2/Bin/{id:int}", async (
            int id,
            WMSContext dbContext,
            string? search = null,
            bool activeOnly = true,
            int page = 1,
            int pageSize = 50,
            CancellationToken cancellationToken = default) =>
        {
            const int maxPageSize = 500;
            page = Math.Max(page, 1);
            pageSize = Math.Clamp(pageSize, 1, maxPageSize);

            var query = dbContext.CheckIns
                .Where(ci => ci.Bins.Any(b => b.Id == id));

            if (activeOnly)
            {
                query = query.Where(ci => ci.IsActive);
            }

            query = query
                .Include(ci => ci.Pallet)
                    .ThenInclude(p => p!.ReceivedProducts)
                        .ThenInclude(rp => rp.Product)
                .Include(ci => ci.ReceivedProducts)
                    .ThenInclude(rp => rp.Product)
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(ci =>
                    (ci.Pallet != null && ci.Pallet.PalletNumber.ToString().Contains(search)) ||
                    ci.ReceivedProducts.Any(rp => rp.Product != null && rp.Product.Name.Contains(search)) ||
                    (ci.Pallet != null && ci.Pallet.ReceivedProducts.Any(rp => rp.Product != null && rp.Product.Name.Contains(search))));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderByDescending(ci => ci.CheckInDate)
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
        // GET /{id} - Fully hydrated single lookup
        // -----------------------------------------------------------------------------
        group.MapGet("/{id:int}", async (int id, WMSContext dbContext, CancellationToken ct) =>
        {
            var checkIn = await dbContext.CheckIns
                .Include(ci => ci.Bins)
                    .ThenInclude(b => b.Rack)
                        .ThenInclude(r => r!.Warehouse)
                .Include(ci => ci.Bins)
                    .ThenInclude(b => b.BinNames)
                .Include(ci => ci.Pallet)
                    .ThenInclude(p => p!.ReceivedProducts)
                        .ThenInclude(rp => rp.Product)
                .Include(ci => ci.ReceivedProducts)
                    .ThenInclude(rp => rp.Product)
                .AsNoTracking()
                .FirstOrDefaultAsync(ci => ci.Id == id, ct);

            return checkIn is null
                ? Results.NotFound($"CheckIn with ID #{id} not found.")
                : Results.Ok(checkIn.ToCheckInDetailsDto());
        })
        .WithName(GetCheckInEndpoint)
        .Produces<CheckInDetailsDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        // -----------------------------------------------------------------------------
        // POST / - Check-In Creation with Pallet Placement Synchronization
        // -----------------------------------------------------------------------------
        group.MapPost("/", async (
            CreateCheckInDto newCheckIn,
            WMSContext dbContext,
            IAuditLogService auditLogService,
            CancellationToken ct) =>
        {
            var bins = await dbContext.Bins
                .Where(b => newCheckIn.BinIds.Contains(b.Id))
                .Include(b => b.BinNames)
                .Include(b => b.Level)
                .Include(b => b.Bay)
                .Include(b => b.Rack)
                    .ThenInclude(r => r!.Warehouse)
                .Include(b => b.Warehouse)
                .ToListAsync(ct);

            if (bins.Count != newCheckIn.BinIds.Count)
            {
                return Results.BadRequest("One or more BinIds are invalid.");
            }

            var receivedProducts = await dbContext.ReceivedProducts
                .Include(rp => rp.Product)
                .Where(rp => (newCheckIn.ReceivedProductIds != null && newCheckIn.ReceivedProductIds.Contains(rp.Id)) ||
                             (newCheckIn.PalletId != null && rp.PalletId == newCheckIn.PalletId))
                .ToListAsync(ct);

            if (newCheckIn.PalletId is null && receivedProducts.Count != (newCheckIn.ReceivedProductIds?.Count ?? 0))
            {
                return Results.BadRequest("One or more ReceivedProductIds are invalid.");
            }

            // If this pallet is currently active in another bin, deactivate the previous placement
            if (newCheckIn.PalletId.HasValue)
            {
                var previousActiveCheckIns = await dbContext.CheckIns
                    .Where(ci => ci.PalletId == newCheckIn.PalletId.Value && ci.IsActive)
                    .ToListAsync(ct);

                foreach (var prev in previousActiveCheckIns)
                {
                    prev.IsActive = false;
                    prev.CheckOutDate = DateTime.UtcNow;
                    prev.Notes = string.IsNullOrWhiteSpace(prev.Notes)
                        ? "Deactivated: Pallet relocated to new bin placement."
                        : $"{prev.Notes} | Deactivated: Pallet relocated.";
                }
            }

            CheckIn checkIn = newCheckIn.ToEntity(bins, receivedProducts);
            checkIn.IsActive = true;
            checkIn.CheckInDate = DateTime.UtcNow;

            dbContext.CheckIns.Add(checkIn);
            await dbContext.SaveChangesAsync(ct);

            // Audit logging
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
                    checkIn.IsActive,
                    TargetBins = bins.Select(b => new
                    {
                        BinLocation = b.Rack is null
                            ? $"Standalone / {b.BinNames?.BinName ?? $"Bin #{b.Id}"}"
                            : $"{b.Rack.Name} / Bay {b.Bay?.BayNumber.ToString() ?? "N/A"} / Level {b.Level?.LevelNumber.ToString() ?? "N/A"} / {b.BinNames?.BinName ?? "Unassigned"}"
                    }).ToList(),
                    TotalItemsCheckedIn = receivedProducts.Count,
                    checkIn.CheckInDate,
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
        })
        .WithName("CreateCheckIn")
        .Produces<CheckInDetailsDto>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest);

        // -----------------------------------------------------------------------------
        // POST /{id}/checkout - Manual Check-Out / Deactivation Endpoint
        // -----------------------------------------------------------------------------
        group.MapPost("/{id:int}/checkout", async (
            int id,
            WMSContext dbContext,
            IAuditLogService auditLogService,
            CancellationToken ct) =>
        {
            var checkIn = await dbContext.CheckIns.FindAsync(new object[] { id }, ct);
            if (checkIn is null) return Results.NotFound();

            if (!checkIn.IsActive)
            {
                return Results.BadRequest(new { Message = $"Check-in #{id} is already checked out/inactive." });
            }

            checkIn.IsActive = false;
            checkIn.CheckOutDate = DateTime.UtcNow;
            await dbContext.SaveChangesAsync(ct);

            await auditLogService.LogAsync(
                category: nameof(CheckIn),
                action: "CheckedOut",
                description: $"Manually checked out CheckIn ID {id}.",
                details: new { CheckInId = id, checkIn.CheckOutDate }
            );

            return Results.Ok(new { Message = $"Check-in #{id} successfully checked out.", CheckInId = id });
        })
        .WithName("CheckoutCheckIn")
        .WithSummary("Manually deactivates a check-in to release its pallet/bins")
        .Produces(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status404NotFound);

        return group;
    }
}