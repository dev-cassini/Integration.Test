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
        var passwordTokenStore = serviceProvider.GetService<GrantTypes.Password.ITokenStore>();
        var clientCredentialsTokenStore = serviceProvider.GetService<GrantTypes.ClientCredentials.ITokenStore>();
        var configurator = new Configurator(passwordTokenStore, clientCredentialsTokenStore, service);
        configuratorAction.Invoke(configurator);

        return service;
    }
}