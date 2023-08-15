namespace Integration.Test.BuildingBlocks.Email.Microsoft.Configuration;

public sealed class AzureAd
{
    public string TenantId { get; init; } = string.Empty;
    public string ClientId { get; init; } = string.Empty;
    public string ClientSecret { get; init; } = string.Empty;
}