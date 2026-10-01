using WMS.Api.Dtos.Incoming;
using WMS.Api.Entities;

namespace WMS.Api.Mapping
{
    public static class IncomingMappings
    {
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

        public static IncomingResponseDto ToResponseDto(
            this Incoming entity,
            List<ReceivedProduct>? receivedProductsList = null)
        {
            var allReceived = receivedProductsList ?? new List<ReceivedProduct>();

            // 1. Group total physical received quantity by ProductId + ExpirationDate
            var receivedPoolBySku = allReceived
                .GroupBy(rp => GetCompositeKey(rp.ProductId, rp.ExpirationDate))
                .ToDictionary(
                    g => g.Key,
                    g => g.Sum(rp => rp.Quantity),
                    StringComparer.OrdinalIgnoreCase
                );

            var productDtos = new List<IncomingProductResponseDto>();

            if (entity.Products != null)
            {
                // Group incoming products by SKU to waterfall calculate remaining balances
                var incomingGroups = entity.Products
                    .GroupBy(p => GetCompositeKey(p.ProductId, p.ExpirationDate))
                    .ToList();

                foreach (var group in incomingGroups)
                {
                    int poolQty = receivedPoolBySku.TryGetValue(group.Key, out int totalRec) ? totalRec : 0;

                    foreach (var p in group)
                    {
                        int allocatedToThisLine = 0;

                        if (poolQty > 0)
                        {
                            // Allocate available stock to this line, then spill surplus to the next line
                            allocatedToThisLine = Math.Min(p.Quantity, poolQty);
                            poolQty -= allocatedToThisLine;
                        }
                        else if (p.Status == IncomingProductStatus.RECEIVED)
                        {
                            allocatedToThisLine = p.Quantity;
                        }

                        int remaining = Math.Max(0, p.Quantity - allocatedToThisLine);

                        productDtos.Add(new IncomingProductResponseDto
                        {
                            Id = p.Id,
                            ProductId = p.ProductId,
                            ProductName = p.Product?.Name ?? $"Product #{p.ProductId}",
                            Code = p.Product?.Code,
                            UnitPrice = p.UnitPrice,
                            TotalAmount = p.TotalAmount,
                            Quantity = p.Quantity,
                            ReceivedQuantity = allocatedToThisLine,
                            RemainingQuantity = remaining,
                            CBM = p.CBM,
                            TotalWeight = p.TotalWeight,
                            TypeOfPackage = p.Product?.TypeOfPackage,
                            ExpirationDate = p.ExpirationDate,
                            Supplier = p.Supplier,
                            Status = p.Status,
                            DateAdded = p.DateAdded,
                            Remarks = p.Remarks
                        });
                    }
                }
            }

            return new IncomingResponseDto
            {
                Id = entity.Id,
                WarehouseId = entity.WarehouseId,
                WarehouseName = entity.Warehouse?.Name,
                Shipper = entity.Shipper,
                Consignee = entity.Consignee,
                Status = entity.Status,
                Products = productDtos
            };
        }

        private static string GetCompositeKey(int productId, DateOnly? exp)
        {
            string expKey = exp?.ToString("yyyy-MM-dd") ?? "NONE";
            return $"{productId}_{expKey}";
        }
    }
}