namespace Integration.Test.BuildingBlocks.Services.Auth.Exceptions;

using Auth = Integration.Test.BuildingBlocks.Auth;
using GrantTypes = Integration.Test.BuildingBlocks.Auth.GrantTypes;

public class ClientCredentialsTokenStoreNotRegisteredException : Exception
{
    public ClientCredentialsTokenStoreNotRegisteredException()
        : base($"Service of type {typeof(GrantTypes.ClientCredentials.ITokenStore)} is not registered. " +
               $"Call {nameof(Auth.Configurator.AddClientCredentialsFlow)} when registering your dependencies.") { }
}