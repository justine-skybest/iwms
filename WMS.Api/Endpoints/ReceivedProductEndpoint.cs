using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Dtos;
using WMS.Api.Dtos.Receiving;
using WMS.Api.Mapping;

namespace WMS.Api.Endpoints;

public static class ReceivedProductEndpoint
{
    const string GetReceivedProductEndpoint = "GetReceivedProduct";

    public static RouteGroupBuilder MapReceivedProductEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("receivedProduct").WithParameterValidation();

        // -----------------------------------------------------------------------------
        // GET /ToCheckInProducts/{WarehouseId} (v1 & v2)
        // -----------------------------------------------------------------------------
        group.MapGet("/ToCheckInProducts/{WarehouseId:int}", async (int WarehouseId, WMSContext dbContext) =>
        {
            // Step 1: Find all ReceivedProductIds that were already checked in
            var checkedInReceivedProductIds = await dbContext.CheckIns
                .SelectMany(ci => ci.ReceivedProducts) // Access the ReceivedProducts navigation
                .Select(rp => rp.Id)
                .ToListAsync();

            // Step 2: Find all unpalletized ReceivedProducts not yet checked in
            var unpalletizedAndNotCheckedIn = await dbContext.ReceivedProducts
                .Include(rp => rp.Product)
                .Include(rp => rp.Receiving)
                .Where(rp => rp.PalletId == null) // Not palletized
                .Where(rp => rp.Receiving != null && rp.Receiving.WarehouseId == WarehouseId) // Correct warehouse
                .Where(rp => !checkedInReceivedProductIds.Contains(rp.Id)) // Not checked-in
                .Select(rp => rp.ToReceivedProductDTO()) // Map to DTO
                .AsNoTracking()
                .ToListAsync();

            return unpalletizedAndNotCheckedIn;
        });

        group.MapGet("/v2/ToCheckInProducts/{WarehouseId:int}", async (
            int WarehouseId,
            WMSContext dbContext,
            int page = 1,
            int pageSize = 50,
            CancellationToken cancellationToken = default) =>
        {
            const int maxPageSize = 500;
            page = Math.Max(page, 1);
            pageSize = Math.Clamp(pageSize, 1, maxPageSize);

            // Query unpalletized & not-yet-checked-in items at database level
            var checkedInReceivedProductIds = dbContext.CheckIns
                .SelectMany(ci => ci.ReceivedProducts)
                .Select(rp => rp.Id);

            var query = dbContext.ReceivedProducts
                .Include(rp => rp.Product)
                .Include(rp => rp.Receiving)
                .Where(rp => rp.PalletId == null)
                .Where(rp => rp.Receiving != null && rp.Receiving.WarehouseId == WarehouseId)
                .Where(rp => !checkedInReceivedProductIds.Contains(rp.Id))
                .AsNoTracking();

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(rp => rp.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(rp => rp.ToReceivedProductDTO())
                .ToListAsync(cancellationToken);

            var response = new PaginatedResponse<ToCheckInProducts>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return Results.Ok(response);
        })
        .Produces<PaginatedResponse<ToCheckInProducts>>(StatusCodes.Status200OK);

        return group;
    }
}