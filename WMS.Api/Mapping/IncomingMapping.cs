using WMS.Api.Dtos.Incoming;
using WMS.Api.Entities;

namespace WMS.Api.Mapping
{
    public static class IncomingMappings
    {
        // Request DTO -> Entity
        public static Incoming ToEntity(this IncomingRequestDto dto)
        {
            return new Incoming
            {
                WarehouseId = dto.WarehouseId,
                Shipper = dto.Shipper,
                Consignee = dto.Consignee,
                Status = dto.Status,
                Products = dto.Products.Select(p => p.ToEntity()).ToList()
            };
        }

        public static IncomingProduct ToEntity(this IncomingProductRequestDto dto)
        {
            return new IncomingProduct
            {
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                CBM = dto.CBM,
                TotalWeight = dto.TotalWeight,
                ExpirationDate = dto.ExpirationDate,
                Remarks = dto.Remarks
            };
        }

        // Entity -> Response DTO
        public static IncomingResponseDto ToResponseDto(this Incoming entity)
        {
            return new IncomingResponseDto
            {
                Id = entity.Id,
                WarehouseId = entity.WarehouseId,
                WarehouseName = entity.Warehouse?.Name,
                Shipper = entity.Shipper,
                Consignee = entity.Consignee,
                Status = entity.Status,
                Products = entity.Products?.Select(p => p.ToResponseDto()).ToList() ?? new()
            };
        }

        public static IncomingProductResponseDto ToResponseDto(this IncomingProduct entity)
        {
            return new IncomingProductResponseDto
            {
                Id = entity.Id,
                ProductId = entity.ProductId,
                ProductName = entity.Product?.Name,
                Code = entity.Product?.Code!,
                UnitPrice = entity.UnitPrice!,
                TotalAmount = entity.TotalAmount,
                Quantity = entity.Quantity,
                CBM = entity.CBM,
                TotalWeight = entity.TotalWeight,
                ExpirationDate = entity.ExpirationDate,
                Supplier = entity.Supplier,
                Remarks = entity.Remarks
            };
        }
    }
}
