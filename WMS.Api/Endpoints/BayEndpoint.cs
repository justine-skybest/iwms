using System;
using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Dtos;
using WMS.Api.Mapping;

namespace WMS.Api.Endpoints;

public static class BayEndpoint
{
    public static RouteGroupBuilder MapBayEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("bay");

        // -----------------------------------------------------------------------------
        // GET / (v1 & v2)
        // -----------------------------------------------------------------------------
        group.MapGet("/", async (WMSContext dbContext) =>
           await dbContext.Bays
                .Select(bay => bay.ToDto())
                .AsNoTracking()
                .ToListAsync());

        group.MapGet("/v2", async (
            WMSContext dbContext,
            int page = 1,
            int pageSize = 50,
            CancellationToken cancellationToken = default) =>
        {
            const int maxPageSize = 500;
            page = Math.Max(page, 1);
            pageSize = Math.Clamp(pageSize, 1, maxPageSize);

            var query = dbContext.Bays
                // .Include(bay => bay.Rack) // Add navigation includes here if ToDto() accesses related entities
                .AsNoTracking();

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(bay => bay.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(bay => bay.ToDto())
                .ToListAsync(cancellationToken);

            var response = new PaginatedResponse<BayDto>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return Results.Ok(response);
        })
        .Produces<PaginatedResponse<BayDto>>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // GET /lessOrEqual/{id} (v1 & v2)
        // -----------------------------------------------------------------------------
        group.MapGet("/lessOrEqual/{id}", async (int id, WMSContext dbContext) =>
           await dbContext.Bays
                .Where(bay => bay.Id <= id)
                .Select(bay => bay.ToDto())
                .AsNoTracking()
                .ToListAsync());

        group.MapGet("/v2/lessOrEqual/{id}", async (
            int id,
            WMSContext dbContext,
            int page = 1,
            int pageSize = 50,
            CancellationToken cancellationToken = default) =>
        {
            const int maxPageSize = 500;
            page = Math.Max(page, 1);
            pageSize = Math.Clamp(pageSize, 1, maxPageSize);

            var query = dbContext.Bays
                .Where(bay => bay.Id <= id)
                // .Include(bay => bay.Rack) // Add navigation includes here if ToDto() accesses related entities
                .AsNoTracking();

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(bay => bay.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(bay => bay.ToDto())
                .ToListAsync(cancellationToken);

            var response = new PaginatedResponse<BayDto>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return Results.Ok(response);
        })
        .Produces<PaginatedResponse<BayDto>>(StatusCodes.Status200OK);

        return group;
    }
}