using Azure.Identity;
using Integration.Test.BuildingBlocks.Email.Microsoft.Configuration;
using Integration.Test.BuildingBlocks.Email.Microsoft.Configuration.Validators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Graph;

namespace Integration.Test.BuildingBlocks.Email.Microsoft;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMicrosoftGraphService(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection
            .AddSingleton<IValidateOptions<AzureAd>, AzureAdValidator>()
            .AddOptions<AzureAd>()
            .Configure(configuration.GetSection(nameof(AzureAd)).Bind)
            .ValidateOnStart();
        
        serviceCollection.AddScoped<IGraphService, GraphService>(provider =>
        {
            var azureAd = provider.GetRequiredService<IOptions<AzureAd>>().Value;
            var clientSecretCredential = new ClientSecretCredential(azureAd.TenantId, azureAd.ClientId, azureAd.ClientSecret);
            var graphServiceClient = new GraphServiceClient(clientSecretCredential, new List<string> { "Mail.Read" });

            return new GraphService(graphServiceClient);
        });

        return serviceCollection;
    }
}