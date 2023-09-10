using System.Net.Http.Headers;
using Integration.Test.BuildingBlocks.Auth.Configuration;

namespace Integration.Test.BuildingBlocks.Services.Auth;

using GrantTypes = BuildingBlocks.Auth.GrantTypes;

public class Configurator
{
    private readonly GrantTypes.Password.ITokenStore _passwordTokenStore;
    private readonly IService _service;

    public Configurator(
        GrantTypes.Password.ITokenStore passwordTokenStore, 
        IService service)
    {
        _passwordTokenStore = passwordTokenStore;
        _service = service;
    }

    public void As(User user)
    {
        var token = _passwordTokenStore.Get(user);
        _service.AuthenticationHeaderValue = new AuthenticationHeaderValue("Bearer", token);
    }
}