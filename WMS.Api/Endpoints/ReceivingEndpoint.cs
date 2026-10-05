using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Dtos;
using WMS.Api.Dtos.Receiving;
using WMS.Api.Entities;
using WMS.Api.Helpers;
using WMS.Api.Hubs;
using WMS.Api.Mapping;
using WMS.Api.Services;

namespace WMS.Api.Endpoints;

public static class ReceivingEndpoint
{
    const string GetReceivingEndpoint = "GetReceiving";

    public static RouteGroupBuilder MapReceivingEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("receiving").WithTags("Receiving").WithParameterValidation();

        // -----------------------------------------------------------------------------
        // GET / (v1)
        // -----------------------------------------------------------------------------
        group.MapGet("/", async (WMSContext dbContext) =>
            await dbContext.Receivings
                   .Include(receiving => receiving.Products!)
                       .ThenInclude(receivedProduct => receivedProduct.Product)
                   .Include(receiving => receiving.Products!)
                       .ThenInclude(receivedProduct => receivedProduct.Pallet)
                   .Include(receiving => receiving.Warehouse)
                  .Select(receiving => receiving.ToReceivingSummaryDto())
                  .AsNoTracking()
                  .ToListAsync()
        );

        // -----------------------------------------------------------------------------
        // GET /v2?search=&page=&pageSize=
        // -----------------------------------------------------------------------------
        group.MapGet("/v2", async (
            WMSContext dbContext,
            string? search = null,
            int? warehouseId = null,
            int page = 1,
            int pageSize = 50,
            CancellationToken cancellationToken = default) =>
        {
            const int maxPageSize = 500;

            page = Math.Max(page, 1);
            pageSize = Math.Clamp(pageSize, 1, maxPageSize);

            var query = dbContext.Receivings
                .Include(receiving => receiving.Products!)
                    .ThenInclude(receivedProduct => receivedProduct.Product)
                .Include(receiving => receiving.Products!)
                    .ThenInclude(receivedProduct => receivedProduct.Pallet)
                .Include(receiving => receiving.Warehouse)
                .AsNoTracking();

            if (warehouseId.HasValue)
            {
                query = query.Where(receiving => receiving.WarehouseId == warehouseId.Value);
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(receiving =>
                    receiving.Series.Contains(search) ||
                    (receiving.Warehouse != null && receiving.Warehouse.Name.Contains(search)) ||
                    (receiving.Shipper != null && receiving.Shipper.Contains(search)));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var receivings = await query
                .OrderByDescending(receiving => receiving.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            foreach (var r in receivings)
            {
                EnsureExpectedQuantities(r, dbContext);
            }

            var items = receivings
                .Select(receiving => receiving.ToReceivingDetailsDto())
                .ToList();

            var response = new PaginatedResponse<ReceivingDetailsDto>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return Results.Ok(response);
        })
        .Produces<PaginatedResponse<ReceivingDetailsDto>>(StatusCodes.Status200OK);

        group.MapGet("/shippers", async (
            WMSContext dbContext,
            int? warehouseId = null,
            CancellationToken cancellationToken = default) =>
        {
            var query = dbContext.Receivings
                .AsNoTracking()
                .Where(r => !string.IsNullOrWhiteSpace(r.Shipper));

            if (warehouseId.HasValue)
            {
                query = query.Where(r => r.WarehouseId == warehouseId.Value);
            }

            var shippers = await query
                .Select(r => r.Shipper!.Trim())
                .Distinct()
                .OrderBy(s => s)
                .ToListAsync(cancellationToken);

            return Results.Ok(shippers);
        })
        .WithName("GetAllShippersFromReceiving")
        .WithSummary("Get all unique shippers from receiving receipts")
        .Produces<List<string>>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // GET /warehouse/{WarehouseId} (v1)
        // -----------------------------------------------------------------------------
        group.MapGet("/warehouse/{WarehouseId:int}", async (int WarehouseId, WMSContext dbContext) =>
            await dbContext.Receivings
                    .Where(receiving => receiving.WarehouseId == WarehouseId)
                   .Include(receiving => receiving.Products!)
                       .ThenInclude(receivedProduct => receivedProduct.Product)
                   .Include(receiving => receiving.Products!)
                       .ThenInclude(receivedProduct => receivedProduct.Pallet)
                   .Include(receiving => receiving.Warehouse)
                  .Select(receiving => receiving.ToReceivingSummaryDto())
                  .AsNoTracking()
                  .ToListAsync()
        );

        // -----------------------------------------------------------------------------
        // Helper & Single Item Endpoints
        // -----------------------------------------------------------------------------
        group.MapGet("/series", async (WMSContext dbContext) =>
        {
            var twoDigitYear = DateTime.Now.ToString("yy");
            var lastSeries = await dbContext.Receivings
                                 .Where(s => s.Series.StartsWith("SLCWH-") && s.Series.EndsWith($"-{twoDigitYear}"))
                                 .OrderByDescending(s => s.Series)
                                 .Select(s => s.Series)
                                 .FirstOrDefaultAsync();

            return lastSeries is null ? Results.Ok("No series found") : Results.Ok(lastSeries);
        });

        // -----------------------------------------------------------------------------
        // GET /{id:int} - Get receiving transaction details by ID
        // -----------------------------------------------------------------------------
        group.MapGet("/{id:int}", async (
            int id,
            WMSContext dbContext,
            CancellationToken cancellationToken = default) =>
        {
            Receiving? receiving = await dbContext.Receivings
                .Include(receiving => receiving.Products!)
                    .ThenInclude(receivedProduct => receivedProduct.Product)
                .Include(receiving => receiving.Products!)
                    .ThenInclude(receivedProduct => receivedProduct.Pallet)
                .Include(receiving => receiving.Warehouse)
                .AsNoTracking()
                .FirstOrDefaultAsync(result => result.Id == id, cancellationToken);

            if (receiving is null)
            {
                return Results.NotFound(new { Message = $"Receiving receipt #{id} was not found." });
            }

            EnsureExpectedQuantities(receiving, dbContext);

            return Results.Ok(receiving.ToReceivingDetailsDto());
        })
        .WithName(GetReceivingEndpoint)
        .WithSummary("Get receiving transaction details")
        .WithDescription("Retrieves full receiving receipt details by ID, including products, assigned pallets, and warehouse context.")
        .Produces<ReceivingDetailsDto>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound);

        // -----------------------------------------------------------------------------
        // POST / - UPSERT RECEIVING (CREATE OR ACCUMULATE ON EXISTING RECEIPT)
        // -----------------------------------------------------------------------------
        group.MapPost("/", async (
            CreateReceivingDto newReceivingDto,
            WMSContext dbContext,
            IHubContext<NotificationHub, INotificationClient> hubContext,
            IAuditLogService auditLogService,
            CancellationToken cancellationToken) =>
        {
            // 1. Mandatory Incoming Record Lookup
            var incoming = await dbContext.Incomings
                .Include(inc => inc.Products!)
                    .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(inc => inc.Id == newReceivingDto.IncomingId, cancellationToken);

            if (incoming is null)
            {
                return Results.NotFound(new { Message = $"Incoming shipment record #{newReceivingDto.IncomingId} was not found." });
            }

            if (incoming.Status == IncomingStatus.RECEIVED || incoming.Status == IncomingStatus.CLOSED_SHORT)
            {
                return Results.BadRequest(new { Message = $"Incoming shipment #{incoming.Id} is already completed or short-closed." });
            }

            // 2. ALWAYS CREATE A DISTINCT NEW RECEIVING RECORD
            var receiving = newReceivingDto.ToEntity();
            receiving.Series = await GenerateReceivingSeriesAsync(newReceivingDto.IncomingId, dbContext, cancellationToken);
            dbContext.Receivings.Add(receiving);
            await dbContext.SaveChangesAsync(cancellationToken);

            // 3. Generate Lot Numbers for any unassigned products
            int sequenceIndex = 1;
            if (receiving.Products != null && receiving.Products.Count > 0)
            {
                foreach (var product in receiving.Products)
                {
                    product.LotNumber = LotNumberGenerator.Generate(
                        product.LotNumber,
                        receiving.Id,
                        product.ProductId,
                        sequenceIndex++
                    );
                }
            }

            // 4. Recalculate baseline ExpectedQuantities sequentially across pallet line items
            RecalculateExpectedQuantities(receiving, incoming);
            await dbContext.SaveChangesAsync(cancellationToken);

            // 5. UPDATE INCOMING PRODUCTS STATUS & INCOMING OVERALL STATUS (Aggregated across ALL receivings for this shipment)
            var allReceivedProducts = await dbContext.Receivings
                .Where(r => r.IncomingId == incoming.Id)
                .SelectMany(r => r.Products!)
                .ToListAsync(cancellationToken);

            var receivedPool = allReceivedProducts
                .GroupBy(rp => $"{rp.ProductId}_{FormatDateKey(rp.ExpirationDate)}")
                .ToDictionary(
                    g => g.Key,
                    g => g.Sum(p => p.Quantity),
                    StringComparer.OrdinalIgnoreCase
                );

            foreach (var incProduct in incoming.Products!)
            {
                if (incProduct.Status == IncomingProductStatus.CLOSED_SHORT)
                {
                    continue; // Preserve CLOSED_SHORT state
                }

                string key = $"{incProduct.ProductId}_{FormatDateKey(incProduct.ExpirationDate)}";

                int allocatedToThisRow = 0;
                if (receivedPool.TryGetValue(key, out int poolQty) && poolQty > 0)
                {
                    allocatedToThisRow = Math.Min(incProduct.Quantity, poolQty);
                    receivedPool[key] = poolQty - allocatedToThisRow;
                }

                if (allocatedToThisRow <= 0)
                {
                    incProduct.Status = IncomingProductStatus.UNRECEIVED;
                }
                else if (allocatedToThisRow >= incProduct.Quantity)
                {
                    incProduct.Status = IncomingProductStatus.RECEIVED;
                }
                else
                {
                    incProduct.Status = IncomingProductStatus.PARTIAL;
                }
            }

            // Update overall Incoming Shipment Status
            if (incoming.Products.All(p => p.Status == IncomingProductStatus.RECEIVED))
            {
                incoming.Status = IncomingStatus.RECEIVED;
            }
            else if (incoming.Products.All(p => p.Status == IncomingProductStatus.RECEIVED || p.Status == IncomingProductStatus.CLOSED_SHORT))
            {
                incoming.Status = IncomingStatus.CLOSED_SHORT;
            }
            else if (incoming.Products.Any(p => p.Status == IncomingProductStatus.RECEIVED || p.Status == IncomingProductStatus.PARTIAL))
            {
                incoming.Status = IncomingStatus.PARTIAL;
            }
            else
            {
                incoming.Status = IncomingStatus.PENDING;
            }

            await dbContext.SaveChangesAsync(cancellationToken);

            // 6. SignalR Notification
            await hubContext.Clients.All.ReceivingCreated();

            // 7. Return Hydrated Response & Audit Log
            var createdReceiving = await dbContext.Receivings
                .Include(r => r.Warehouse)
                .Include(r => r.Products!)
                    .ThenInclude(p => p.Product)
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == receiving.Id, cancellationToken);

            if (createdReceiving != null)
            {
                RecalculateExpectedQuantities(createdReceiving, incoming);
            }

            var resultDto = (createdReceiving ?? receiving).ToReceivingDetailsDto();

            await auditLogService.LogAsync(
                category: "Receiving",
                action: "Created",
                description: $"Created receiving receipt '{resultDto.Series}' (linked to Incoming ID {incoming.Id}) with {resultDto.Products.Count} line item(s). Overall Incoming status is now '{incoming.Status}'.",
                details: new
                {
                    ReceivingId = resultDto.Id,
                    resultDto.Series,
                    resultDto.Shipper,
                    LinkedIncomingId = incoming.Id,
                    ResultingIncomingStatus = incoming.Status.ToString(),
                    Products = resultDto.Products.Select(p => new
                    {
                        p.Name,
                        p.Quantity,
                        p.LotNumber,
                        Expiration = FormatDateKey(p.ExpirationDate),
                    })
                }
            );

            return Results.CreatedAtRoute(GetReceivingEndpoint, new { id = receiving.Id }, resultDto);
        })
        .WithName("CreateReceiving")
        .WithSummary("Create a new receiving receipt")
        .Produces<ReceivingDetailsDto>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound);

        // -----------------------------------------------------------------------------
        // PUT /{id:int} - Direct Receiving Edit (Update Header & Existing Line Items Only)
        // -----------------------------------------------------------------------------
        // -----------------------------------------------------------------------------
        // PUT /{id:int} - Direct Receiving Edit (Update Header & Existing Line Items Only)
        // -----------------------------------------------------------------------------
        group.MapPut("/{id:int}", async (
            int id,
            CreateReceivingDto updatedReceiving,
            WMSContext dbContext,
            IHubContext<NotificationHub, INotificationClient> hubContext,
            IAuditLogService auditLogService,
            CancellationToken cancellationToken = default) =>
        {
            // 1. Fetch Existing Receiving Record
            var existingReceiving = await dbContext.Receivings
                .Include(receiving => receiving.Products!)
                    .ThenInclude(product => product!.Product)
                .FirstOrDefaultAsync(result => result.Id == id, cancellationToken);

            if (existingReceiving is null)
            {
                return Results.NotFound(new { Message = $"Receiving receipt #{id} was not found." });
            }

            // 2. Fetch Linked Incoming Shipment Directly via Existing Record
            Incoming? incoming = null;
            if (existingReceiving.IncomingId.HasValue)
            {
                incoming = await dbContext.Incomings
                    .Include(inc => inc.Products!)
                        .ThenInclude(p => p.Product)
                    .FirstOrDefaultAsync(inc => inc.Id == existingReceiving.IncomingId.Value, cancellationToken);

                if (incoming != null && incoming.Status == IncomingStatus.CLOSED_SHORT)
                {
                    return Results.BadRequest(new { Message = $"Incoming shipment #{incoming.Id} is short-closed and cannot be modified." });
                }
            }

            // Preserve immutable header fields
            var originalSeries = existingReceiving.Series;
            var originalIncomingId = existingReceiving.IncomingId;

            // 3. Update Header Values (Preserve Original Series & IncomingId)
            dbContext.Entry(existingReceiving).CurrentValues.SetValues(updatedReceiving.ToUpdateEntity(id));
            existingReceiving.Series = originalSeries;         // Series is never allowed to change
            existingReceiving.IncomingId = originalIncomingId; // IncomingId is preserved from existing record

            // 4. Update EXISTING Line Items Only (Preserve Lot Numbers & Disallow Additions)
            if (updatedReceiving.Products != null && existingReceiving.Products != null)
            {
                foreach (var updatedProduct in updatedReceiving.Products)
                {
                    var existingProduct = existingReceiving.Products
                        .FirstOrDefault(p => (updatedProduct.Id > 0 && p.Id == updatedProduct.Id) || p.ProductId == updatedProduct.ProductId);

                    if (existingProduct != null)
                    {
                        existingProduct.Quantity = updatedProduct.Quantity;
                        existingProduct.CBM = updatedProduct.CBM;
                        existingProduct.TotalWeight = updatedProduct.TotalWeight;
                        existingProduct.Remarks = updatedProduct.Remarks;
                        existingProduct.ExpirationDate = updatedProduct.ExpirationDate;
                        existingProduct.ContainerName = updatedProduct.ContainerName;
                        existingProduct.PalletId = updatedProduct.PalletId;
                    }
                }
            }

            await dbContext.SaveChangesAsync(cancellationToken);

            // 5. Recalculate Expected Quantities & Sync Parent Incoming Shipment Statuses
            if (incoming != null)
            {
                RecalculateExpectedQuantities(existingReceiving, incoming);
                await dbContext.SaveChangesAsync(cancellationToken);

                // Re-aggregate received pool across ALL receivings for this shipment
                var allReceivedProducts = await dbContext.Receivings
                    .Where(r => r.IncomingId == incoming.Id)
                    .SelectMany(r => r.Products!)
                    .ToListAsync(cancellationToken);

                var receivedPool = allReceivedProducts
                    .GroupBy(rp => $"{rp.ProductId}_{FormatDateKey(rp.ExpirationDate)}")
                    .ToDictionary(
                        g => g.Key,
                        g => g.Sum(p => p.Quantity),
                        StringComparer.OrdinalIgnoreCase
                    );

                foreach (var incProduct in incoming.Products!)
                {
                    if (incProduct.Status == IncomingProductStatus.CLOSED_SHORT)
                    {
                        continue; // Preserve CLOSED_SHORT state
                    }

                    string key = $"{incProduct.ProductId}_{FormatDateKey(incProduct.ExpirationDate)}";

                    int allocatedToThisRow = 0;
                    if (receivedPool.TryGetValue(key, out int poolQty) && poolQty > 0)
                    {
                        allocatedToThisRow = Math.Min(incProduct.Quantity, poolQty);
                        receivedPool[key] = poolQty - allocatedToThisRow;
                    }

                    if (allocatedToThisRow <= 0)
                    {
                        incProduct.Status = IncomingProductStatus.UNRECEIVED;
                    }
                    else if (allocatedToThisRow >= incProduct.Quantity)
                    {
                        incProduct.Status = IncomingProductStatus.RECEIVED;
                    }
                    else
                    {
                        incProduct.Status = IncomingProductStatus.PARTIAL;
                    }
                }

                // Update overall Incoming Shipment Status
                if (incoming.Products.All(p => p.Status == IncomingProductStatus.RECEIVED))
                {
                    incoming.Status = IncomingStatus.RECEIVED;
                }
                else if (incoming.Products.All(p => p.Status == IncomingProductStatus.RECEIVED || p.Status == IncomingProductStatus.CLOSED_SHORT))
                {
                    incoming.Status = IncomingStatus.CLOSED_SHORT;
                }
                else if (incoming.Products.Any(p => p.Status == IncomingProductStatus.RECEIVED || p.Status == IncomingProductStatus.PARTIAL))
                {
                    incoming.Status = IncomingStatus.PARTIAL;
                }
                else
                {
                    incoming.Status = IncomingStatus.PENDING;
                }

                await dbContext.SaveChangesAsync(cancellationToken);
            }

            // 6. SignalR Notification
            await hubContext.Clients.All.ReceivingUpdated();

            // 7. Audit Logging
            await auditLogService.LogAsync(
                category: "Receiving",
                action: "Updated",
                description: $"Updated receiving receipt '{existingReceiving.Series}' (ID: {id}) containing {existingReceiving.Products.Count} product(s). Overall Incoming status is now '{incoming?.Status}'.",
                details: new
                {
                    ReceivingId = id,
                    Series = existingReceiving.Series,
                    existingReceiving.Shipper,
                    LinkedIncomingId = incoming?.Id,
                    ResultingIncomingStatus = incoming?.Status.ToString(),
                    Products = existingReceiving.Products.Select(p => new
                    {
                        p.ProductId,
                        p.Quantity,
                        p.LotNumber,
                        Expiration = FormatDateKey(p.ExpirationDate)
                    })
                }
            );

            return Results.NoContent();
        })
        .WithName("UpdateReceiving")
        .WithSummary("Update an existing receiving receipt")
        .Produces(StatusCodes.Status204NoContent)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound);

        // -----------------------------------------------------------------------------
        // DELETE /{id:int}
        // -----------------------------------------------------------------------------
        group.MapDelete("/{id:int}", async (
            int id,
            WMSContext dbContext,
            IAuditLogService auditLogService) =>
        {
            var existingReceiving = await dbContext.Receivings
                .Include(receiving => receiving.Products)
                .FirstOrDefaultAsync(receiving => receiving.Id == id);

            if (existingReceiving is null)
            {
                return Results.NotFound();
            }

            var snapshotSeries = existingReceiving.Series;
            var snapshotProductsCount = existingReceiving.Products?.Count ?? 0;

            if (existingReceiving.Products != null)
            {
                dbContext.ReceivedProducts.RemoveRange(existingReceiving.Products);
            }
            dbContext.Receivings.Remove(existingReceiving);

            await dbContext.SaveChangesAsync();

            await auditLogService.LogAsync(
                category: "Receiving",
                action: "Deleted",
                description: $"Deleted receiving receipt '{snapshotSeries}' (ID: {id}) containing {snapshotProductsCount} product(s).",
                details: new
                {
                    DeletedId = id,
                    Series = snapshotSeries,
                    Shipper = existingReceiving.Shipper,
                    TotalProductsRemoved = snapshotProductsCount
                }
            );

            return Results.NoContent();
        });

        return group;
    }

    // -----------------------------------------------------------------------------
    // DATE KEY NORMALIZER HELPER
    // -----------------------------------------------------------------------------
    // Unified helper accepting object? to handle DateOnly?, DateTime?, and null seamlessly
    private static string FormatDateKey(object? date) => date switch
    {
        DateOnly d => d.ToString("yyyy-MM-dd"),
        DateTime dt => dt.ToString("yyyy-MM-dd"),
        string s when DateTime.TryParse(s, out var dt) => dt.ToString("yyyy-MM-dd"),
        _ => "NONE"
    };

    // -----------------------------------------------------------------------------
    // WATERFALL EXPECTED QUANTITY ALLOCATION HELPER (PRESERVES INDIVIDUAL LINE BASELINES)
    // -----------------------------------------------------------------------------
    private static void RecalculateExpectedQuantities(Receiving receiving, Incoming incoming)
    {
        if (receiving.Products == null || incoming.Products == null) return;

        // Group INCOMING products by ProductId + ExpirationDate ordered sequentially
        var incomingGroups = incoming.Products
            .GroupBy(p => $"{p.ProductId}_{FormatDateKey(p.ExpirationDate)}")
            .ToDictionary(
                g => g.Key,
                g => g.OrderBy(p => p.Id).ToList(),
                StringComparer.OrdinalIgnoreCase
            );

        // Group RECEIVED products by ProductId + ExpirationDate
        var receivedGroups = receiving.Products
            .GroupBy(rp => $"{rp.ProductId}_{FormatDateKey(rp.ExpirationDate)}")
            .ToList();

        foreach (var group in receivedGroups)
        {
            if (!incomingGroups.TryGetValue(group.Key, out var incList) || incList.Count == 0)
            {
                continue;
            }

            var receivedItems = group.OrderBy(rp => rp.Id).ToList();

            int incIdx = 0;
            int currentIncRemaining = incList[0].Quantity;

            for (int rIdx = 0; rIdx < receivedItems.Count; rIdx++)
            {
                var rp = receivedItems[rIdx];
                var currentInc = incList[Math.Min(incIdx, incList.Count - 1)];

                // Populate baseline metadata from matching incoming row
                rp.ExpectedCBM = currentInc.CBM;
                rp.ExpectedTotalWeight = currentInc.TotalWeight;
                rp.ExpectedExpirationDate = currentInc.ExpirationDate;
                rp.ExpectedProductName = currentInc.Product?.Name;
                if (string.IsNullOrWhiteSpace(rp.TypeOfPackage))
                {
                    rp.TypeOfPackage = currentInc.Product?.TypeOfPackage;
                }

                int unallocatedPalletQty = rp.Quantity;
                int allocatedExpectedForPallet = 0;

                // Waterfall allocation across multiple planned line items
                while (unallocatedPalletQty > 0 && incIdx < incList.Count)
                {
                    int alloc = Math.Min(unallocatedPalletQty, currentIncRemaining);
                    allocatedExpectedForPallet += alloc;
                    unallocatedPalletQty -= alloc;
                    currentIncRemaining -= alloc;

                    if (currentIncRemaining == 0)
                    {
                        incIdx++;
                        if (incIdx < incList.Count)
                        {
                            currentIncRemaining = incList[incIdx].Quantity;
                        }
                    }
                }

                // Assign allocated baseline expectation
                rp.ExpectedQuantity = allocatedExpectedForPallet > 0 ? allocatedExpectedForPallet : rp.Quantity;
            }
        }
    }

    private static void EnsureExpectedQuantities(Receiving receiving, WMSContext dbContext)
    {
        if (receiving.IncomingId.HasValue && receiving.Products != null && receiving.Products.Count > 0)
        {
            var incoming = dbContext.Incomings
                .Include(inc => inc.Products!)
                    .ThenInclude(p => p.Product)
                .AsNoTracking()
                .FirstOrDefault(inc => inc.Id == receiving.IncomingId.Value);

            if (incoming != null)
            {
                RecalculateExpectedQuantities(receiving, incoming, dbContext);
            }
        }
    }

    private static void RecalculateExpectedQuantities(
       Receiving receiving,
       Incoming incoming,
       WMSContext dbContext)
    {
        if (receiving.Products == null || receiving.Products.Count == 0 || incoming.Products == null)
            return;

        // 1. Fetch all prior receiving receipts for this incoming shipment
        var priorReceivings = dbContext.Receivings
            .AsNoTracking()
            .Include(r => r.Products)
            .Where(r => r.IncomingId == incoming.Id && r.Id < receiving.Id)
            .OrderBy(r => r.Id)
            .ToList();

        var priorReceivedProducts = priorReceivings
            .SelectMany(r => r.Products ?? new List<ReceivedProduct>())
            .ToList();

        // 2. Build an expected pool from ALL Incoming product lines (including duplicates)
        var expectedPool = incoming.Products
            .Select(ip => new LocalExpectedPoolItem
            {
                IncomingProductId = ip.Id,
                ProductId = ip.ProductId,
                ExpirationDate = ip.ExpirationDate,
                RemainingExpected = ip.Quantity
            })
            .ToList();

        // 3. Deduct prior received quantities sequentially across the pool
        foreach (var priorRp in priorReceivedProducts)
        {
            DeductFromExpectedPool(
                expectedPool,
                priorRp.IncomingProductId,
                priorRp.ProductId,
                priorRp.ExpirationDate,
                priorRp.Quantity
            );
        }

        // 4. Assign ExpectedQuantity for each line in the CURRENT receiving receipt
        foreach (var currentRp in receiving.Products)
        {
            int allocatedExpected = DeductFromExpectedPool(
                expectedPool,
                currentRp.IncomingProductId,
                currentRp.ProductId,
                currentRp.ExpirationDate,
                currentRp.Quantity
            );

            currentRp.ExpectedQuantity = allocatedExpected;
        }
    }

    private class LocalExpectedPoolItem
    {
        public int IncomingProductId { get; set; }
        public int ProductId { get; set; }
        public object? ExpirationDate { get; set; }
        public int RemainingExpected { get; set; }
    }

    private static int DeductFromExpectedPool(
        List<LocalExpectedPoolItem> pool,
        int? incomingProductId,
        int productId,
        object? expDate,
        int quantityToDeduct)
    {
        if (quantityToDeduct <= 0) return 0;

        int totalAllocated = 0;

        // Step A: Direct match by IncomingProductId
        if (incomingProductId.HasValue)
        {
            var match = pool.FirstOrDefault(p => p.IncomingProductId == incomingProductId.Value && p.RemainingExpected > 0);
            if (match != null)
            {
                int take = Math.Min(match.RemainingExpected, quantityToDeduct);
                match.RemainingExpected -= take;
                totalAllocated += take;
            }
        }

        // Step B: Match across ALL duplicate lines with ProductId + ExpirationDate
        if (totalAllocated < quantityToDeduct)
        {
            string targetExp = FormatDateKey(expDate);
            var matchingLines = pool
                .Where(p => p.ProductId == productId && FormatDateKey(p.ExpirationDate) == targetExp && p.RemainingExpected > 0)
                .ToList();

            foreach (var match in matchingLines)
            {
                int needed = quantityToDeduct - totalAllocated;
                if (needed <= 0) break;

                int take = Math.Min(match.RemainingExpected, needed);
                match.RemainingExpected -= take;
                totalAllocated += take;
            }
        }

        // Step C: Fallback across ALL duplicate lines with ProductId alone (handles null/added exp dates)
        if (totalAllocated < quantityToDeduct)
        {
            var matchingLines = pool
                .Where(p => p.ProductId == productId && p.RemainingExpected > 0)
                .ToList();

            foreach (var match in matchingLines)
            {
                int needed = quantityToDeduct - totalAllocated;
                if (needed <= 0) break;

                int take = Math.Min(match.RemainingExpected, needed);
                match.RemainingExpected -= take;
                totalAllocated += take;
            }
        }

        return totalAllocated;
    }

    private static async Task<string> GenerateReceivingSeriesAsync(
        int? incomingId,
        WMSContext dbContext,
        CancellationToken cancellationToken)
    {
        var currentYearSuffix = DateTime.Now.ToString("yy");

        // ✅ Corrected: Pass "D5" inside ToString()
        var formattedId = incomingId?.ToString("D5");
        var baseSeries = $"SLCWH-INC{formattedId}-{currentYearSuffix}";

        // Count existing receiving receipts for this incoming shipment
        var existingCount = await dbContext.Receivings
            .CountAsync(r => r.IncomingId == incomingId, cancellationToken);

        // First receipt: "SLCWH-INC00012-26"
        // Subsequent receipts: "SLCWH-INC00012-26-R2", "SLCWH-INC00012-26-R3"
        return existingCount == 0
            ? baseSeries
            : $"{baseSeries}-R{existingCount + 1}";
    }
}