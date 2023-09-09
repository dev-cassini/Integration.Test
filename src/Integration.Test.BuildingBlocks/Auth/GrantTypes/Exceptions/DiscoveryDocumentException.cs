using IdentityModel.Client;
using Integration.Test.BuildingBlocks.Auth.Configuration;

namespace Integration.Test.BuildingBlocks.Auth.GrantTypes.Exceptions;

public class DiscoveryDocumentException : Exception
{
    public DiscoveryDocumentException(DiscoveryDocumentResponse response, JwtBearer jwtBearer) 
        : base($"An error occurred when requesting the discovery document from {jwtBearer.Authority} " +
               $"with response error type {response.ErrorType} and error message '{response.Error}'.") { }
}