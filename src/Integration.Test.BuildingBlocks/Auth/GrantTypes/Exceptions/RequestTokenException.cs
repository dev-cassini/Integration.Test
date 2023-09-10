using IdentityModel.Client;

namespace Integration.Test.BuildingBlocks.Auth.GrantTypes.Exceptions;

public class RequestTokenException : Exception
{
    public RequestTokenException(TokenResponse tokenResponse, DiscoveryDocumentResponse discoveryDocumentResponse) 
        : base($"An error occurred when requesting a token from {discoveryDocumentResponse.TokenEndpoint} " +
               $"with response type '{tokenResponse.ErrorType}', error '{tokenResponse.Error}' and description '{tokenResponse.ErrorDescription}'.") { }
}