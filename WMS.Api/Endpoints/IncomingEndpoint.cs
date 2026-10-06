using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Dtos.Incoming;
using WMS.Api.Entities;
using WMS.Api.Mapping;
using WMS.Api.Services;

namespace WMS.Api.Endpoints
{
    public static class IncomingEndpoint
    {
        public static RouteGroupBuilder MapIncomingEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("incoming")
                .WithTags("Incomings")
                .WithParameterValidation();

            // -----------------------------------------------------------------------------
            // GET / - Paginated Incomings
            // -----------------------------------------------------------------------------
            group.MapGet("/", async (
                WMSContext dbContext,
                string? search = null,
                int? warehouseId = null,
                IncomingStatus? status = null,
                int page = 1,
                int pageSize = 50,
                CancellationToken cancellationToken = default) =>
            {
                const int maxPageSize = 500;

                page = Math.Max(page, 1);
                pageSize = Math.Clamp(pageSize, 1, maxPageSize);

                var query = dbContext.Incomings
                    .Include(inc => inc.Products!)
                        .ThenInclude(p => p.Product)
                    .Include(inc => inc.Warehouse)
                    .AsNoTracking();

                if (warehouseId.HasValue)
                {
                    query = query.Where(inc => inc.WarehouseId == warehouseId.Value);
                }

                if (status.HasValue)
                {
                    query = query.Where(inc => inc.Status == status.Value);
                }

                if (!string.IsNullOrWhiteSpace(search))
                {
                    query = query.Where(inc =>
                        (inc.Shipper != null && inc.Shipper.Contains(search)) ||
                        (inc.Consignee != null && inc.Consignee.Contains(search)) ||
                        (inc.Warehouse != null && inc.Warehouse.Name.Contains(search)));
                }

                var totalCount = await query.CountAsync(cancellationToken);

                var incomings = await query
                    .OrderByDescending(inc => inc.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync(cancellationToken);

                // Fetch linked Receivings to calculate already-received quantities
                var incomingIds = incomings.Select(i => i.Id).ToList();
                var existingReceivings = await dbContext.Receivings
                    .Include(r => r.Products)
                    .Where(r => r.IncomingId.HasValue && incomingIds.Contains(r.IncomingId.Value))
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

                // Map strongly-typed DTOs with calculated Received and Remaining balances
                var items = incomings.Select(inc =>
                {
                    var linkedProducts = existingReceivings
                        .Where(r => r.IncomingId == inc.Id)
                        .SelectMany(r => r.Products ?? new List<ReceivedProduct>())
                        .ToList();

                    return inc.ToResponseDto(linkedProducts);
                }).ToList();

                var response = new PaginatedResponse<IncomingResponseDto>
                {
                    Items = items,
                    Page = page,
                    PageSize = pageSize,
                    TotalCount = totalCount,
                    TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
                };

                return Results.Ok(response);
            })
            .WithName("GetIncomings")
            .WithSummary("Get paginated incoming shipments")
            .WithDescription("Retrieves a paginated list of incoming shipments with optional filtering by warehouse, status, and search terms.")
            .Produces<PaginatedResponse<IncomingResponseDto>>(StatusCodes.Status200OK);

            // -----------------------------------------------------------------------------
            // GET /unreceived - Pending or Partial Incomings containing UNRECEIVED products
            // -----------------------------------------------------------------------------
            group.MapGet("/unreceived", async (
               WMSContext dbContext,
               string? search = null,
               int? warehouseId = null,
               int page = 1,
               int pageSize = 15,
               CancellationToken cancellationToken = default) =>
            {
                var query = dbContext.Incomings
                    .Where(inc => inc.Status != IncomingStatus.RECEIVED && inc.Status != IncomingStatus.CLOSED_SHORT)
                    .Include(inc => inc.Products!)
                        .ThenInclude(p => p.Product)
                    .Include(inc => inc.Warehouse)
                    .AsNoTracking();

                if (warehouseId.HasValue)
                {
                    query = query.Where(inc => inc.WarehouseId == warehouseId.Value);
                }

                if (!string.IsNullOrWhiteSpace(search))
                {
                    query = query.Where(inc =>
                        (inc.Shipper != null && inc.Shipper.Contains(search)) ||
                        (inc.Consignee != null && inc.Consignee.Contains(search)) ||
                        (inc.Warehouse != null && inc.Warehouse.Name.Contains(search)));
                }

                var totalCount = await query.CountAsync(cancellationToken);

                var incomings = await query
                    .OrderByDescending(inc => inc.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync(cancellationToken);

                // ✅ Fetch all linked received products for these incoming shipments
                var incomingIds = incomings.Select(i => i.Id).ToList();
                var existingReceivings = await dbContext.Receivings
                    .Include(r => r.Products)
                    .Where(r => r.IncomingId.HasValue && incomingIds.Contains(r.IncomingId.Value))
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

                // ✅ Map response DTOs with hydrated ReceivedProduct history
                var items = incomings.Select(inc =>
                {
                    var linkedProducts = existingReceivings
                        .Where(r => r.IncomingId == inc.Id)
                        .SelectMany(r => r.Products ?? new List<ReceivedProduct>())
                        .ToList();

                    return inc.ToResponseDto(linkedProducts);
                }).ToList();

                var response = new PaginatedResponse<IncomingResponseDto>
                {
                    Items = items,
                    Page = page,
                    PageSize = pageSize,
                    TotalCount = totalCount,
                    TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
                };

                return Results.Ok(response);
            })
            .WithName("GetUnreceivedIncomings")
            .WithSummary("Get pending or partial incoming shipments with unreceived or partial products")
            .WithDescription("Retrieves a paginated list of incoming shipments with status PENDING or PARTIAL, including calculated remaining balances.")
            .Produces<PaginatedResponse<IncomingResponseDto>>(StatusCodes.Status200OK);

            // -----------------------------------------------------------------------------
            // GET /unreceived/{id:int} - Get unreceived or partial incoming shipment by ID
            // -----------------------------------------------------------------------------
            group.MapGet("/unreceived/{id:int}", async (
                int id,
                WMSContext dbContext,
                CancellationToken cancellationToken = default) =>
            {
                // 1. Fetch Incoming shipment record with line items and warehouse details
                var incoming = await dbContext.Incomings
                    .Where(inc => inc.Status != IncomingStatus.RECEIVED && inc.Status != IncomingStatus.CLOSED_SHORT)
                    .Include(inc => inc.Warehouse)
                    .Include(inc => inc.Products!)
                        .ThenInclude(p => p.Product)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(inc => inc.Id == id, cancellationToken);

                if (incoming is null)
                {
                    return Results.NotFound(new { Message = $"Unreceived incoming shipment record #{id} was not found or is already completed/closed." });
                }

                // 2. Fetch all linked received products across prior receipts (matching GET /unreceived pattern)
                var existingReceivings = await dbContext.Receivings
                    .Include(r => r.Products)
                    .Where(r => r.IncomingId.HasValue && r.IncomingId.Value == id)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

                var linkedProducts = existingReceivings
                    .SelectMany(r => r.Products ?? new List<ReceivedProduct>())
                    .ToList();

                // 3. Reconcile remaining line item balances via ToResponseDto waterfall pool
                var responseDto = incoming.ToResponseDto(linkedProducts);

                // 4. Verify dynamically calculated status isn't fully RECEIVED or CLOSED_SHORT
                if (responseDto.Status == IncomingStatus.RECEIVED || responseDto.Status == IncomingStatus.CLOSED_SHORT)
                {
                    return Results.NotFound(new { Message = $"Incoming shipment record #{id} has been fully received or closed." });
                }

                return Results.Ok(responseDto);
            })
            .WithName("GetUnreceivedIncomingById")
            .WithSummary("Get pending or partial incoming shipment details by ID")
            .WithDescription("Retrieves detailed information for a specific unreceived or partial incoming shipment, including dynamically calculated received and remaining product balances.")
            .Produces<IncomingResponseDto>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound);

            group.MapPost("/{id:int}/short-close", async (
                int id,
                WMSContext dbContext,
                IAuditLogService auditLogService,
                CancellationToken cancellationToken) =>
            {
                var incoming = await dbContext.Incomings
                    .Include(inc => inc.Products)
                    .FirstOrDefaultAsync(inc => inc.Id == id, cancellationToken);

                if (incoming is null)
                {
                    return Results.NotFound(new { Message = $"Incoming shipment #{id} not found." });
                }

                if (incoming.Status == IncomingStatus.RECEIVED || incoming.Status == IncomingStatus.CLOSED_SHORT)
                {
                    return Results.BadRequest(new { Message = $"Incoming shipment #{id} is already completed or closed." });
                }

                // Mark all unfulfilled or partial line items as CLOSED_SHORT
                foreach (var product in incoming.Products!)
                {
                    if (product.Status != IncomingProductStatus.RECEIVED)
                    {
                        product.Status = IncomingProductStatus.CLOSED_SHORT;
                    }
                }

                incoming.Status = IncomingStatus.CLOSED_SHORT;
                await dbContext.SaveChangesAsync(cancellationToken);

                await auditLogService.LogAsync(
                    category: "Incoming",
                    action: "ShortClosed",
                    description: $"Shipment #{id} was short-closed by management. Remaining expected stock marked as lost/short.",
                    details: new { IncomingId = id, NewStatus = incoming.Status.ToString() }
                );

                return Results.Ok(new { Message = $"Shipment #{id} has been short-closed successfully." });
            })
            .WithName("ShortCloseIncoming")
            .WithSummary("Permanently close an incoming shipment with missing/lost items");

            // -----------------------------------------------------------------------------
            // GET /{id:int} - Get incoming by ID
            // -----------------------------------------------------------------------------
            group.MapGet("/{id:int}", async (int id, WMSContext dbContext) =>
            {
                var incoming = await dbContext.Incomings
                    .Include(inc => inc.Warehouse)
                    .Include(inc => inc.Products!)
                        .ThenInclude(p => p.Product)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(inc => inc.Id == id);

                if (incoming is null)
                {
                    return Results.NotFound();
                }

                var linkedProducts = await dbContext.Receivings
                    .Where(r => r.IncomingId == id)
                    .SelectMany(r => r.Products!)
                    .AsNoTracking()
                    .ToListAsync();

                return Results.Ok(incoming.ToResponseDto(linkedProducts));
            })
            .WithName("GetIncomingById")
            .WithSummary("Get incoming shipment by ID")
            .Produces<IncomingResponseDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            // -----------------------------------------------------------------------------
            // POST / - Create a new incoming record
            // -----------------------------------------------------------------------------
            group.MapPost("/", async (
                IncomingRequestDto dto,
                WMSContext dbContext,
                IAuditLogService auditLogService) =>
            {
                var entity = dto.ToEntity();

                dbContext.Incomings.Add(entity);
                await dbContext.SaveChangesAsync();

                var createdEntity = await dbContext.Incomings
                    .Include(inc => inc.Warehouse)
                    .Include(inc => inc.Products)
                        .ThenInclude(p => p.Product)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(inc => inc.Id == entity.Id);

                var responseDto = createdEntity?.ToResponseDto() ?? entity.ToResponseDto();

                // --- ADD AUDIT LOG ENTRY ---
                await auditLogService.LogAsync(
                    category: "Incoming",
                    action: "Created",
                    description: $"Created incoming shipment ID {entity.Id} (Shipper: '{entity.Shipper ?? "N/A"}') with {entity.Products.Count} line item(s).",
                    details: new
                    {
                        IncomingId = entity.Id,
                        WarehouseId = entity.WarehouseId,
                        Shipper = entity.Shipper,
                        Consignee = entity.Consignee,
                        Status = entity.Status.ToString(),
                        Products = responseDto.Products.Select(p => new
                        {
                            p.ProductName,
                            p.Quantity,
                            p.ExpirationDate,
                            Status = p.Status.ToString()
                        })
                    }
                );

                return Results.Created($"/incoming/{entity.Id}", responseDto);
            })
            .WithName("CreateIncoming")
            .WithSummary("Create a new incoming shipment")
            .WithDescription("Creates a new planned incoming shipment with its associated line items.")
            .Produces<IncomingResponseDto>(StatusCodes.Status201Created)
            .ProducesValidationProblem(StatusCodes.Status400BadRequest);

            // -----------------------------------------------------------------------------
            // PUT /{id:int} - Update an existing incoming record
            // -----------------------------------------------------------------------------
            group.MapPut("/{id:int}", async (
                int id,
                IncomingRequestDto dto,
                WMSContext dbContext,
                IAuditLogService auditLogService) =>
            {
                var existingEntity = await dbContext.Incomings
                    .Include(inc => inc.Products)
                    .FirstOrDefaultAsync(inc => inc.Id == id);

                if (existingEntity is null)
                {
                    return Results.NotFound();
                }

                var oldShipper = existingEntity.Shipper;
                var oldStatus = existingEntity.Status;

                existingEntity.WarehouseId = dto.WarehouseId;
                existingEntity.Shipper = dto.Shipper;
                existingEntity.Consignee = dto.Consignee;
                existingEntity.Status = dto.Status;

                dbContext.RemoveRange(existingEntity.Products);
                existingEntity.Products = dto.Products.Select(p => p.ToEntity()).ToList();

                await dbContext.SaveChangesAsync();

                var updatedEntity = await dbContext.Incomings
                    .Include(inc => inc.Warehouse)
                    .Include(inc => inc.Products)
                        .ThenInclude(p => p.Product)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(inc => inc.Id == id);

                var responseDto = updatedEntity?.ToResponseDto();

                // --- ADD AUDIT LOG ENTRY ---
                await auditLogService.LogAsync(
                    category: "Incoming",
                    action: "Updated",
                    description: $"Updated incoming shipment ID {id} (Shipper: '{existingEntity.Shipper ?? "N/A"}') with {existingEntity.Products.Count} line item(s).",
                    details: new
                    {
                        IncomingId = id,
                        OldShipper = oldShipper,
                        NewShipper = existingEntity.Shipper,
                        OldStatus = oldStatus.ToString(),
                        NewStatus = existingEntity.Status.ToString(),
                        TotalProducts = existingEntity.Products.Count,
                        Products = responseDto?.Products.Select(p => new
                        {
                            p.ProductName,
                            p.Quantity,
                            p.ExpirationDate,
                            Status = p.Status.ToString()
                        })
                    }
                );

                return Results.NoContent();
            })
            .WithName("UpdateIncoming")
            .WithSummary("Update an incoming shipment")
            .WithDescription("Updates all details and line items for an existing incoming shipment record.")
            .Produces(StatusCodes.Status204NoContent)
            .ProducesValidationProblem(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound);

            // -----------------------------------------------------------------------------
            // DELETE /{id:int} - Remove an incoming record
            // -----------------------------------------------------------------------------
            group.MapDelete("/{id:int}", async (
                int id,
                WMSContext dbContext,
                IAuditLogService auditLogService) =>
            {
                var existingIncoming = await dbContext.Incomings
                    .Include(inc => inc.Products)
                    .FirstOrDefaultAsync(inc => inc.Id == id);

                if (existingIncoming is null)
                {
                    return Results.NotFound();
                }

                var snapshotShipper = existingIncoming.Shipper;
                var snapshotConsignee = existingIncoming.Consignee;
                var snapshotProductCount = existingIncoming.Products?.Count ?? 0;

                dbContext.Incomings.Remove(existingIncoming);
                await dbContext.SaveChangesAsync();

                // --- ADD AUDIT LOG ENTRY ---
                await auditLogService.LogAsync(
                    category: "Incoming",
                    action: "Deleted",
                    description: $"Deleted incoming shipment ID {id} (Shipper: '{snapshotShipper ?? "N/A"}') containing {snapshotProductCount} line item(s).",
                    details: new
                    {
                        DeletedId = id,
                        Shipper = snapshotShipper,
                        Consignee = snapshotConsignee,
                        TotalProductsRemoved = snapshotProductCount
                    }
                );

                return Results.NoContent();
            })
            .WithName("DeleteIncoming")
            .WithSummary("Delete an incoming shipment")
            .WithDescription("Deletes an incoming shipment record from the system.")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);

            return group;
        }
    }
}