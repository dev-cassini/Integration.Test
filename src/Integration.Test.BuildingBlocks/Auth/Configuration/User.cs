namespace Integration.Test.BuildingBlocks.Auth.Configuration;

public sealed class User
{
    public string Type { get; init; } = string.Empty;
    public string EmailAddress { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}