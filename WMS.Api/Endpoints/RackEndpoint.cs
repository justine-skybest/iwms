using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Dtos;
using WMS.Api.Entities;
using WMS.Api.Mapping;

namespace WMS.Api.Endpoints;

public static class RackEndpoint
{
    const string GetRacksEndpointName = "GetRack";

    public static RouteGroupBuilder MapRackEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("rack").WithParameterValidation();

        // -----------------------------------------------------------------------------
        // GET / (v1 & v2)
        // -----------------------------------------------------------------------------
        group.MapGet("/", async (WMSContext dbContext) =>
            await dbContext.Racks
                .Include(rack => rack.Warehouse)
                .Include(rack => rack.Bay)
                .Include(rack => rack.Level)
                .Include(rack => rack.RackFloorMapObject)
                .OrderBy(rack => rack.Warehouse)
                .ThenBy(rack => rack.Name)
                .Select(rack => rack.ToRackSummaryDto())
                .AsNoTracking()
                .ToListAsync()
        );

        group.MapGet("/v2", async (
            WMSContext dbContext,
            int page = 1,
            int pageSize = 50,
            CancellationToken cancellationToken = default) =>
        {
            const int maxPageSize = 500;
            page = Math.Max(page, 1);
            pageSize = Math.Clamp(pageSize, 1, maxPageSize);

            var query = dbContext.Racks
                .Include(rack => rack.Warehouse)
                .Include(rack => rack.Bay)
                .Include(rack => rack.Level)
                .Include(rack => rack.RackFloorMapObject)
                .AsNoTracking();

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(rack => rack.Warehouse)
                    .ThenBy(rack => rack.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(rack => rack.ToRackSummaryDto())
                .ToListAsync(cancellationToken);

            var response = new PaginatedResponse<RackSummaryDto>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return Results.Ok(response);
        })
        .Produces<PaginatedResponse<RackSummaryDto>>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // GET /warehouse/{id} (v1 & v2)
        // -----------------------------------------------------------------------------
        group.MapGet("/warehouse/{id}", async (int id, WMSContext dbContext) =>
            await dbContext.Racks
                    .Include(rack => rack.Warehouse)
                    .Include(rack => rack.Bay)
                    .Include(rack => rack.Level)
                    .Include(rack => rack.RackFloorMapObject)
                    .Where(rack => rack.WarehouseId == id)
                    .Select(rack => rack.ToRackSummaryDto())
                    .AsNoTracking()
                    .ToListAsync()
        );

        group.MapGet("/v2/warehouse/{id}", async (
            int id,
            WMSContext dbContext,
            int page = 1,
            int pageSize = 50,
            CancellationToken cancellationToken = default) =>
        {
            const int maxPageSize = 500;
            page = Math.Max(page, 1);
            pageSize = Math.Clamp(pageSize, 1, maxPageSize);

            var query = dbContext.Racks
                .Where(rack => rack.WarehouseId == id)
                .Include(rack => rack.Warehouse)
                .Include(rack => rack.Bay)
                .Include(rack => rack.Level)
                .Include(rack => rack.RackFloorMapObject)
                .AsNoTracking();

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(rack => rack.Warehouse)
                    .ThenBy(rack => rack.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(rack => rack.ToRackSummaryDto())
                .ToListAsync(cancellationToken);

            var response = new PaginatedResponse<RackSummaryDto>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return Results.Ok(response);
        })
        .Produces<PaginatedResponse<RackSummaryDto>>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // Single Item & Helper Endpoints
        // -----------------------------------------------------------------------------
        group.MapGet("/{id}", async (int id, WMSContext dbContext) =>
        {
            Rack? rack = await dbContext.Racks
                .Include(rack => rack.RackFloorMapObject)
                .FirstOrDefaultAsync(result => result.Id == id);

            return rack is null ? Results.NotFound() : Results.Ok(rack.ToRackDetailsDto());
        }).WithName(GetRacksEndpointName);

        group.MapGet("/bin/{id}", async (int id, WMSContext dbContext) =>
        {
            Bin? bin = await dbContext.Bins.FindAsync(id);
            if (bin == null)
            {
                return Results.NotFound($"Bin with ID {id} not found.");
            }

            Rack? rack = await dbContext.Racks
                .Include(r => r.RackFloorMapObject)
                .FirstOrDefaultAsync(r => r.Id == bin.RackId);

            if (rack == null)
            {
                return Results.NotFound($"Rack with ID {bin.RackId} not found.");
            }

            return Results.Ok(rack.ToRackDetailsDto());
        });

        // -----------------------------------------------------------------------------
        // Mutation Endpoints
        // -----------------------------------------------------------------------------
        group.MapPost("/", async (CreateRackDto newRack, WMSContext dbContext) =>
        {
            Rack rack = newRack.ToEntity();
            dbContext.Racks.Add(rack);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetRacksEndpointName, new { id = rack.Id }, rack.ToRackDetailsDto());
        });

        group.MapPut("/{id}", async (int id, UpdateRackDto updatedRack, WMSContext dbContext) =>
        {
            var existingRack = await dbContext.Racks
                .Include(rack => rack.RackFloorMapObject)
                .FirstOrDefaultAsync(result => result.Id == id);

            if (existingRack is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingRack).CurrentValues.SetValues(updatedRack.ToEntity(id));

            foreach (var updatedObject in updatedRack.RackFloorMapObject)
            {
                var existingObject = existingRack.RackFloorMapObject.FirstOrDefault(p => p.Id == updatedObject.Id);
                if (existingObject != null && existingObject.Id != 0)
                {
                    dbContext.Entry(existingObject).CurrentValues.SetValues(updatedObject);
                }
                else
                {
                    existingRack.RackFloorMapObject.Add(new RackFloorMapObject
                    {
                        RackId = updatedObject.RackId,
                        Type = updatedObject.Type,
                        Left = updatedObject.Left,
                        Top = updatedObject.Top,
                        Width = updatedObject.Width,
                        Height = updatedObject.Height,
                        Text = updatedObject.Text,
                        Fill = updatedObject.Fill,
                        Stroke = updatedObject.Stroke,
                        StrokeWidth = updatedObject.StrokeWidth,
                        FontSize = updatedObject.FontSize,
                        ScaleX = updatedObject.ScaleX,
                        ScaleY = updatedObject.ScaleY,
                        Angle = updatedObject.Angle
                    });
                }
            }

            foreach (var existingObject in existingRack.RackFloorMapObject.ToList())
            {
                if (!updatedRack.RackFloorMapObject.Any(p => p.Id == existingObject.Id))
                {
                    dbContext.RackFloorMapObjects.Remove(existingObject);
                }
            }

            await dbContext.SaveChangesAsync();
            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, WMSContext dbContext) =>
        {
            await dbContext.Racks.Where(rack => rack.Id == id).ExecuteDeleteAsync();
            return Results.NoContent();
        });

        return group;
    }
}