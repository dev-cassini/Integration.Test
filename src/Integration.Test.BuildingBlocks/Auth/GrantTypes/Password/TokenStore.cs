using System.Collections.ObjectModel;
using Integration.Test.BuildingBlocks.Auth.Configuration;
using Integration.Test.BuildingBlocks.Auth.GrantTypes.Password.Exceptions;

namespace Integration.Test.BuildingBlocks.Auth.GrantTypes.Password;

public class TokenStore : ITokenStore
{
    public ReadOnlyDictionary<string, string> Tokens { get; }

    public TokenStore(ReadOnlyDictionary<string, string> tokens)
    {
        Tokens = tokens;
    }
    
    public string Get(User user)
    {
        if (Tokens.TryGetValue(user.EmailAddress, out var token))
        {
            return token;
        }

        throw new UserTokenNotFoundException(user);
    }
}