using System.Net.Http.Headers;
using Integration.Test.BuildingBlocks.Auth.Configuration;
using Integration.Test.BuildingBlocks.Services.Auth.Exceptions;

namespace Integration.Test.BuildingBlocks.Services.Auth;

using GrantTypes = BuildingBlocks.Auth.GrantTypes;

public class Configurator
{
    private readonly GrantTypes.Password.ITokenStore? _passwordTokenStore;
    private readonly GrantTypes.ClientCredentials.ITokenStore? _clientCredentialsTokenStore;
    private readonly IService _service;

    public Configurator(
        GrantTypes.Password.ITokenStore? passwordTokenStore,
        GrantTypes.ClientCredentials.ITokenStore? clientCredentialsTokenStore, 
        IService service)
    {
        _passwordTokenStore = passwordTokenStore;
        _clientCredentialsTokenStore = clientCredentialsTokenStore;
        _service = service;
    }

    public void As(User user)
    {
        if (_passwordTokenStore is null)
        {
            throw new PasswordTokenStoreNotRegisteredException();
        }
        
        var token = _passwordTokenStore.Get(user);
        _service.AuthenticationHeaderValue = new AuthenticationHeaderValue("Bearer", token);
    }

    public void AsClient()
    {
        if (_clientCredentialsTokenStore is null)
        {
            throw new ClientCredentialsTokenStoreNotRegisteredException();
        }
        
        _service.AuthenticationHeaderValue = new AuthenticationHeaderValue("Bearer", _clientCredentialsTokenStore.Token);
    }
}