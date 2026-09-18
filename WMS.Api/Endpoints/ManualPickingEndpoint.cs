using System;
using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Dtos;
using WMS.Api.Dtos.ManualPicking;
using WMS.Api.Entities;
using WMS.Api.Mapping;

namespace WMS.Api.Endpoints;

public static class PickingEndpoint
{
    const string GetManualPickingEndpointName = "GetPick";

    public static RouteGroupBuilder MapManualPickingEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("manualpicking").WithParameterValidation();

        // -----------------------------------------------------------------------------
        // GET / (v1)
        // -----------------------------------------------------------------------------
        group.MapGet("/", async (WMSContext dbContext) =>
            await dbContext.ManualPickings
                   .Include(picking => picking.Warehouse)
                   .Include(picking => picking.Bin)
                        .ThenInclude(bin => bin!.BinNames)
                   .Include(picking => picking.PickedProducts)
                        .ThenInclude(pickedProduct => pickedProduct.ReceivedProduct)
                                .ThenInclude(receivedProduct => receivedProduct!.Product)
                  .Select(picking => picking.ToSummaryDto())
                  .AsNoTracking()
                  .ToListAsync()
        );

        // -----------------------------------------------------------------------------
        // GET /v2?search=&page=&pageSize=
        // -----------------------------------------------------------------------------
        group.MapGet("/v2", async (
            WMSContext dbContext,
            string? search = null,
            int page = 1,
            int pageSize = 50,
            CancellationToken cancellationToken = default) =>
        {
            const int maxPageSize = 500;
            page = Math.Max(page, 1);
            pageSize = Math.Clamp(pageSize, 1, maxPageSize);

            var query = dbContext.ManualPickings
                .Include(picking => picking.Warehouse)
                .Include(picking => picking.Bin)
                    .ThenInclude(bin => bin!.BinNames)
                .Include(picking => picking.PickedProducts)
                    .ThenInclude(pickedProduct => pickedProduct.ReceivedProduct)
                        .ThenInclude(receivedProduct => receivedProduct!.Product)
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                // NOTE: assumes warehouse name, bin name, and picked product
                // name are the meaningful search targets, matching the
                // "Warehouse" / "Bin" columns on the pick-orders dashboard
                // table. Adjust field names/navigation paths (e.g. BinNames'
                // actual name property) to match your entities.
                query = query.Where(picking =>
                    (picking.Warehouse != null && picking.Warehouse.Name.Contains(search)) ||
                    (picking.Bin != null && picking.Bin.BinNames!.BinName.Contains(search)) ||
                    picking.PickedProducts.Any(pp =>
                        pp.ReceivedProduct != null &&
                        pp.ReceivedProduct.Product != null &&
                        pp.ReceivedProduct.Product.Name.Contains(search)));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(picking => picking.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(picking => picking.ToSummaryDto())
                .ToListAsync(cancellationToken);

            var response = new PaginatedResponse<ManualPickingSummaryDto>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return Results.Ok(response);
        })
        .Produces<PaginatedResponse<ManualPickingSummaryDto>>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // Single Item & Mutation Endpoints
        // -----------------------------------------------------------------------------
        group.MapGet("/{Id}", async (int Id, WMSContext dbContext) => {
            ManualPicking? pick = await dbContext.ManualPickings.FindAsync(Id);

            return pick is null ? Results.NotFound() : Results.Ok(pick.ToDetailsDto());
        }).WithName(GetManualPickingEndpointName);

        group.MapPost("/", async (CreateManualPickingDto newManualPicking, WMSContext dbContext) =>
        {
            ManualPicking pick = newManualPicking.ToEntity();
            dbContext.ManualPickings.Add(pick);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetManualPickingEndpointName, new { id = pick.Id }, pick.ToDetailsDto());
        });

        group.MapPut("/", () => {

        });

        group.MapDelete("", () => {

        });

        return group;
    }
}