using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Integration.Test.BuildingBlocks.Configuration;

public class Builder
{
    public IConfiguration Build()
    {
        return new ConfigurationBuilder()
            .AddJsonFile("appsettings.Development.json")
            .AddEnvironmentVariables()
            .AddUserSecrets(Assembly.GetExecutingAssembly())
            .Build();
    }
}