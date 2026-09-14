using System;
using WMS.Api.Dtos.Receiving;
using WMS.Api.Entities;

namespace WMS.Api.Mapping;

public static class ReceivingMapping
{
    public static Receiving ToEntity(this CreateReceivingDto createdReceive)
    {
        return new ()
        {
            WarehouseId = createdReceive.WarehouseId,
            Series = createdReceive.Series,
            TransportCompany = createdReceive.TransportCompany,
            Shipper = createdReceive.Shipper,
            Consignee = createdReceive.Consignee,
            DateReceived = createdReceive.DateReceived,
            Reference = createdReceive.Reference,
            Products = createdReceive.Products.Select(product => product.ToEntity()).ToList(),
            PlateNumber = createdReceive.PlateNumber,
            DriverName = createdReceive.DriverName,
            DateTime = createdReceive.DateTime,
            ClientRepresentative = createdReceive.ClientRepresentative,
            CheckerName = createdReceive.CheckerName,
            TimeStart = createdReceive.TimeStart,
            TimeEnd = createdReceive.TimeEnd,
            DateAdded = createdReceive.DateAdded        
        };
    }

    public static Receiving ToUpdateEntity(this CreateReceivingDto createdReceive, int id)
    {
        return new ()
        {
            Id = id,
            WarehouseId = createdReceive.WarehouseId,
            Series = createdReceive.Series,
            TransportCompany = createdReceive.TransportCompany,
            Shipper = createdReceive.Shipper,
            Consignee = createdReceive.Consignee,
            DateReceived = createdReceive.DateReceived,
            Reference = createdReceive.Reference,
            Products = createdReceive.Products.Select(product => product.ToEntity()).ToList(),
            PlateNumber = createdReceive.PlateNumber,
            DriverName = createdReceive.DriverName,
            DateTime = createdReceive.DateTime,
            ClientRepresentative = createdReceive.ClientRepresentative,
            CheckerName = createdReceive.CheckerName,
            TimeStart = createdReceive.TimeStart,
            TimeEnd = createdReceive.TimeEnd,
            DateAdded = createdReceive.DateAdded        
        };
    }

    public static ReceivedProduct ToEntity(this ReceivedProductDetailsDto  receivedDetails)
    {
        return new(){
            ProductId = receivedDetails.ProductId,
            Quantity = receivedDetails.Quantity,
            CBM = receivedDetails.CBM,
            TotalWeight = receivedDetails.TotalWeight,
            ExpirationDate = receivedDetails.ExpirationDate,
            Remarks = receivedDetails.Remarks,
            ContainerName = receivedDetails.ContainerName,
            PalletId = receivedDetails.PalletId
        };
    }

    public static ReceivingSummaryDto ToReceivingSummaryDto(this Receiving receiving)
    {
        return new ReceivingSummaryDto( 
            receiving.Id,
            receiving.WarehouseId,
            receiving.Warehouse!.Name,
            receiving.Series,
            receiving.TransportCompany,
            receiving.Shipper,
            receiving.Consignee!,
            receiving.DateReceived,
            receiving.Reference,
            receiving.Products!.Select(product => product.ToReceivedProductSummaryDto()).ToList(),
            receiving.PlateNumber,
            receiving.DriverName,
            receiving.DateTime,
            receiving.ClientRepresentative!,
            receiving.CheckerName!,
            receiving.TimeStart,
            receiving.TimeEnd,
            receiving.DateAdded
        );
    }

    public static ReceivedProductSummaryDto ToReceivedProductSummaryDto(this ReceivedProduct receivedProduct)
    {
        return new ReceivedProductSummaryDto(
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
            receivedProduct.Pallet is null ? null : receivedProduct.Pallet.PalletNumber.ToString()
        );
    }

    public static ReceivingDetailsDto ToReceivingDetailsDto(this Receiving receiving)
    {
        return new( 
            receiving.Id,
            receiving.WarehouseId,
            receiving.Series,
            receiving.TransportCompany,
            receiving.Shipper,
            receiving.Consignee!,
            receiving.DateReceived,
            receiving.Reference,
            receiving.Products!.Select(product => product.ToReceivedProductDetailsDto()).ToList(),
            receiving.PlateNumber,
            receiving.DriverName,
            receiving.DateTime,
            receiving.ClientRepresentative!,
            receiving.CheckerName!,
            receiving.TimeStart,
            receiving.TimeEnd
        );
    }
    
    public static ReceivedProductDetailsDto ToReceivedProductDetailsDto(this ReceivedProduct receivedProduct)
    {
        return new ReceivedProductDetailsDto(
            receivedProduct.Id,
            receivedProduct.ProductId,
            receivedProduct.Quantity,
            receivedProduct.CBM,
            receivedProduct.TotalWeight,
            receivedProduct.ExpirationDate,
            receivedProduct.Remarks,
            receivedProduct.ContainerName,
            receivedProduct.PalletId
        );
    }     

    public static ReceivingSeriesDto ToReceivingSeriesDto(this Receiving receiving)
    {
        return new(
            receiving.Series
        );
    }

    public static ToCheckInProducts ToReceivedProductDTO(this ReceivedProduct receivedProduct)
    {
        return new(
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
            receivedProduct.ReceivingId,
            receivedProduct.Receiving!.Series
        );        
    }
}
