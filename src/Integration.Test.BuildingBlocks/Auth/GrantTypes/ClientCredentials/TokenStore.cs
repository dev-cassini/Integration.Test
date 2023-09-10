namespace Integration.Test.BuildingBlocks.Auth.GrantTypes.ClientCredentials;

public class TokenStore : ITokenStore
{
    public string Token { get; }

    public TokenStore(string token)
    {
        Token = token;
    }
}