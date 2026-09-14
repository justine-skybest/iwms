
using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Dtos;
using WMS.Api.Entities;
using WMS.Api.Mapping;

namespace WMS.Api.Endpoints;

public static class WarehouseEndpoint
{    
    public static RouteGroupBuilder MapWarehouseEndpoints(this WebApplication app){
        const string GetWarehouseEndpointName = "GetWarehouse";
        var group = app.MapGroup("warehouse").WithParameterValidation();

        group.MapGet("/", async (WMSContext dbContext) => 
            await dbContext.Warehouses.Select(warehouse => warehouse.ToWarehouseDetailsDto()).AsNoTracking().ToListAsync()
        );

        group.MapGet("/{id}", async (int id, WMSContext dbContext) => 
        {
            Warehouse? warehouse = await dbContext.Warehouses.FindAsync(id);

            return warehouse is null ? Results.NotFound() : Results.Ok(warehouse.ToWarehouseDetailsDto());
        }).WithName(GetWarehouseEndpointName);

        group.MapPost("/", async (CreateWarehouseDto newWarehouse, WMSContext dbContext) => {
            Warehouse warehouse = newWarehouse.ToEntity();
            dbContext.Warehouses.Add(warehouse);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetWarehouseEndpointName, new {id = warehouse.Id}, warehouse.ToWarehouseDetailsDto());
        });

        group.MapPut("/{id}", async (int id, UpdateWarehouseDto updatedWarehouse, WMSContext dbContenxt) => 
        {
            var existingWarehouse = await dbContenxt.Warehouses.FindAsync(id);
            if(existingWarehouse is null)
            {
                return Results.NotFound();
            }

            dbContenxt.Entry(existingWarehouse).CurrentValues.SetValues(updatedWarehouse.ToEntity(id));
            await dbContenxt.SaveChangesAsync();

            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, WMSContext dbContext) => 
        {
            await dbContext.Warehouses.Where(warehouse => warehouse.Id == id).ExecuteDeleteAsync();
            return Results.NoContent();
        });

        return group;
    }
}
