using Integration.Test.BuildingBlocks.Microsoft.Configuration.Validators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Integration.Test.BuildingBlocks.Microsoft.Configuration;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddAzureAdConfiguration(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection
            .AddSingleton<IValidateOptions<AzureAd>, AzureAdValidator>()
            .AddOptions<AzureAd>()
            .Configure(configuration.GetSection(nameof(AzureAd)).Bind)
            .ValidateOnStart();

        return serviceCollection;
    }
}