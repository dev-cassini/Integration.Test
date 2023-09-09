using Integration.Test.BuildingBlocks.Auth.Configuration.Validators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Integration.Test.BuildingBlocks.Auth.Configuration;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddAuthConfiguration(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection
            .AddSingleton<IValidateOptions<Client>, ClientValidator>()
            .AddOptions<Client>()
            .Configure(configuration.GetSection($"{nameof(Auth)}:{nameof(Client)}").Bind)
            .ValidateOnStart();
        
        serviceCollection
            .AddSingleton<IValidateOptions<JwtBearer>, JwtBearerValidator>()
            .AddOptions<JwtBearer>()
            .Configure(configuration.GetSection($"{nameof(Auth)}:{nameof(JwtBearer)}").Bind)
            .ValidateOnStart();

        return serviceCollection;
    }
}