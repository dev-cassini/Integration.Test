using IdentityModel;

namespace Integration.Test.BuildingBlocks.Auth.GrantTypes.ClientCredentials;

/// <summary>
/// A token store for OAuth <see cref="OidcConstants.GrantTypes.ClientCredentials"/> flow.
/// </summary>
public interface ITokenStore
{
    /// <summary>
    /// Integration Test client token.
    /// </summary>
    string Token { get; }
}