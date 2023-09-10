using Microsoft.Extensions.DependencyInjection;

namespace Integration.Test.BuildingBlocks.Services.Cronofy;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCronofyService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHttpClient<IHttpService, HttpService>((provider, client) =>
        {
            client.BaseAddress = new Uri("http://localhost:1234");
        });

        return serviceCollection;
    }
}