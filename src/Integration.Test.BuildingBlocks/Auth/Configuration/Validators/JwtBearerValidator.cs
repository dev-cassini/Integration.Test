using Microsoft.Extensions.Options;

namespace Integration.Test.BuildingBlocks.Auth.Configuration.Validators;

public class JwtBearerValidator : IValidateOptions<JwtBearer>
{
    public ValidateOptionsResult Validate(string name, JwtBearer options)
    {
        if ((Uri.TryCreate(options.Authority, UriKind.Absolute, out var uri) && 
             (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps)) is false)
        {
            return ValidateOptionsResult.Fail($"{nameof(JwtBearer)}.{nameof(JwtBearer.Authority)} value is null or empty string. Check environment variables are configured correctly.");
        }
        
        return ValidateOptionsResult.Success;
    }
}