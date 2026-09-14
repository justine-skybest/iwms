using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Dtos.Product;
using WMS.Api.Entities;
using WMS.Api.Mapping;

namespace WMS.Api.Endpoints;

public static class ProductEndpoint
{   
    public static RouteGroupBuilder MapProductEndpoints(this WebApplication app)
    {
        const string GetProductEndpointName = "GetProduct";
        var group = app.MapGroup("product").WithParameterValidation();

        group.MapGet("/", async (WMSContext dbContext) =>
            await dbContext.Products.Select(product => product.ToProductSummaryDto()).AsNoTracking().ToListAsync()
        );  

        group.MapGet("/{FilterText}", async (string FilterText, WMSContext dbContext) =>
            await dbContext.Products.Where(product => product.Name.Contains(FilterText.Substring(1, FilterText.Length - 2))).Select(product => product.ToProductDetailsDto()).AsNoTracking().ToListAsync()
        );

        group.MapGet("/{id:int}", async (int id, WMSContext dbContext) =>
        {
            Product? product = await dbContext.Products.FindAsync(id);

            return product is null ? Results.NotFound() : Results.Ok(product);            
        }
        ).WithName(GetProductEndpointName);
        
        group.MapPost("/", async (CreateProductDto newProduct, WMSContext dbContext) => 
        {
            Product product = newProduct.ToEntity();
            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetProductEndpointName, new {id = product.Id}, product.ToProductDetailsDto());
        });

        group.MapPut("/{id}", async (int id, UpdateProductDto updatedProduct, WMSContext dbContext) => 
        {
            var existingProduct = await dbContext.Products.FindAsync(id);
            if(existingProduct is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingProduct).CurrentValues.SetValues(updatedProduct.ToEntity(id));
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, WMSContext dbContext) => 
        {
            await dbContext.Products.Where(product => product.Id == id).ExecuteDeleteAsync();
            return Results.NoContent();
        });
        
        return group;
    }
}
