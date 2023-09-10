using System.Net.Http.Headers;

namespace Integration.Test.BuildingBlocks.Services.Cronofy;

public class HttpService : IHttpService
{
    private readonly HttpClient _httpClient;

    public AuthenticationHeaderValue? AuthenticationHeaderValue
    {
        get => _httpClient.DefaultRequestHeaders.Authorization;
        set => _httpClient.DefaultRequestHeaders.Authorization = value;
    }

    public HttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpResponseMessage> GetServiceAccountAsync(Requests.GetServiceAccount request)
    {
        return await _httpClient.GetAsync(new Uri($"service-accounts/{request.Id}"));
    }
}