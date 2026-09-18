using System;
using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Dtos;
using WMS.Api.Entities;
using WMS.Api.Mapping;

namespace WMS.Api.Endpoints;

public static class BinNamesEndpoint
{
    public static RouteGroupBuilder MapBinNameEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("binnames");

        // -----------------------------------------------------------------------------
        // GET / (v1 & v2)
        // -----------------------------------------------------------------------------
        group.MapGet("/", async (WMSContext dbContext) =>
            await dbContext.BinNames
                  .Select(binnames => binnames.ToDto())
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

            var query = dbContext.BinNames.AsNoTracking();

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(binName => binName.Id)
                .Select(binName => binName.ToDto())
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            var response = new PaginatedResponse<BinNamesDto>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return Results.Ok(response);
        })
        .Produces<PaginatedResponse<BinNamesDto>>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // GET /rack/{rackId}/bay/{bayId}/level/{levelId} (v1 & v2)
        // -----------------------------------------------------------------------------
        group.MapGet("/rack/{rackId}/bay/{bayId}/level/{levelId}", async (int rackId, int bayId, int levelId, WMSContext dbContext) =>
            await dbContext.BinNames
                  .Where(binNames =>
                        !dbContext.Bins
                        .Where(bin => bin.RackId == rackId && bin.BayId == bayId && bin.LevelId == levelId)
                        .Select(bin => bin.BinNamesId)
                        .Contains(binNames.Id))
                  .Select(binNames => binNames.ToDto())
                  .AsNoTracking()
                  .ToListAsync()
        );

        group.MapGet("/v2/rack/{rackId}/bay/{bayId}/level/{levelId}", async (
            int rackId,
            int bayId,
            int levelId,
            WMSContext dbContext,
            int page = 1,
            int pageSize = 50,
            CancellationToken cancellationToken = default) =>
        {
            const int maxPageSize = 500;
            page = Math.Max(page, 1);
            pageSize = Math.Clamp(pageSize, 1, maxPageSize);

            var query = dbContext.BinNames
                .Where(binNames =>
                    !dbContext.Bins
                    .Where(bin => bin.RackId == rackId && bin.BayId == bayId && bin.LevelId == levelId)
                    .Select(bin => bin.BinNamesId)
                    .Contains(binNames.Id))
                .AsNoTracking();

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(binName => binName.Id)
                .Select(binName => binName.ToDto())
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            var response = new PaginatedResponse<BinNamesDto>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return Results.Ok(response);
        })
        .Produces<PaginatedResponse<BinNamesDto>>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // GET /rack/{rackId}/bay/{bayId}/level/{levelId}/binName/{binNameId} (v1 & v2)
        // -----------------------------------------------------------------------------
        group.MapGet("/rack/{rackId}/bay/{bayId}/level/{levelId}/binName/{binNameId}", async (int rackId, int bayId, int levelId, int binNameId, WMSContext dbContext) =>
            await dbContext.BinNames
                  .Where(binNames => binNames.Id == binNameId ||
                        !dbContext.Bins
                        .Where(bin => bin.RackId == rackId && bin.BayId == bayId && bin.LevelId == levelId)
                        .Select(bin => bin.BinNamesId)
                        .Contains(binNames.Id))
                  .Select(binNames => binNames.ToDto())
                  .AsNoTracking()
                  .ToListAsync()
        );

        group.MapGet("/v2/rack/{rackId}/bay/{bayId}/level/{levelId}/binName/{binNameId}", async (
            int rackId,
            int bayId,
            int levelId,
            int binNameId,
            WMSContext dbContext,
            int page = 1,
            int pageSize = 50,
            CancellationToken cancellationToken = default) =>
        {
            const int maxPageSize = 500;
            page = Math.Max(page, 1);
            pageSize = Math.Clamp(pageSize, 1, maxPageSize);

            var query = dbContext.BinNames
                .Where(binNames => binNames.Id == binNameId ||
                    !dbContext.Bins
                    .Where(bin => bin.RackId == rackId && bin.BayId == bayId && bin.LevelId == levelId)
                    .Select(bin => bin.BinNamesId)
                    .Contains(binNames.Id))
                .AsNoTracking();

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(binName => binName.Id)
                .Select(binName => binName.ToDto())
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            var response = new PaginatedResponse<BinNamesDto>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return Results.Ok(response);
        })
        .Produces<PaginatedResponse<BinNamesDto>>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // GET /{id}
        // -----------------------------------------------------------------------------
        group.MapGet("/{id}", async (int id, WMSContext dbContext) =>
        {
            BinNames? binName = await dbContext.BinNames.FindAsync(id);

            return binName is null ? Results.NotFound() : Results.Ok(binName.ToDto());
        });

        return group;
    }
}