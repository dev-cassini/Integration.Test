using Microsoft.Extensions.Options;

namespace Integration.Test.BuildingBlocks.Auth.Configuration.Validators;

public class ClientValidator : IValidateOptions<Client>
{
    public ValidateOptionsResult Validate(string name, Client options)
    {
        if (string.IsNullOrEmpty(options.Id))
        {
            return ValidateOptionsResult.Fail($"{nameof(Client)}.{nameof(Client.Id)} value is null or empty string. Check environment variables are configured correctly.");
        }
        
        if (string.IsNullOrEmpty(options.Secret))
        {
            return ValidateOptionsResult.Fail($"{nameof(Client)}.{nameof(Client.Secret)} value is null or empty string. Check environment variables are configured correctly.");
        }
        
        return ValidateOptionsResult.Success;
    }
}