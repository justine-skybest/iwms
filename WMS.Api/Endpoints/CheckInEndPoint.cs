using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Dtos.CheckIn;
using WMS.Api.Entities;
using WMS.Api.Mapping;

namespace WMS.Api.Endpoints;

public static class CheckInEndPoint
{
    const string GetCheckInEndpoint = "GetCheckIn";
    public static RouteGroupBuilder MapCheckInEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("checkin").WithParameterValidation();
        
        group.MapGet("/", async (WMSContext dbContext) => 
                await dbContext.CheckIns
                        .Include(checkedin => checkedin.Bins)
                        .Include(checkedin => checkedin.Pallet)
                        .Select(checkedin => checkedin.ToCheckInSummaryDto())
                        .AsNoTracking()
                        .ToListAsync()
        );

        group.MapGet("/Bin/{id}", async (WMSContext dbContext, int id) =>
            await dbContext.CheckIns
                .Where(ci => ci.Bins.Any(b => b.Id == id))               
                .Include(ci => ci.Pallet)
                .Include(ci => ci.ReceivedProducts)
                    .ThenInclude(ci =>ci.Product)
                .AsNoTracking()
                .Select(ci => ci.ToDisplayCheckinProductsDto())
                .ToListAsync()
        );

        group.MapGet("/{id}", async (int id, WMSContext dbContext) => {
            CheckIn? checkIn = await dbContext.CheckIns.FindAsync(id);

            return checkIn is null ? Results.NotFound() : Results.Ok(checkIn.ToCheckInDetailsDto());
        }).WithName(GetCheckInEndpoint);

        group.MapPost("/", async (CreateCheckInDto newCheckIn, WMSContext dbContext) => 
        {
            var bins = await dbContext.Bins
                .Where(b => newCheckIn.BinIds.Contains(b.Id))
                .ToListAsync();

            if (bins.Count != newCheckIn.BinIds.Count)
            {
                return Results.BadRequest("One or more BinIds are invalid.");
            }

            var receivedProducts = await dbContext.ReceivedProducts
                    .Where(rp => newCheckIn.ReceivedProductIds!.Contains(rp.Id))
                    .ToListAsync();

            if (newCheckIn.PalletId is null && receivedProducts.Count != newCheckIn.ReceivedProductIds!.Count)
            {
                return Results.BadRequest("One or more ReceivedProductIds are invalid.");
            }
            
            CheckIn checkIn = newCheckIn.ToEntity(bins, receivedProducts);
            dbContext.CheckIns.Add(checkIn);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetCheckInEndpoint, new {id = checkIn.Id}, checkIn.ToCheckInDetailsDto());
        });

        return group;
    }
}
