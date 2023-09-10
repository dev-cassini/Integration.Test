namespace Integration.Test.BuildingBlocks.Services.Auth.Exceptions;

using Auth = Integration.Test.BuildingBlocks.Auth;
using GrantTypes = Integration.Test.BuildingBlocks.Auth.GrantTypes;

public class PasswordTokenStoreNotRegisteredException : Exception
{
    public PasswordTokenStoreNotRegisteredException()
        : base($"Service of type {typeof(GrantTypes.Password.ITokenStore)} is not registered. " +
               $"Call {nameof(Auth.Configurator.AddPasswordFlow)} when registering your dependencies.") { }
}