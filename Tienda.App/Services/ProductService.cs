using System.Net.Http.Json;
using Tienda.Shared.Models;

namespace Tienda.App.Services;

public class ProductService
{
    private readonly HttpClient _http;

    public ProductService(HttpClient http, IConfiguration configuration)
    {
        _http = http;
        var baseAddress = configuration["ApiBaseAddress"];
        if (string.IsNullOrEmpty(baseAddress))
        {
            throw new ArgumentNullException(nameof(baseAddress), "ApiBaseAddress configuration is missing or empty.");
        }
        _http.BaseAddress = new Uri(baseAddress);
    }

    public async Task<List<ProductDto>?> GetProducts() =>
        await _http.GetFromJsonAsync<List<ProductDto>>("api/products");

    public async Task<ProductDto?> GetProductById(Guid id) =>
        await _http.GetFromJsonAsync<ProductDto>($"api/products/{id}");

    public async Task CreateProduct(ProductDto product)
    {
        await _http.PostAsJsonAsync("api/products", product);
    }

    public async Task UpdateProduct(Guid id, ProductDto product)
    {
        await _http.PutAsJsonAsync($"api/products/{id}", product);
    }

    public async Task DeleteProduct(Guid id) =>
        await _http.DeleteAsync($"api/products?id={id}");
}

