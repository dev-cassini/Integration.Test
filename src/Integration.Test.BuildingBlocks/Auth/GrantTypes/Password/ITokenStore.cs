using System.Collections.ObjectModel;
using IdentityModel;
using Integration.Test.BuildingBlocks.Auth.Configuration;
using Integration.Test.BuildingBlocks.Auth.GrantTypes.Password.Exceptions;

namespace Integration.Test.BuildingBlocks.Auth.GrantTypes.Password;

/// <summary>
/// A token store for OAuth <see cref="OidcConstants.GrantTypes.Password"/> flow.
/// </summary>
public interface ITokenStore
{
    /// <summary>
    /// A store of user tokens, populated on construction of the store, with key being the
    /// email of the user who the token belongs to.
    /// </summary>
    ReadOnlyDictionary<string, string> Tokens { get; }
    
    /// <summary>
    /// Return token from store if one exists for user.
    /// </summary>
    /// <param name="user">The user who the token belongs to.</param>
    /// <returns>The access token.</returns>
    /// <exception cref="UserTokenNotFoundException">Token not registered for user.</exception>
    string GetAsync(User user);
}