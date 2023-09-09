namespace Integration.Test.BuildingBlocks.Auth.Configuration;

/// <summary>
/// OAuth client configuration.
/// </summary>
public sealed class Client
{
    public string Id { get; init; } = string.Empty;
    public string Secret { get; init; } = string.Empty;
}