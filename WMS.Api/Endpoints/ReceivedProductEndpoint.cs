using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Mapping;
namespace WMS.Api.Endpoints;

public static class ReceivedProductEndpoint
{
    const string GetReceivedProductEndpoint = "GetReceivedProduct";

    public static RouteGroupBuilder MapReceivedProductEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("receivedProduct").WithParameterValidation();
       
        group.MapGet("/ToCheckInProducts/{WarehouseId:int}", async (int WarehouseId, WMSContext dbContext) =>
        {
            // Step 1: Find all ReceivedProductIds that were already checked in
            var checkedInReceivedProductIds = await dbContext.CheckIns
                .SelectMany(ci => ci.ReceivedProducts) // Access the ReceivedProducts navigation
                .Select(rp => rp.Id)
                .ToListAsync();

            // Step 2: Find all unpalletized ReceivedProducts not yet checked in
            var unpalletizedAndNotCheckedIn = await dbContext.ReceivedProducts
                .Include(rp => rp.Product)
                .Include(rp => rp.Receiving)
                .Where(rp => rp.PalletId == null) // Not palletized
                .Where(rp => rp.Receiving != null && rp.Receiving.WarehouseId == WarehouseId) // Correct warehouse
                .Where(rp => !checkedInReceivedProductIds.Contains(rp.Id)) // Not checked-in
                .Select(rp => rp.ToReceivedProductDTO()) // Map to DTO
                .ToListAsync();

            return unpalletizedAndNotCheckedIn;
        });


        return group;
    }
}
