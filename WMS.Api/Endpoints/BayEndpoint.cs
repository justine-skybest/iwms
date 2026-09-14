using System;
using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Mapping;

namespace WMS.Api.Endpoints;

public static class BayEndpoint
{
    public static RouteGroupBuilder MapBayEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("bay");

        group.MapGet("/", async (WMSContext dbContext) =>
           await dbContext.Bays.Select(bay => bay.ToDto()).AsNoTracking().ToListAsync());

        group.MapGet("/lessOrEqual/{id}", async (int id, WMSContext dbContext) =>
           await dbContext.Bays.Where(bay => bay.Id <= id).Select(bay => bay.ToDto()).AsNoTracking().ToListAsync());

        return group;
    }
}
