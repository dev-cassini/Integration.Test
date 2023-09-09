using Integration.Test.BuildingBlocks.Auth.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Integration.Test.BuildingBlocks.Auth;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAuthServices(
        this IServiceCollection serviceCollection,
        IConfiguration configuration,
        Action<Configurator> configuratorAction)
    {
        serviceCollection.AddAuthConfiguration(configuration);
        
        var configurator = new Configurator(serviceCollection);
        configuratorAction.Invoke(configurator);

        return serviceCollection;
    }
}