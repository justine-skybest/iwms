using System;
using WMS.Api.Dtos.Receiving;
using WMS.Api.Entities;

namespace WMS.Api.Mapping;

public static class ReceivingMapping
{
    public static Receiving ToEntity(this CreateReceivingDto dto)
    {
        return new Receiving
        {
            WarehouseId = dto.WarehouseId,
            IncomingId = dto.IncomingId,
            Series = dto.Series,
            TransportCompany = dto.TransportCompany,
            Shipper = dto.Shipper,
            Consignee = dto.Consignee,
            DateReceived = dto.DateReceived,
            Reference = dto.Reference,
            PlateNumber = dto.PlateNumber,
            DriverName = dto.DriverName,
            DateTime = dto.DateTime,
            ClientRepresentative = dto.ClientRepresentative,
            CheckerName = dto.CheckerName,
            TimeStart = dto.TimeStart,
            TimeEnd = dto.TimeEnd,
            DateAdded = dto.DateAdded,
            Products = dto.Products?.Select(p => p.ToEntity()).ToList() ?? new()
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

    public static ReceivedProduct ToEntity(this ReceivedProductDetailsDto dto)
    {
        return new ReceivedProduct
        {
            Id = dto.Id,
            ProductId = dto.ProductId,

            // Baseline Expected Fields (From Incoming)
            ExpectedProductName = dto.ExpectedProductName,
            ExpectedQuantity = dto.ExpectedQuantity,
            ExpectedCBM = dto.ExpectedCBM,
            ExpectedTotalWeight = dto.ExpectedTotalWeight,
            ExpectedExpirationDate = dto.ExpectedExpirationDate,

            // Actual Counted / Received Fields
            Quantity = dto.Quantity,
            CBM = dto.CBM ?? "0",
            TotalWeight = dto.TotalWeight ?? "0",
            ExpirationDate = dto.ExpirationDate,

            Supplier = dto.Supplier,
            Remarks = dto.Remarks,
            ContainerName = dto.ContainerName ?? string.Empty,
            PalletId = dto.PalletId
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

    public static ReceivedProductSummaryDto ToReceivedProductSummaryDto(this ReceivedProduct rp)
    {
        return new ReceivedProductSummaryDto(
            rp.Id,
            rp.ProductId,
            rp.Product?.Name ?? rp.ExpectedProductName ?? string.Empty,
            rp.Product?.TypeOfPackage ?? string.Empty,
            rp.Product?.Measurement ?? string.Empty,
            rp.Product?.Weight ?? 0m,

            // Baseline Expected Fields (From Incoming)
            rp.ExpectedProductName,
            rp.ExpectedQuantity,
            rp.ExpectedCBM,
            rp.ExpectedTotalWeight,
            rp.ExpectedExpirationDate,

            // Actual Counted / Received Fields
            rp.Quantity,
            rp.CBM,
            rp.TotalWeight,
            rp.ExpirationDate,
            rp.Remarks ?? string.Empty,
            rp.ContainerName,
            rp.PalletId
        );
    }

    public static ReceivingDetailsDto ToReceivingDetailsDto(this Receiving entity)
    {
        return new ReceivingDetailsDto(
            Id: entity.Id,
            WarehouseId: entity.WarehouseId,
            IncomingId: entity.IncomingId,
            Series: entity.Series,
            TransportCompany: entity.TransportCompany,
            Shipper: entity.Shipper,
            Consignee: entity.Consignee ?? string.Empty,
            DateReceived: entity.DateReceived,
            Reference: entity.Reference,
            Products: entity.Products?.Select(p => p.ToReceivedProductDetailsDto()).ToList() ?? new(),
            PlateNumber: entity.PlateNumber,
            DriverName: entity.DriverName,
            DateTime: entity.DateTime,
            ClientRepresentative: entity.ClientRepresentative ?? string.Empty,
            CheckerName: entity.CheckerName ?? string.Empty,
            TimeStart: entity.TimeStart,
            TimeEnd: entity.TimeEnd
        );
    }

    public static ReceivedProductDetailsDto ToReceivedProductDetailsDto(this ReceivedProduct entity)
    {
        return new ReceivedProductDetailsDto
        {
            Id = entity.Id,
            ProductId = entity.ProductId,

            // Baseline Expected Fields
            ExpectedProductName = entity.ExpectedProductName,
            ExpectedQuantity = entity.ExpectedQuantity,
            ExpectedCBM = entity.ExpectedCBM,
            ExpectedTotalWeight = entity.ExpectedTotalWeight,
            ExpectedExpirationDate = entity.ExpectedExpirationDate,

            // Actual Counted Fields
            ProductName = entity.Product?.Name ?? entity.ExpectedProductName,
            Quantity = entity.Quantity,
            CBM = entity.CBM,
            TotalWeight = entity.TotalWeight,
            ExpirationDate = entity.ExpirationDate,

            Supplier = entity.Supplier,
            Remarks = entity.Remarks,
            ContainerName = entity.ContainerName,
            PalletId = entity.PalletId
        };
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
            receivedProduct.Remarks!,
            receivedProduct.ContainerName,
            receivedProduct.ReceivingId,
            receivedProduct.Receiving!.Series
        );        
    }
}
