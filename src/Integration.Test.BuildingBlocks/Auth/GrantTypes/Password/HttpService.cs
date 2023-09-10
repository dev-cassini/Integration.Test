using IdentityModel.Client;
using Integration.Test.BuildingBlocks.Auth.Configuration;
using Integration.Test.BuildingBlocks.Auth.GrantTypes.Exceptions;
using Microsoft.Extensions.Options;

namespace Integration.Test.BuildingBlocks.Auth.GrantTypes.Password;

public class HttpService : IHttpService
{
    private readonly Client _client;
    private readonly JwtBearer _jwtBearer;

    public HttpService(IOptions<Client> clientOptions, IOptions<JwtBearer> jwtBearerOptions)
    {
        _client = clientOptions.Value;
        _jwtBearer = jwtBearerOptions.Value;
    }
    
    public async Task<TokenResponse> RequestTokenAsync(User user, CancellationToken cancellationToken)
    {
        var httpClient = new HttpClient();
        var discoveryDocument = await httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
        {
            Address = _jwtBearer.Authority,
            Policy = new DiscoveryPolicy
            {
                RequireHttps = _jwtBearer.RequireHttpsMetadata
            }
        }, cancellationToken);

        if (discoveryDocument.IsError)
        {
            throw new DiscoveryDocumentException(discoveryDocument, _jwtBearer);
        }

        var token = await httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest
        {
            Address = discoveryDocument.TokenEndpoint,
            ClientId = _client.Id,
            ClientSecret = _client.Secret,
            UserName = user.Username,
            Password = user.Password
        }, cancellationToken);

        if (token.IsError)
        {
            throw new RequestTokenException(token, discoveryDocument);
        }

        return token;
    }
}