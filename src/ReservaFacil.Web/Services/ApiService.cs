using Newtonsoft.Json;

namespace ReservaFacil.Web.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(IConfiguration configuration)
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(configuration.GetSection("ReservaFacilAPI:Address").Value)
        };
    }

    public async Task<T> GetDataAsync<T>(string endpoint)
    {
        var response = await _httpClient.GetAsync(endpoint);

        if (!response.IsSuccessStatusCode) return default;

        var jsonResponse = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<T>(jsonResponse);
    }

    public async Task<T> GetDataAsync<T>(string endpoint, object data)
    {
        var jsonContent = JsonConvert.SerializeObject(data);
        var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(endpoint, content);

        if (!response.IsSuccessStatusCode) return default;

        var jsonResponse = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<T>(jsonResponse);
    }

    public async Task<bool> PostDataAsync(string endpoint, object data)
    {
        var jsonContent = JsonConvert.SerializeObject(data);
        var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(endpoint, content);

        return response.IsSuccessStatusCode;
    }
}