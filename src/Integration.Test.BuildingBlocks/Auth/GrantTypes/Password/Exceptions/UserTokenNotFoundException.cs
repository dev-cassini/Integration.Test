using Integration.Test.BuildingBlocks.Auth.Configuration;

namespace Integration.Test.BuildingBlocks.Auth.GrantTypes.Password.Exceptions;

public class UserTokenNotFoundException : Exception
{
    public UserTokenNotFoundException(User user)
        : base($"User token not registered for {user.Username}. Check that the " +
               $"user is registered and that the token is fetched during construction of the token store.") { }
}