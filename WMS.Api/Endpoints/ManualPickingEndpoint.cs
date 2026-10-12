using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections;
using WMS.Api.Data;
using WMS.Api.Dtos;
using WMS.Api.Dtos.ManualPicking;
using WMS.Api.Entities;
using WMS.Api.Mapping;
using WMS.Api.Services;

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
                .OrderByDescending(picking => picking.PickingDate)
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
        group.MapGet("/{id:int}", async Task<Results<Ok<ManualPickingDetailsDto>, NotFound>> (
            int id,
            WMSContext dbContext,
            CancellationToken cancellationToken) =>
        {
            var pick = await dbContext.ManualPickings
                .Include(picking => picking.PickedProducts)
                    .ThenInclude(pickedProduct => pickedProduct.ReceivedProduct)
                        .ThenInclude(receivedProduct => receivedProduct!.Product)
                .AsNoTracking()
                .FirstOrDefaultAsync(picking => picking.Id == id, cancellationToken);

            return pick is null
                ? TypedResults.NotFound()
                : TypedResults.Ok(pick.ToDetailsDto());
        })
        .WithName(GetManualPickingEndpointName)
        .WithSummary("Get a manual pick order by ID")
        .WithDescription("Returns a manual pick order with its picked-product lines, including product names, picked quantities, and pick dates. Returns 404 when the pick order does not exist.")
        .Produces<ManualPickingDetailsDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPost("/", async (
            CreateManualPickingDto newManualPicking,
            WMSContext dbContext,
            IAuditLogService auditLogService,
            CancellationToken cancellationToken) =>
        {
            ManualPicking pick = newManualPicking.ToEntity();
            dbContext.ManualPickings.Add(pick);
            await dbContext.SaveChangesAsync(cancellationToken);

            var targetBin = await dbContext.Bins
                .AsNoTracking()
                .Where(b =>
                    b.Id == newManualPicking.BinId &&
                    (b.Rack != null
                        ? b.Rack.WarehouseId == newManualPicking.WarehouseId
                        : b.WarehouseId == newManualPicking.WarehouseId))
                .Include(b => b.Warehouse)
                .Include(b => b.Rack)
                    .ThenInclude(r => r!.Warehouse)
                .Include(b => b.BinNames)
                .Include(b => b.Bay)
                .Include(b => b.Level)
                .FirstOrDefaultAsync(cancellationToken);

            var receivedProducts = await dbContext.ReceivedProducts
                .AsNoTracking()
                .Include(rp => rp.Product)
                .Where(rp => newManualPicking.PickedProducts!.Select(pp => pp.ReceivedProductId).Contains(rp.Id))
                .ToListAsync(cancellationToken);

            await auditLogService.LogAsync(
                category: nameof(ManualPicking),
                action: "Created",
                description: $"Picked {newManualPicking.PickedProducts!.Count} item(s) from Bin id [{newManualPicking.BinId}]",
                details: new
                {
                    PickingId = pick.Id,
                    TotalItemsPicked = newManualPicking.PickedProducts!.Count,
                    TargetBin = targetBin!.ToSummaryDto(),
                    newManualPicking.PickingDate,
                    Notes = string.IsNullOrWhiteSpace(newManualPicking.Notes) ? "—" : newManualPicking.Notes,
                    Items = receivedProducts.Select(pp => new
                    {
                        pp.Id,
                        ProductName = pp.Product?.Name ?? $"Product #{pp.ProductId}",
                        pp.Quantity,
                        pp.LotNumber
                    })
                }
            );

            var createdPick = await dbContext.ManualPickings
                .Include(picking => picking.PickedProducts)
                    .ThenInclude(pickedProduct => pickedProduct.ReceivedProduct)
                        .ThenInclude(receivedProduct => receivedProduct!.Product)
                .AsNoTracking()
                .FirstAsync(picking => picking.Id == pick.Id, cancellationToken);

            return Results.CreatedAtRoute(GetManualPickingEndpointName, new { id = pick.Id }, createdPick.ToDetailsDto());
        })
        .WithSummary("Create a manual pick order")
        .WithDescription("Creates a manual pick order with its picked-product lines and returns the created order, including the picked-product details.")
        .Produces<ManualPickingDetailsDto>(StatusCodes.Status201Created)
        .ProducesValidationProblem(StatusCodes.Status400BadRequest);

        group.MapPut("/", () => {

        });

        group.MapDelete("", () => {

        });

        return group;
    }
}