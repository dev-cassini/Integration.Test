using Integration.Test.BuildingBlocks.Auth.Configuration.Validators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Integration.Test.BuildingBlocks.Auth.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUsers(
        this IServiceCollection serviceCollection,
        IConfiguration configuration,
        List<string> userTypes)
    {
        serviceCollection.AddSingleton<IValidateOptions<User>, UserValidator>();
        foreach (var userType in userTypes)
        {
            serviceCollection
                .AddOptions<User>()
                .Configure(configuration.GetSection($"{nameof(Auth)}:{nameof(Users)}:{userType}").Bind)
                .ValidateOnStart();
        }

        return serviceCollection;
    }
    
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