using ssCRUDapp.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ssCRUDapp.Client.Services
{
  public class ProductService 
  {
    private readonly HttpClient _httpClient;
    public ProductService(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public async Task<List<Product>> GetProductsAsync()
    {
      return await _httpClient.GetFromJsonAsync<List<Product>>("api/products");
    }

    public async Task CreateProductAsync(Product product) 
    {
      await _httpClient.PostAsJsonAsync("api/products", product);
    }
  }
}