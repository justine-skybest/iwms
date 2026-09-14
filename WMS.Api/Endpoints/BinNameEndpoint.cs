using System;
using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Entities;
using WMS.Api.Mapping;

namespace WMS.Api.Endpoints;

public static class BinNamesEndpoint
{
    public static RouteGroupBuilder MapBinNameEndpoints (this WebApplication app)
    {
        var group =app.MapGroup("binnames");

        group.MapGet("/", async (WMSContext dbContext) => 
            await dbContext.BinNames
                  .Select(binnames => binnames.ToDto())
                  .AsNoTracking()
                  .ToListAsync());
        
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

         group.MapGet("/{id}", async (int id, WMSContext dbContext) => 
        {
            BinNames? binName = await dbContext.BinNames.FindAsync(id);
            
            return binName is null ? Results.NotFound() : Results.Ok(binName.ToDto());
        });
        
        return group;
    }
}
