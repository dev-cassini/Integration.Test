using System.Net.Http.Headers;

namespace Integration.Test.BuildingBlocks.Services;

public interface IService
{
    AuthenticationHeaderValue? AuthenticationHeaderValue { get; internal set; }
}