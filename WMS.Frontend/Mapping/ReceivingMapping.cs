using System;
using WMS.Frontend.Clients;
using WMS.Frontend.Models;

namespace WMS.Frontend.Mapping;

public static class ReceivingMapping
{
    public static ReceivedProductDetails ToDetails(this ReceivedProductSummary summary)
    {
        return new ReceivedProductDetails(){
            ProductId = summary.Id,
            Quantity = summary.Quantity,
            CBM = summary.CBM,
            TotalWeight = summary.TotalWeight,
            ExpirationDate = summary.ExpirationDate,
            Remarks = summary.Remarks,
            PalletId = summary.PalletId
        };
    }

    public static async Task<ReceivedProductSummary> ToSummaryAsync(this ReceivedProductDetails details, ProductClient productClient, PalletClient palletClient)
    {
        if(!String.IsNullOrWhiteSpace(details.PalletId))
        {
            var product = await productClient.GetProductAsync(details.ProductId);
            var pallet = await palletClient.GetPalletAsync(Convert.ToInt32(details.PalletId));
            return new ReceivedProductSummary()
            {
                Id = details.ProductId,
                Name = product.Name,
                TypeOfPackage = product.TypeOfPackage,
                Measurement = product.Measurement,
                Weight = product.Weight,
                Quantity = details.Quantity,
                CBM = details.CBM,
                TotalWeight = details.TotalWeight,
                ExpirationDate = details.ExpirationDate,
                Remarks = details.Remarks,
                ContainerName = "",
                PalletId = $"Pallet #{pallet.PalletNumber}"
            };
        }
        else{
            var product = await productClient.GetProductAsync(details.ProductId);
            return new ReceivedProductSummary()
            {
                Id = details.ProductId,
                Name = product.Name,
                TypeOfPackage = product.TypeOfPackage,
                Measurement = product.Measurement,
                Weight = product.Weight,
                Quantity = details.Quantity,
                CBM = details.CBM,
                TotalWeight = details.TotalWeight,
                ExpirationDate = details.ExpirationDate,
                ContainerName = !String.IsNullOrEmpty(details.ContainerName) ? details.ContainerName : "",
                Remarks = details.Remarks,
                PalletId = "Individual Item(s)"
            };
        }
        
    }
}
