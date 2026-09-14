using System;
using WMS.Api.Dtos.CheckIn;
using WMS.Api.Dtos.Receiving;
using WMS.Api.Entities;

namespace WMS.Api.Mapping;

public static class CheckInMapping
{
    public static CheckIn ToEntity(this CreateCheckInDto createdCheckIn, List<Bin> bins, List<ReceivedProduct> receivedProducts)
    {
        return new()
        {
            CheckInType = createdCheckIn.CheckInType,
            Bins = bins,
            PalletId = createdCheckIn.PalletId,
            ReceivedProducts = receivedProducts,
            CheckInDate = createdCheckIn.CheckInDate,
            Notes = createdCheckIn.Notes,
        };
    }

    // public static CheckIn ToUpdateEntity(this CreateCheckInDto createdCheckIn, int Id)
    // {
    //     return new()
    //     {
    //         Id = Id,
    //         BinId = createdCheckIn.BinId,
    //         CheckInDate = createdCheckIn.CheckInDate,
    //         Notes = createdCheckIn.Notes,
    //         // CheckInProducts = createdCheckIn.CheckInProducts.Select(product => product.ToEntity()).ToList()
    //     };
    // }


    // public static CheckInProducts ToEntity(this CheckInProductsDetailsDto checkInDetails)
    // {
    //     return new()
    //     {
    //         CheckInId  = checkInDetails.CheckInId,
    //         ReceivedProductId = checkInDetails.ReceivedProductId,
    //         Quantity = checkInDetails.Quantity
    //     };
    // }

    public static CheckInSummaryDto ToCheckInSummaryDto(this CheckIn checkIn)
    {
        return new CheckInSummaryDto(
            checkIn.Id,
            checkIn.CheckInType,
            checkIn.Bins.Select(bins => bins.ToSummaryDto()).ToList(),
            !String.IsNullOrWhiteSpace(Convert.ToString(checkIn.Pallet?.PalletNumber)) ? "Pallet " + checkIn.Pallet!.PalletNumber : "",
            checkIn.ReceivedProducts is null ? [] : checkIn.ReceivedProducts.Select(receivedproducts => receivedproducts.ToReceivedProductSummaryDto()).ToList(),
            checkIn.CheckInDate,
            checkIn.Notes
        );
    }

    public static CheckInDetailsDto ToCheckInDetailsDto(this CheckIn checkIn)
    {
        return new CheckInDetailsDto(
            checkIn.Id,
            checkIn.CheckInType,
            checkIn.Bins.Select(bin => bin.Id).ToList(),
            checkIn.PalletId,
            checkIn.ReceivedProducts.Select(product => product.Id).ToList(),
            checkIn.CheckInDate,
            checkIn.Notes
        );
    }

    public static DisplayCheckInProductsDto ToDisplayCheckinProductsDto(this CheckIn checkIn)
    {
        return new DisplayCheckInProductsDto(
            checkIn.Id,
            checkIn.CheckInType,
            !String.IsNullOrWhiteSpace(Convert.ToString(checkIn.Pallet?.PalletNumber)) ? "Pallet " + checkIn.Pallet!.PalletNumber : "",
            checkIn.ReceivedProducts is null ? [] : checkIn.ReceivedProducts.Select(receivedproducts => receivedproducts.ToCheckedInProductSumamryDto()).ToList(),
            checkIn.CheckInDate,
            checkIn.Notes
        );
    }
    
    public static CheckedInProductSumamryDto ToCheckedInProductSumamryDto(this ReceivedProduct receivedProduct)
    {
        return new CheckedInProductSumamryDto(
            receivedProduct.Id,
            receivedProduct.Product!.Name,
            receivedProduct.Product!.TypeOfPackage,
            receivedProduct.Product!.Measurement,
            receivedProduct.Product!.Weight,
            receivedProduct.Quantity,
            receivedProduct.CBM,
            receivedProduct.TotalWeight,
            receivedProduct.ExpirationDate,
            receivedProduct.Remarks,
            receivedProduct.ContainerName,
            receivedProduct.Pallet is null ? null : receivedProduct.Pallet.PalletNumber.ToString(),
            receivedProduct!.Receiving!.Series,
            receivedProduct!.Receiving!.Shipper
        );
    }

    // public static CheckInProductsSummaryDto ToCheckInProductsSummaryDto(this CheckInProducts checkInProducts)    
    // {
    //     return new CheckInProductsSummaryDto(
    //         checkInProducts.Id,
    //         checkInProducts.CheckInId,
    //         checkInProducts.ReceivedProductId,
    //         checkInProducts.Quantity
    //     );
    // }
}
