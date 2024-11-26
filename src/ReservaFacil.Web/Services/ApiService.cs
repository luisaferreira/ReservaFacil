using ReservaFacil. Domain. Interfaces;
using Newtonsoft.Json;

namespace ReservaFacil.Web.Services;

public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;
    
    public ApiService(HttpClient httpClient)
        => _httpClient = httpClient;
    
    
    public async Task<T> GetDataAsync<T>(string url)
    {
        var response = await _httpClient.GetAsync(url);
        
        if (!response.IsSuccessStatusCode) return default;
        
        var jsonResponse = await response.Content.ReadAsStringAsync();
        
        return JsonConvert.DeserializeObject<T>(jsonResponse);
    }

    public async Task<bool> PostDataAsync(string url, object data)
    {
        var jsonContent = JsonConvert.SerializeObject(data);
        var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(url, content);
        
        return response.IsSuccessStatusCode;
    }
}