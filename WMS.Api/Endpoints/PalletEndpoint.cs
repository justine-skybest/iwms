using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Dtos.Pallet;
using WMS.Api.Entities;
using WMS.Api.Mapping;

namespace WMS.Api.Endpoints;

public static class PalletEndpoint
{
    public static RouteGroupBuilder MapPalletEndpoints(this WebApplication app)
    {
        const string GetPalletEndpointName = "GetPallet";
        var group = app.MapGroup("pallet").WithParameterValidation();

        group.MapGet("/", async (WMSContext dbContext) =>
             await dbContext.Pallets
                    .Include(pallet => pallet.Warehouse)
                    .Select(pallet => pallet.ToSummaryDto()).AsNoTracking().ToListAsync() ?? []
        );

        group.MapGet("/Warehouse/{id:int}", async (int id, WMSContext dbContext) =>
            await dbContext.Pallets
                    .Include(pallet => pallet.Warehouse)
                    .Where(pallet => pallet.WarehouseId == id)
                    .Select(pallet => pallet.ToSummaryDto()).AsNoTracking().ToListAsync() ?? []
        );

        
        group.MapGet("/{id:int}", async (int id, WMSContext dbContext) =>
        {
            Pallet? pallet = await dbContext.Pallets.FindAsync(id);

            return pallet is null ? Results.NotFound() : Results.Ok(pallet.ToDetailDto());
        }).WithName(GetPalletEndpointName);

        group.MapGet("/ToBeCheckIn/{WarehouseId:int}", async (WMSContext dbContext, int WarehouseId) =>
             await dbContext.Pallets                                        
                    .Include(pallet => pallet.ReceivedProducts!)
                        .ThenInclude(product => product.Product)
                    .Include(pallet => pallet.ReceivedProducts!)
                        .ThenInclude(product => product.Receiving)
                    .Include(pallet => pallet.Warehouse!)                    
                    .Where(pallet =>  pallet.ReceivedProducts != null && pallet.ReceivedProducts.Any())
                    .Where(p => !dbContext.CheckIns.Any(c => c.PalletId == p.Id)) 
                    .Where(pallet => pallet.WarehouseId == WarehouseId)
                    .Select(p => p.ToBeCheckInDto())                                  
                    .AsNoTracking().ToListAsync() ?? []
        );

        group.MapGet("/QRCode/{PalletHasCode:int}/{WarehouseId:int}", async (int PalletHasCode, int WarehouseId, WMSContext dbContext) =>
        {
            bool PalletExistAndUsed = await dbContext.Pallets.AnyAsync(pallet => pallet.PalletHashCode == PalletHasCode && pallet.WarehouseId == WarehouseId && pallet.ReceivedProducts != null && pallet.ReceivedProducts.Count() != 0);                     
            
            Pallet? pallet = await dbContext.Pallets.FirstOrDefaultAsync(pallet => pallet.PalletHashCode == PalletHasCode && pallet.WarehouseId == WarehouseId && (pallet.ReceivedProducts == null || pallet.ReceivedProducts.Count() == 0)) ?? new()
            {
                Id = 0,
                WarehouseId = 0,
                PalletNumber = 0,
                PalletHashCode = 0,   
                PalletDimension = PalletExistAndUsed ? "This QR code is from a pallet that is currently in use." : "This QR code is not present on any pallets in this warehouse."
            };
            return Results.Ok(pallet.ToDetailDto());
        });

        group.MapGet("/number/{WarehouseId:int}", async (int WarehouseId, WMSContext dbContext) =>
        {
            var lastNumber = await dbContext.Pallets
                                 .OrderByDescending(pallet => pallet.PalletNumber)
                                 .Where(pallet => pallet.WarehouseId == WarehouseId)
                                 .Select(pallet => pallet.PalletNumber)
                                 .FirstOrDefaultAsync();

            return lastNumber;
        });


        group.MapPost("/", async (CreatePalletDto newPallet, WMSContext dbContext) =>
        {
            Pallet pallet = newPallet.ToEntity();
            dbContext.Pallets.Add(pallet);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetPalletEndpointName, new { id = pallet.Id }, pallet.ToSummaryDto());
        });

        group.MapPost("/autocreate/{WarehouseId:int}", async (WMSContext dbContext, int WarehouseId) =>
        {
            // Get the last pallet number
            var lastNumber = await dbContext.Pallets
                                .OrderByDescending(pallet => pallet.PalletNumber)
                                .Where(pallet => pallet.WarehouseId == WarehouseId)
                                .Select(pallet => pallet.PalletNumber)                                
                                .FirstOrDefaultAsync();

            // Increment the pallet number
            var newPalletNumber = lastNumber + 1;

            // Generate the hash code (similar to the Blazor front-end logic)
            var hash = new HashCode();
            hash.Add(DateTime.Now); // Add the current date
            hash.Add(DateTime.Now.TimeOfDay); // Add the current time

            // Create the new pallet
            var newPallet = new CreatePalletDto(
                WarehouseId,
                newPalletNumber,
                hash.ToHashCode(),
                "",
                0,
                0,
                DateTime.Now
            );

            Pallet pallet = newPallet.ToEntity();
            // Add to database
            dbContext.Pallets.Add(pallet);
            await dbContext.SaveChangesAsync();

            return pallet is null ? Results.NoContent() : Results.Ok(pallet.ToDetailDto());
        });

        group.MapPut("/{id}", async (int id, CreatePalletDto updatedPallet, WMSContext dbContext) =>
        {
            var existingPallet = await dbContext.Pallets.FindAsync(id);
            if (existingPallet is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingPallet).CurrentValues.SetValues(updatedPallet.ToUpdateEntity(id));
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, WMSContext dbContext) =>
        {
            await dbContext.Pallets.Where(pallet => pallet.Id == id).ExecuteDeleteAsync();
            return Results.NoContent();
        });

        return group;
    }
}
