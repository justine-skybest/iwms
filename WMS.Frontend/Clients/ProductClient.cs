using WMS.Frontend.Models;

namespace WMS.Frontend.Clients;

public class ProductClient(HttpClient httpClient)
{
    public async Task<ProductSummary[]> GetProductsAsync()
        => await httpClient.GetFromJsonAsync<ProductSummary[]>("product") ?? [];
    
    public async Task<ProductSummary[]> GetProductsAsync(string FilterText)
        => await httpClient.GetFromJsonAsync<ProductSummary[]>($"product/{"'" + FilterText + "'"}") ?? [];

    public async Task AddProductAsync(ProductDetails product) 
        => await httpClient.PostAsJsonAsync("product", product);

    public async Task<ProductDetails> GetProductAsync(int id)
        => await httpClient.GetFromJsonAsync<ProductDetails>($"product/{id}")
        ?? throw new Exception("Could not find the product!");

    public async Task UpdateProductAsync(ProductDetails updateProduct)
        => await httpClient.PutAsJsonAsync($"product/{updateProduct.Id}", updateProduct);

    public async Task DeleteProductAsync(int id)
        => await httpClient.DeleteAsync($"product/{id}");
}
