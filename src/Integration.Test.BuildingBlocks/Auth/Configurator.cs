using System.Collections.ObjectModel;
using Integration.Test.BuildingBlocks.Auth.Configuration;
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
        _serviceCollection.AddSingleton<GrantTypes.Password.ITokenStore, GrantTypes.Password.TokenStore>(provider =>
        {
            var tokens = new Dictionary<string, string>();
            var passwordHttpService = provider.GetRequiredService<GrantTypes.Password.IHttpService>();
            var users = provider.GetServices<User>();
            foreach (var user in users)
            {
                var token = passwordHttpService.RequestTokenAsync(user, CancellationToken.None)
                    .GetAwaiter().GetResult();

                tokens.Add(user.EmailAddress, token.AccessToken!);
            }

            return new GrantTypes.Password.TokenStore(new ReadOnlyDictionary<string, string>(tokens));
        });
        
        return this;
    }
}