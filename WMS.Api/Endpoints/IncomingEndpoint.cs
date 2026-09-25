using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Dtos.Incoming;
using WMS.Api.Entities;
using WMS.Api.Mapping;

namespace WMS.Api.Endpoints
{
    public static class IncomingEndpoint
    {
        public static RouteGroupBuilder MapIncomingEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("incoming")
                .WithTags("Incomings")
                .WithParameterValidation();

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
                    .Include(inc => inc.Products)
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

                var items = incomings
                    .Select(inc => inc.ToResponseDto())
                    .ToList();

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

            group.MapGet("/unreceived", async (
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

                var query = dbContext.Incomings
                    // Filter loaded child products to only those where Received is false
                    .Include(inc => inc.Products.Where(p => !p.Received))
                        .ThenInclude(p => p.Product)
                    .Include(inc => inc.Warehouse)
                    .AsNoTracking()
                    // Restrict Incoming status to PENDING or PARTIAL
                    .Where(inc => inc.Status == IncomingStatus.PENDING || inc.Status == IncomingStatus.PARTIAL)
                    // Ensure we only retrieve Incomings that still have at least one unreceived product
                    .Where(inc => inc.Products.Any(p => !p.Received));

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

                var items = incomings
                    .Select(inc => inc.ToResponseDto())
                    .ToList();

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
            .WithSummary("Get pending or partial incoming shipments with unreceived products")
            .WithDescription("Retrieves a paginated list of incoming shipments with status PENDING or PARTIAL, including only products where Received is false.")
            .Produces<PaginatedResponse<IncomingResponseDto>>(StatusCodes.Status200OK);

            // GET: Get incoming by ID
            group.MapGet("/{id:int}", async (int id, WMSContext dbContext) =>
            {
                var incoming = await dbContext.Incomings
                    .Include(inc => inc.Warehouse)
                    .Include(inc => inc.Products)
                        .ThenInclude(p => p.Product)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(inc => inc.Id == id);

                return incoming is not null
                    ? Results.Ok(incoming.ToResponseDto())
                    : Results.NotFound();
            })
            .WithName("GetIncomingById")
            .WithSummary("Get incoming shipment by ID")
            .WithDescription("Retrieves a single incoming shipment record by its primary key.")
            .Produces<IncomingResponseDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            // POST: Create a new incoming record
            group.MapPost("/", async (IncomingRequestDto dto, WMSContext dbContext) =>
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

                return Results.Created($"/incoming/{entity.Id}", responseDto);
            })
            .WithName("CreateIncoming")
            .WithSummary("Create a new incoming shipment")
            .WithDescription("Creates a new planned incoming shipment with its associated line items.")
            .Produces<IncomingResponseDto>(StatusCodes.Status201Created)
            .ProducesValidationProblem(StatusCodes.Status400BadRequest);

            // PUT: Update an existing incoming record
            group.MapPut("/{id:int}", async (int id, IncomingRequestDto dto, WMSContext dbContext) =>
            {
                var existingEntity = await dbContext.Incomings
                    .Include(inc => inc.Products)
                    .FirstOrDefaultAsync(inc => inc.Id == id);

                if (existingEntity is null)
                {
                    return Results.NotFound();
                }

                existingEntity.WarehouseId = dto.WarehouseId;
                existingEntity.Shipper = dto.Shipper;
                existingEntity.Consignee = dto.Consignee;
                existingEntity.Status = dto.Status;

                // Use dbContext.RemoveRange directly instead of dbContext.IncomingProducts.RemoveRange
                dbContext.RemoveRange(existingEntity.Products);
                existingEntity.Products = dto.Products.Select(p => p.ToEntity()).ToList();

                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            })
            .WithName("UpdateIncoming")
            .WithSummary("Update an incoming shipment")
            .WithDescription("Updates all details and line items for an existing incoming shipment record.")
            .Produces(StatusCodes.Status204NoContent)
            .ProducesValidationProblem(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound);

            // DELETE: Remove an incoming record
            group.MapDelete("/{id:int}", async (int id, WMSContext dbContext) =>
            {
                var rowsAffected = await dbContext.Incomings
                    .Where(inc => inc.Id == id)
                    .ExecuteDeleteAsync();

                return rowsAffected > 0
                    ? Results.NoContent()
                    : Results.NotFound();
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