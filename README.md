# Integration Test Suite #

A suite of integration tests using SpecFlow.

### SpecFlow ###

https://specflow.org/

### Local Development ###

#### User Secrets ####

https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=windows

To avoid committing sensitive information to source control, add the following secrets 
to secrets storage by running the following commands from the root of Integration.Test.BuildingBlocks:

Azure AD
```powershell
dotnet user-secrets set "AzureAd:ClientSecret" "CLIENT_SECRET_HERE"
```

Client Secret
```powershell
dotnet user-secrets set "Auth:Client:Secret" "CLIENT_SECRET_HERE"
```

Users
```powershell
dotnet user-secrets set "Auth:Users:Admin:Password" "ADMIN_PASSWORD_HERE"
```