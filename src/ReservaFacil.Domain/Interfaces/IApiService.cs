namespace ReservaFacil. Domain. Interfaces;

public interface IApiService
{
    Task<T> GetDataAsync<T>(string url);
    Task<bool> PostDataAsync(string url, object data);
}