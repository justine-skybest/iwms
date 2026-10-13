using System;
using System.Linq;
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
            Products = dto.Products?.Select(product => product.ToReceiveProductEntity()).ToList() ?? new(),
            PlateNumber = dto.PlateNumber,
            DriverName = dto.DriverName,
            DateTime = dto.DateTime,
            ClientRepresentative = dto.ClientRepresentative,
            CheckerName = dto.CheckerName,
            TimeStart = dto.TimeStart,
            TimeEnd = dto.TimeEnd,
            DateAdded = dto.DateAdded
        };
    }

    public static ReceivedProduct ToReceiveProductEntity(this ReceivedProductDetailsDto dto)
    {
        return new ReceivedProduct
        {
            Id = dto.Id,
            ProductId = dto.ProductId,
            IncomingProductId = dto.Status == ReceivedItemStatus.Unlisted_PendingPL ? null : dto.IncomingProductId,
            Status = dto.Status,

            // ✅ MAP EXCEPTION & PHOTOS DTO -> ENTITY
            ExceptionRecord = dto.ExceptionRecord == null ? null : new ReceivingException
            {
                Reason = dto.ExceptionRecord.Reason,
                DeliveryReceiptReference = dto.ExceptionRecord.DeliveryReceiptReference,
                ApprovedBy = dto.ExceptionRecord.ApprovedBy,
                Notes = dto.ExceptionRecord.Notes,
                CreatedAt = dto.ExceptionRecord.CreatedAt != default ? dto.ExceptionRecord.CreatedAt : DateTime.UtcNow,
                Photos = dto.ExceptionRecord.Photos?.Select(url => new ExceptionPhoto
                {
                    PhotoUrl = url,
                    UploadedAt = DateTime.UtcNow
                }).ToList() ?? new()
            },

            // Baseline Expected Fields
            ExpectedProductName = dto.ExpectedProductName,
            ExpectedQuantity = dto.ExpectedQuantity,
            ExpectedCBM = dto.ExpectedCBM,
            ExpectedTotalWeight = dto.ExpectedTotalWeight,
            ExpectedExpirationDate = dto.ExpectedExpirationDate,

            // Actual Counted / Received Fields
            Quantity = dto.Quantity,
            CBM = dto.CBM,
            TotalAmount = dto.TotalAmount,
            UnitPrice = dto.UnitPrice,
            ExpirationDate = dto.ExpirationDate,
            LotNumber = dto.LotNumber,
            TypeOfPackage = dto.TypeOfPackage,
            Supplier = dto.Supplier,
            Remarks = dto.Remarks,
            ContainerName = dto.ContainerName ?? string.Empty,
            PalletId = dto.PalletId
        };
    }

    public static Receiving ToUpdateEntity(this CreateReceivingDto createdReceive, int id)
    {
        return new()
        {
            Id = id,
            WarehouseId = createdReceive.WarehouseId,
            IncomingId = createdReceive.IncomingId,
            Series = createdReceive.Series,
            TransportCompany = createdReceive.TransportCompany,
            Shipper = createdReceive.Shipper,
            Consignee = createdReceive.Consignee,
            DateReceived = createdReceive.DateReceived,
            Reference = createdReceive.Reference,
            Products = createdReceive.Products?.Select(product => product.ToEntity()).ToList() ?? new(),
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

    public static ReceivedProductDetailsDto ToReceivedProductDetailsDto(this ReceivedProduct product)
    {
        return new ReceivedProductDetailsDto
        {
            Id = product.Id,
            ProductId = product.ProductId,
            IncomingProductId = product.IncomingProductId,
            Status = product.Status,

            // ✅ MAP EXCEPTION & PHOTOS ENTITY -> DTO
            ExceptionRecord = product.ExceptionRecord == null ? null : new ReceivingExceptionDetailsDto
            {
                Id = product.ExceptionRecord.Id,
                Reason = product.ExceptionRecord.Reason,
                DeliveryReceiptReference = product.ExceptionRecord.DeliveryReceiptReference,
                ApprovedBy = product.ExceptionRecord.ApprovedBy,
                Notes = product.ExceptionRecord.Notes,
                CreatedAt = product.ExceptionRecord.CreatedAt,
                Photos = product.ExceptionRecord.Photos?.Select(p => p.PhotoUrl).ToList() ?? new()
            },

            ExpectedProductName = product.ExpectedProductName,
            ExpectedQuantity = product.ExpectedQuantity,
            ExpectedCBM = product.ExpectedCBM,
            ExpectedTotalWeight = product.ExpectedTotalWeight,
            ExpectedExpirationDate = product.ExpectedExpirationDate,

            // Actual Counted Fields
            Name = product.Product?.Name ?? product.ExpectedProductName,
            Quantity = product.Quantity,
            CBM = product.CBM ?? 0m,
            Weight = product.Weight ?? 0m,
            TotalAmount = product.TotalAmount ?? 0,
            UnitPrice = product.UnitPrice ?? 0,
            LotNumber = product.LotNumber,
            TypeOfPackage = !string.IsNullOrWhiteSpace(product.TypeOfPackage)
                ? product.TypeOfPackage
                : product.Product?.TypeOfPackage,

            ExpirationDate = product.ExpirationDate,
            Supplier = product.Supplier,
            Remarks = product.Remarks,
            ContainerName = product.ContainerName,
            PalletId = product.PalletId
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