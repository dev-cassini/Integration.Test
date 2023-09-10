using IdentityModel;
using Integration.Test.BuildingBlocks.Auth.Configuration;

namespace Integration.Test.BuildingBlocks.Auth.GrantTypes.Password;

/// <summary>
/// A token store for OAuth <see cref="OidcConstants.GrantTypes.Password"/> flow.
/// </summary>
public interface ITokenStore
{
    /// <summary>
    /// Return token from cache if one already exists for user, else request one using <see cref="IHttpService"/>.
    /// </summary>
    /// <param name="user">The user who the token is requested on behalf of.</param>
    /// <returns>The access token.</returns>
    Task<string> GetAsync(User user);
}