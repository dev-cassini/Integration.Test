using IdentityModel;
using IdentityModel.Client;
using Integration.Test.BuildingBlocks.Auth.Configuration;

namespace Integration.Test.BuildingBlocks.Auth.GrantTypes.Password;

public interface IHttpService
{
    /// <summary>
    /// Request a token using <see cref="OidcConstants.GrantTypes.Password"/> flow.
    /// </summary>
    /// <param name="user">The user who the token is requested on behalf of.</param>
    /// <returns>The <see cref="TokenResponse"/> from auth server.</returns>
    Task<TokenResponse> RequestTokenAsync(User user);
}