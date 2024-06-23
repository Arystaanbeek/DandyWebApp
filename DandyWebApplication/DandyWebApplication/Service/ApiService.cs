/*using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> RegisterUserAsync(string jsonUserData)
    {
        var content = new StringContent(jsonUserData, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("api/Account/register", content);
        return response.IsSuccessStatusCode;
    }
}
*/