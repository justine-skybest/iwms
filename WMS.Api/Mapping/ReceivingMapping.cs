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
        return new()
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
            IncomingProductId = dto.IncomingProductId, // ✅ Map IncomingProductId

            // Baseline Expected Fields
            ExpectedProductName = dto.ExpectedProductName,
            ExpectedQuantity = dto.ExpectedQuantity,
            ExpectedCBM = dto.ExpectedCBM,
            ExpectedTotalWeight = dto.ExpectedTotalWeight,
            ExpectedExpirationDate = dto.ExpectedExpirationDate,

            // Actual Counted Fields
            Quantity = dto.Quantity,
            CBM = dto.CBM,
            Weight = dto.Weight,
            ExpirationDate = dto.ExpirationDate,
            LotNumber = dto.LotNumber,
            TypeOfPackage = dto.TypeOfPackage,
            Supplier = dto.Supplier,
            Remarks = dto.Remarks,
            ContainerName = dto.ContainerName ?? string.Empty,
            TotalAmount = dto.TotalAmount,
            UnitPrice = dto.UnitPrice,
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
            rp.LotNumber!,
            !string.IsNullOrWhiteSpace(rp.TypeOfPackage) ? rp.TypeOfPackage : (rp.Product?.TypeOfPackage ?? string.Empty),
            rp.Product?.Measurement ?? string.Empty,
            rp.Weight ?? 0m,

            // Baseline Expected Fields
            rp.ExpectedProductName,
            rp.ExpectedQuantity,
            rp.ExpectedCBM ?? 0m,
            rp.ExpectedTotalWeight,
            rp.ExpectedExpirationDate,

            // Actual Counted / Received Fields
            rp.Quantity,
            rp.CBM ?? 0m,
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
            IncomingProductId = entity.IncomingProductId, // ✅ Map IncomingProductId

            // Baseline Expected Fields
            ExpectedProductName = entity.ExpectedProductName ?? entity.Product?.Name,
            ExpectedQuantity = entity.ExpectedQuantity ?? 0,
            ExpectedCBM = entity.ExpectedCBM ?? entity.CBM,
            ExpectedTotalWeight = entity.ExpectedTotalWeight ?? entity.TotalWeight,
            ExpectedExpirationDate = entity.ExpectedExpirationDate ?? entity.ExpirationDate,

            // Actual Counted Fields
            Name = entity.Product?.Name ?? entity.ExpectedProductName,
            Quantity = entity.Quantity,
            CBM = entity.CBM ?? 0m,
            Weight = entity.Weight ?? 0m,
            TotalAmount = entity.TotalAmount ?? 0,
            UnitPrice = entity.UnitPrice ?? 0,
            LotNumber = entity.LotNumber,
            TypeOfPackage = !string.IsNullOrWhiteSpace(entity.TypeOfPackage)
                ? entity.TypeOfPackage
                : entity.Product?.TypeOfPackage,

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
            receivedProduct.Weight ?? 0m,
            receivedProduct.Quantity,
            receivedProduct.CBM ?? 0m,
            receivedProduct.TotalWeight,
            receivedProduct.ExpirationDate,
            receivedProduct.Remarks!,
            receivedProduct.ContainerName,
            receivedProduct.ReceivingId,
            receivedProduct.Receiving!.Series
        );
    }
}