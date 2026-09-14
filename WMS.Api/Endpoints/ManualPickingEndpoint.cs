using System;
using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
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

        group.MapGet("/{Id}", async (int Id, WMSContext dbContext) => {
            ManualPicking? pick = await dbContext.ManualPickings.FindAsync(Id);

            return pick is null ? Results.NotFound() : Results.Ok(pick.ToDetailsDto());
        }).WithName(GetManualPickingEndpointName);

        group.MapPost("/", async (CreateManualPickingDto newManualPicking, WMSContext dbContext) => 
        {
            ManualPicking pick = newManualPicking.ToEntity();
            dbContext.ManualPickings.Add(pick);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetManualPickingEndpointName, new {id = pick.Id}, pick.ToDetailsDto());
        });

        group.MapPut("/", () => {

        });

        group.MapDelete("", () => {

        });

        
        return group;
    }
}
