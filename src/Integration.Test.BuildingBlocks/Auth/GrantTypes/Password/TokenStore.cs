using System.Collections.ObjectModel;
using Integration.Test.BuildingBlocks.Auth.Configuration;
using Integration.Test.BuildingBlocks.Auth.GrantTypes.Password.Exceptions;

namespace Integration.Test.BuildingBlocks.Auth.GrantTypes.Password;

public class TokenStore : ITokenStore
{
    /// <summary>
    /// A store of user tokens, populated on construction of the store, with key being the
    /// email of the user who the token belongs to.
    /// </summary>
    private readonly ReadOnlyDictionary<string, string> _tokens;

    public TokenStore(ReadOnlyDictionary<string, string> tokens)
    {
        _tokens = tokens;
    }
    
    public string Get(User user)
    {
        if (_tokens.TryGetValue(user.EmailAddress, out var token))
        {
            return token;
        }

        throw new UserTokenNotFoundException(user);
    }
}