using Integration.Test.BuildingBlocks.Auth.Configuration;

namespace Integration.Test.BuildingBlocks.Auth.GrantTypes.Password;

public class TokenStore : ITokenStore
{
    private readonly Dictionary<string, string> _tokens = new();
    private readonly IHttpService _httpService;

    public TokenStore(IHttpService httpService)
    {
        _httpService = httpService;
    }
    
    public async Task<string> GetAsync(User user)
    {
        if (_tokens.TryGetValue(user.EmailAddress, out var token))
        {
            return token;
        }

        var tokenResponse = await _httpService.RequestTokenAsync(user);
        _tokens.Add(user.EmailAddress, tokenResponse.AccessToken!);

        return tokenResponse.AccessToken!;
    }
}