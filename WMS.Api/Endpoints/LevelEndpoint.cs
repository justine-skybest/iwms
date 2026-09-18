using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Dtos;
using WMS.Api.Mapping;

namespace WMS.Api.Endpoints;

public static class LevelEndpoint
{
    public static RouteGroupBuilder MapLevelEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("level");

        // -----------------------------------------------------------------------------
        // GET / (v1 & v2)
        // -----------------------------------------------------------------------------
        group.MapGet("/", async (WMSContext dbContext) =>
           await dbContext.Levels.Select(level => level.ToDto()).AsNoTracking().ToListAsync());

        group.MapGet("/v2", async (
            WMSContext dbContext,
            int page = 1,
            int pageSize = 50,
            CancellationToken cancellationToken = default) =>
        {
            const int maxPageSize = 500;
            page = Math.Max(page, 1);
            pageSize = Math.Clamp(pageSize, 1, maxPageSize);

            var query = dbContext.Levels.AsNoTracking();

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(level => level.Id)
                .Select(level => level.ToDto())
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            var response = new PaginatedResponse<LevelDto>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return Results.Ok(response);
        })
        .Produces<PaginatedResponse<LevelDto>>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // GET /lessOrEqual/{id} (v1 & v2)
        // -----------------------------------------------------------------------------
        group.MapGet("/lessOrEqual/{id}", async (int id, WMSContext dbContext) =>
           await dbContext.Levels.Where(level => level.Id <= id).Select(level => level.ToDto()).AsNoTracking().ToListAsync());

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

            var query = dbContext.Levels.Where(level => level.Id <= id).AsNoTracking();

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(level => level.Id)
                .Select(level => level.ToDto())
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            var response = new PaginatedResponse<LevelDto>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return Results.Ok(response);
        })
        .Produces<PaginatedResponse<LevelDto>>(StatusCodes.Status200OK);

        return group;
    }
}