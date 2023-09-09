using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Integration.Test.BuildingBlocks.Auth.Configuration;

/// <summary>
/// A lightweight version of <see cref="JwtBearerOptions"/>.
/// </summary>
public sealed class JwtBearer
{
    /// <inheritdoc cref="JwtBearerOptions.Authority"/>
    public string Authority { get; init; } = string.Empty;
    
    /// <inheritdoc cref="JwtBearerOptions.RequireHttpsMetadata"/>
    public bool RequireHttpsMetadata { get; init; }
}