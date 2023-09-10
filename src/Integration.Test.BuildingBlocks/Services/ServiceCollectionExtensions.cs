using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Integration.Test.BuildingBlocks.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(
        this IServiceCollection serviceCollection,
        IConfiguration configuration,
        Action<Configurator> configuratorAction)
    {
        var configurator = new Configurator(serviceCollection);
        configuratorAction.Invoke(configurator);

        return serviceCollection;
    }
}