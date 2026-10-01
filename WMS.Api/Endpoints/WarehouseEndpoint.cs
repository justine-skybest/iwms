using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Dtos;
using WMS.Api.Entities;
using WMS.Api.Mapping;

namespace WMS.Api.Endpoints;

public static class WarehouseEndpoint
{
    public static RouteGroupBuilder MapWarehouseEndpoints(this WebApplication app)
    {
        const string GetWarehouseEndpointName = "GetWarehouse";
        var group = app.MapGroup("warehouse").WithParameterValidation();

        // -----------------------------------------------------------------------------
        // GET / (v1)
        // -----------------------------------------------------------------------------
        group.MapGet("/", async (WMSContext dbContext) =>
            await dbContext.Warehouses
                .Select(warehouse => warehouse.ToWarehouseDetailsDto())
                .AsNoTracking()
                .ToListAsync()
        );

        // -----------------------------------------------------------------------------
        // GET /v2?search=&page=&pageSize= — paginated, with optional search query
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

            var query = dbContext.Warehouses.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                // NOTE: adjust `Name` below if Warehouse's searchable field is
                // named differently (e.g. Code, Location).
                query = query.Where(warehouse => warehouse.Name.Contains(search));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(warehouse => warehouse.Id)
                .Select(warehouse => warehouse.ToWarehouseDetailsDto())
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            var response = new PaginatedResponse<WarehouseDetailsDto>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return Results.Ok(response);
        })
        .Produces<PaginatedResponse<WarehouseDetailsDto>>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // Single Item & Mutation Endpoints
        // -----------------------------------------------------------------------------
        group.MapGet("/{id:int}", async (int id, WMSContext dbContext) =>
        {
            Warehouse? warehouse = await dbContext.Warehouses.FindAsync(id);

            return warehouse is null ? Results.NotFound() : Results.Ok(warehouse.ToWarehouseDetailsDto());
        }).WithName(GetWarehouseEndpointName);

        group.MapPost("/", async (CreateWarehouseDto newWarehouse, WMSContext dbContext) =>
        {
            Warehouse warehouse = newWarehouse.ToEntity();
            dbContext.Warehouses.Add(warehouse);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetWarehouseEndpointName, new { id = warehouse.Id }, warehouse.ToWarehouseDetailsDto());
        });

        group.MapPut("/{id:int}", async (int id, UpdateWarehouseDto updatedWarehouse, WMSContext dbContext) =>
        {
            var existingWarehouse = await dbContext.Warehouses.FindAsync(id);
            if (existingWarehouse is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingWarehouse).CurrentValues.SetValues(updatedWarehouse.ToEntity(id));
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        group.MapDelete("/{id:int}", async (int id, WMSContext dbContext) =>
        {
            await dbContext.Warehouses.Where(warehouse => warehouse.Id == id).ExecuteDeleteAsync();
            return Results.NoContent();
        });

        return group;
    }
}