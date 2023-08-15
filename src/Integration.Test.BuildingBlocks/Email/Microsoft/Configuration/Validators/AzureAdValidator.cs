using Microsoft.Extensions.Options;

namespace Integration.Test.BuildingBlocks.Email.Microsoft.Configuration.Validators;

public class AzureAdValidator : IValidateOptions<AzureAd>
{
    public ValidateOptionsResult Validate(string name, AzureAd options)
    {
        if (string.IsNullOrEmpty(options.TenantId))
        {
            return ValidateOptionsResult.Fail($"{nameof(AzureAd)}.{nameof(AzureAd.TenantId)} value is null or empty string. Check environment variables are configured correctly.");
        }
        
        if (string.IsNullOrEmpty(options.ClientId))
        {
            return ValidateOptionsResult.Fail($"{nameof(AzureAd)}.{nameof(AzureAd.ClientId)} value is null or empty string. Check environment variables are configured correctly.");
        }
        
        if (string.IsNullOrEmpty(options.ClientSecret))
        {
            return ValidateOptionsResult.Fail($"{nameof(AzureAd)}.{nameof(AzureAd.ClientSecret)} value is null or empty string. Check environment variables are configured correctly.");
        }
        
        return ValidateOptionsResult.Success;
    }
}