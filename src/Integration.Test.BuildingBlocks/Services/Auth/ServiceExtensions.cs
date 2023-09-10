using Microsoft.Extensions.DependencyInjection;

namespace Integration.Test.BuildingBlocks.Services.Auth;

using GrantTypes = BuildingBlocks.Auth.GrantTypes;

public static class ServiceExtensions
{
    public static IService ConfigureAuthentication(
        this IService service, 
        IServiceProvider serviceProvider,
        Action<Configurator> configuratorAction)
    {
        var passwordTokenStore = serviceProvider.GetRequiredService<GrantTypes.Password.ITokenStore>();
        var configurator = new Configurator(passwordTokenStore, service);
        configuratorAction.Invoke(configurator);

        return service;
    }
}