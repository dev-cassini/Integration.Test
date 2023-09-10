using Microsoft.Extensions.DependencyInjection;

namespace Integration.Test.BuildingBlocks.Services.Auth;

using GrantTypes = BuildingBlocks.Auth.GrantTypes;

public static class ServiceExtensions
{
    public static T ConfigureAuthentication<T>(
        this T service, 
        IServiceProvider serviceProvider,
        Action<Configurator> configuratorAction) where T : IService
    {
        var passwordTokenStore = serviceProvider.GetRequiredService<GrantTypes.Password.ITokenStore>();
        var configurator = new Configurator(passwordTokenStore, service);
        configuratorAction.Invoke(configurator);

        return service;
    }
}