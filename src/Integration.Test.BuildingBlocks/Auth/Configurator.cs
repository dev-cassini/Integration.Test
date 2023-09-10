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
                var token = Task.Run(async () => await passwordHttpService.RequestTokenAsync(user, CancellationToken.None))
                    .ConfigureAwait(false).GetAwaiter().GetResult();

                tokens.Add(user.EmailAddress, token.AccessToken!);
            }

            return new GrantTypes.Password.TokenStore(new ReadOnlyDictionary<string, string>(tokens));
        });
        
        return this;
    }

    public Configurator AddClientCredentialsFlow()
    {
        _serviceCollection.AddScoped<GrantTypes.ClientCredentials.IHttpService, GrantTypes.ClientCredentials.HttpService>();
        _serviceCollection.AddSingleton<GrantTypes.ClientCredentials.ITokenStore, GrantTypes.ClientCredentials.TokenStore>(provider =>
        {
            var clientCredentialsHttpService = provider.GetRequiredService<GrantTypes.ClientCredentials.IHttpService>();
            var token = Task.Run(async () => await clientCredentialsHttpService.RequestTokenAsync(CancellationToken.None))
                .ConfigureAwait(false).GetAwaiter().GetResult();

            return new GrantTypes.ClientCredentials.TokenStore(token.AccessToken!);
        });

        return this;
    }
}