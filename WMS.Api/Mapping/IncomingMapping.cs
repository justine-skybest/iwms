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

            // Create a local pool so we can deduct quantities cleanly without mutating original entities
            var unallocatedPool = allReceived
                .Select(rp => new LocalReceivedPoolItem
                {
                    IncomingProductId = rp.IncomingProductId,
                    ProductId = rp.ProductId,
                    ExpirationDate = rp.ExpirationDate,
                    Quantity = rp.Quantity
                })
                .ToList();

            var productDtos = new List<IncomingProductResponseDto>();

            if (entity.Products != null)
            {
                foreach (var p in entity.Products)
                {
                    int allocatedToThisLine = 0;

                    // Priority 1: Match directly by IncomingProductId
                    allocatedToThisLine += DeductFromPool(
                        unallocatedPool,
                        item => item.IncomingProductId.HasValue && item.IncomingProductId.Value == p.Id,
                        p.Quantity - allocatedToThisLine
                    );

                    // Priority 2: Match by ProductId AND ExpirationDate
                    if (allocatedToThisLine < p.Quantity)
                    {
                        string targetExpKey = FormatDateKey(p.ExpirationDate);
                        allocatedToThisLine += DeductFromPool(
                            unallocatedPool,
                            item => item.ProductId == p.ProductId && FormatDateKey(item.ExpirationDate) == targetExpKey,
                            p.Quantity - allocatedToThisLine
                        );
                    }

                    // Priority 3: Fallback match by ProductId alone (when exp date was added/changed during receiving)
                    if (allocatedToThisLine < p.Quantity)
                    {
                        allocatedToThisLine += DeductFromPool(
                            unallocatedPool,
                            item => item.ProductId == p.ProductId,
                            p.Quantity - allocatedToThisLine
                        );
                    }

                    // Legacy fallback if marked RECEIVED without explicit received records
                    if (allocatedToThisLine == 0 && p.Status == IncomingProductStatus.RECEIVED)
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

        private class LocalReceivedPoolItem
        {
            public int? IncomingProductId { get; set; }
            public int ProductId { get; set; }
            public object? ExpirationDate { get; set; }
            public int Quantity { get; set; }
        }

        private static int DeductFromPool(
            List<LocalReceivedPoolItem> pool,
            Func<LocalReceivedPoolItem, bool> predicate,
            int maxToTake)
        {
            if (maxToTake <= 0) return 0;

            int totalAllocated = 0;
            var matches = pool.Where(predicate).ToList();

            foreach (var item in matches)
            {
                int needed = maxToTake - totalAllocated;
                if (needed <= 0) break;

                int take = Math.Min(item.Quantity, needed);
                totalAllocated += take;
                item.Quantity -= take;

                if (item.Quantity <= 0)
                {
                    pool.Remove(item);
                }
            }

            return totalAllocated;
        }

        private static string FormatDateKey(object? date) => date switch
        {
            DateOnly d => d.ToString("yyyy-MM-dd"),
            DateTime dt => dt.ToString("yyyy-MM-dd"),
            string s when DateTime.TryParse(s, out var dt) => dt.ToString("yyyy-MM-dd"),
            _ => "NONE"
        };
    }
}