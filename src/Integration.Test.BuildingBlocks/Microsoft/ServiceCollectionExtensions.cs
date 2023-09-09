using Integration.Test.BuildingBlocks.Microsoft.Configuration;
using Integration.Test.BuildingBlocks.Microsoft.Configuration.Validators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Integration.Test.BuildingBlocks.Microsoft;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMicrosoftGraphServices(
        this IServiceCollection serviceCollection,
        IConfiguration configuration,
        Action<Configurator> configuratorAction)
    {
        serviceCollection
            .AddSingleton<IValidateOptions<AzureAd>, AzureAdValidator>()
            .AddOptions<AzureAd>()
            .Configure(configuration.GetSection(nameof(AzureAd)).Bind)
            .ValidateOnStart();
        
        var configurator = new Configurator(serviceCollection);
        configuratorAction.Invoke(configurator);

        return serviceCollection;
    }
}