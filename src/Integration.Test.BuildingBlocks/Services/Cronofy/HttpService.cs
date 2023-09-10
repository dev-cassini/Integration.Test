namespace Integration.Test.BuildingBlocks.Services.Cronofy;

public class HttpService : IHttpService
{
    private readonly HttpClient _httpClient;

    public HttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpResponseMessage> GetServiceAccountAsync(Requests.GetServiceAccount request)
        => await _httpClient.GetAsync(new Uri($"service-accounts/{request.Id}"));
}