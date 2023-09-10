namespace Integration.Test.BuildingBlocks.Services.Cronofy;

public interface IHttpService : IService
{
    Task<HttpResponseMessage> GetServiceAccountAsync(Requests.GetServiceAccount request);
}