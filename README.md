# Integration Test Suite #

A suite of integration tests using SpecFlow.

### SpecFlow ###

https://specflow.org/

### Local Development ###

#### User Secrets ####

https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=windows

Add Azure AD client secret to secrets storage by running the following command from the root of Integration.Test.BuildingBlocks:

```powershell
dotnet user-secrets set "AzureAd:ClientSecret" "CLIENT_SECRET_HERE"
```