using Integration.Test.BuildingBlocks.Services.Cronofy;
using Microsoft.Extensions.DependencyInjection;

namespace Integration.Test.BuildingBlocks.Services;

public class Configurator
{
    private readonly IServiceCollection _serviceCollection;

    public Configurator(IServiceCollection serviceCollection)
    {
        _serviceCollection = serviceCollection;
    }

    public Configurator AddCronofyService()
    {
        _serviceCollection.AddCronofyService();
        return this;
    }
}