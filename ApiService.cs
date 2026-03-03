using System.Net.Http;
using System.Net.Http.Json;
using ProductClientApp.Models;

namespace ProductClientApp.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;

    private const string BaseUrl = "https://localhost:5001"; // пока рандомный

    public ApiService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(BaseUrl);
    }

    public async Task<bool> LoginAsync(string login, string password)
    {
        var response = await _httpClient.PostAsJsonAsync("/login", new
        {
            login,
            password
        });

        return response.IsSuccessStatusCode;
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        var products = await _httpClient.GetFromJsonAsync<List<Product>>("/products");
        return products ?? new List<Product>();
    }
}