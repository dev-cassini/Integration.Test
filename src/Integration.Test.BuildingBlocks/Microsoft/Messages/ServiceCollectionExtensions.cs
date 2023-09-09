using Azure.Identity;
using Integration.Test.BuildingBlocks.Microsoft.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Graph;

namespace Integration.Test.BuildingBlocks.Microsoft.Messages;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddMessagesMicrosoftGraphService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IGraphService, GraphService>(provider =>
        {
            var azureAd = provider.GetRequiredService<IOptions<AzureAd>>().Value;
            var clientSecretCredential = new ClientSecretCredential(azureAd.TenantId, azureAd.ClientId, azureAd.ClientSecret);
            var graphServiceClient = new GraphServiceClient(clientSecretCredential, new List<string> { ".default" });
            return new GraphService(graphServiceClient);
        });

        return serviceCollection;
    }
}