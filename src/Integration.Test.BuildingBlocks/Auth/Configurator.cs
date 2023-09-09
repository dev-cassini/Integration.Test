using Microsoft.Extensions.DependencyInjection;

namespace Integration.Test.BuildingBlocks.Auth;

public class Configurator
{
    private readonly IServiceCollection _serviceCollection;

    public Configurator(IServiceCollection serviceCollection)
    {
        _serviceCollection = serviceCollection;
    }

    public Configurator AddPasswordFlow()
    {
        _serviceCollection.AddScoped<GrantTypes.Password.IHttpService, GrantTypes.Password.HttpService>();
        return this;
    }
}