using IdentityModel;
using IdentityModel.Client;

namespace Integration.Test.BuildingBlocks.Auth.GrantTypes.ClientCredentials;

public interface IHttpService
{
    /// <summary>
    /// Request a token using <see cref="OidcConstants.GrantTypes.ClientCredentials"/> flow.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The <see cref="TokenResponse"/> from auth server.</returns>
    Task<TokenResponse> RequestTokenAsync(CancellationToken cancellationToken);
}