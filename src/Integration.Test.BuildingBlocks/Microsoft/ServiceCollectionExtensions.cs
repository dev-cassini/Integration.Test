using Integration.Test.BuildingBlocks.Microsoft.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Integration.Test.BuildingBlocks.Microsoft;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMicrosoftGraphServices(
        this IServiceCollection serviceCollection,
        IConfiguration configuration,
        Action<Configurator> configuratorAction)
    {
        serviceCollection.AddAzureAdConfiguration(configuration);
        
        var configurator = new Configurator(serviceCollection);
        configuratorAction.Invoke(configurator);

        return serviceCollection;
    }
}