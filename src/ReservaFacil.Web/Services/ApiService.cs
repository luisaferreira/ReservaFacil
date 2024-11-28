using ReservaFacil. Domain. Interfaces;
using Newtonsoft.Json;

namespace ReservaFacil.Web.Services;

public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://localhost:44390";

    public ApiService(HttpClient httpClient)
        => _httpClient = httpClient;
    
    public async Task<T> GetDataAsync<T>(string endpoint)
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}/{endpoint}");
        
        if (!response.IsSuccessStatusCode) return default;
        
        var jsonResponse = await response.Content.ReadAsStringAsync();
        
        return JsonConvert.DeserializeObject<T>(jsonResponse);
    }

    public async Task<bool> PostDataAsync(string endpoint, object data)
    {
        var jsonContent = JsonConvert.SerializeObject(data);
        var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{BaseUrl}/{endpoint}", content);
        
        return response.IsSuccessStatusCode;
    }
}