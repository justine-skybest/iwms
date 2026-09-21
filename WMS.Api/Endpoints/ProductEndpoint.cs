using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Dtos;
using WMS.Api.Dtos.Product;
using WMS.Api.Entities;
using WMS.Api.Hubs;
using WMS.Api.Mapping;

namespace WMS.Api.Endpoints;

public static class ProductEndpoint
{
    public static RouteGroupBuilder MapProductEndpoints(this WebApplication app)
    {
        const string GetProductEndpointName = "GetProduct";
        var group = app.MapGroup("product").WithParameterValidation();

        // -----------------------------------------------------------------------------
        // GET / (v1) — legacy, unfiltered, unpaginated
        // -----------------------------------------------------------------------------
        group.MapGet("/", async (WMSContext dbContext) =>
            await dbContext.Products.Select(product => product.ToProductSummaryDto()).AsNoTracking().ToListAsync()
        );

        // -----------------------------------------------------------------------------
        // GET /v2?search=&page=&pageSize= — paginated, with optional search query
        // -----------------------------------------------------------------------------
        group.MapGet("/v2", async (
            WMSContext dbContext,
            string? search = null,
            int page = 1,
            int pageSize = 50,
            CancellationToken cancellationToken = default) =>
        {
            const int maxPageSize = 500;
            page = Math.Max(page, 1);
            pageSize = Math.Clamp(pageSize, 1, maxPageSize);

            var query = dbContext.Products.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(product => product.Name.Contains(search));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(product => product.Id)
                .Select(product => product.ToProductSummaryDto())
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            var response = new PaginatedResponse<ProductSummaryDto>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return Results.Ok(response);
        })
        .Produces<PaginatedResponse<ProductSummaryDto>>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // GET /{FilterText} (v1) — legacy path-segment filter, kept for backward compatibility
        // -----------------------------------------------------------------------------
        group.MapGet("/{FilterText}", async (string FilterText, WMSContext dbContext) =>
            await dbContext.Products
                .Where(product => product.Name.Contains(FilterText))
                .Select(product => product.ToProductDetailsDto())
                .AsNoTracking()
                .ToListAsync()
        );

        // -----------------------------------------------------------------------------
        // Single Item & Mutation Endpoints
        // -----------------------------------------------------------------------------
        group.MapGet("/{id:int}", async (int id, WMSContext dbContext) =>
        {
            Product? product = await dbContext.Products.FindAsync(id);

            return product is null ? Results.NotFound() : Results.Ok(product);
        }
        ).WithName(GetProductEndpointName);

        group.MapPost("/", async (CreateProductDto newProduct, WMSContext dbContext, IHubContext<NotificationHub, INotificationClient> hubContext) =>
        {
            Product product = newProduct.ToEntity();
            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();

            await hubContext.Clients.All.ProductCreated();

            return Results.CreatedAtRoute(GetProductEndpointName, new { id = product.Id }, product.ToProductDetailsDto());
        })
        .WithName("CreateProduct")
        .WithSummary("Create a new product")
        .WithDescription("Creates a new product record and returns the created product details.")
        .Accepts<CreateProductDto>("application/json")
        .Produces<ProductDetailsDto>(StatusCodes.Status201Created)
        .ProducesValidationProblem(StatusCodes.Status400BadRequest);

        group.MapPut("/{id}", async (int id, UpdateProductDto updatedProduct, WMSContext dbContext, IHubContext<NotificationHub, INotificationClient> hubContext) =>
        {
            var existingProduct = await dbContext.Products.FindAsync(id);
            if (existingProduct is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingProduct).CurrentValues.SetValues(updatedProduct.ToEntity(id));
            await dbContext.SaveChangesAsync();

            await hubContext.Clients.All.ProductUpdated();

            return Results.NoContent();
        })
        .WithName("UpdateProduct")
        .WithSummary("Update an existing product")
        .WithDescription("Updates all details of an existing product by its ID.")
        .Accepts<UpdateProductDto>("application/json")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound)
        .ProducesValidationProblem(StatusCodes.Status400BadRequest);

        group.MapDelete("/{id}", async (int id, WMSContext dbContext) =>
        {
            await dbContext.Products.Where(product => product.Id == id).ExecuteDeleteAsync();
            return Results.NoContent();
        });

        return group;
    }
}