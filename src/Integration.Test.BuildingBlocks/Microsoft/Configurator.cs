using Integration.Test.BuildingBlocks.Microsoft.Messages;
using Microsoft.Extensions.DependencyInjection;

namespace Integration.Test.BuildingBlocks.Microsoft;

public class Configurator
{
    private readonly IServiceCollection _serviceCollection;

    public Configurator(IServiceCollection serviceCollection)
    {
        _serviceCollection = serviceCollection;
    }

    public Configurator AddMessagesService()
    {
        _serviceCollection.AddMessagesMicrosoftGraphService();
        return this;
    }
}