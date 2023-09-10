using Microsoft.Extensions.Options;

namespace Integration.Test.BuildingBlocks.Auth.Configuration.Validators;

public class UserValidator : IValidateOptions<User>
{
    public ValidateOptionsResult Validate(string name, User options)
    {
        if (string.IsNullOrEmpty(options.Username))
        {
            return ValidateOptionsResult.Fail($"{nameof(User)}.{nameof(User.Username)} value is null or empty string. Check environment variables are configured correctly.");
        }
        
        if (string.IsNullOrEmpty(options.Password))
        {
            return ValidateOptionsResult.Fail($"{nameof(User)}.{nameof(User.Password)} value is null or empty string. Check environment variables are configured correctly.");
        }
        
        return ValidateOptionsResult.Success;
    }
}