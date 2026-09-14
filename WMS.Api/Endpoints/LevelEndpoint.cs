using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Mapping;

namespace WMS.Api.Endpoints;

public static class LevelEndpoint
{
    public static RouteGroupBuilder MapLevelEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("level");

        group.MapGet("/", async (WMSContext dbContext) =>
           await dbContext.Levels.Select(level => level.ToDto()).AsNoTracking().ToListAsync());
           
        group.MapGet("/lessOrEqual/{id}", async (int id, WMSContext dbContext) =>
           await dbContext.Levels.Where(level => level.Id <= id).Select(level => level.ToDto()).AsNoTracking().ToListAsync());

        return group;
    }
}
