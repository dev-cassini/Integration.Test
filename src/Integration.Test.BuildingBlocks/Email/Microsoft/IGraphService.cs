using Microsoft.Graph.Models;

namespace Integration.Test.BuildingBlocks.Email.Microsoft;

public interface IGraphService
{
    Task<IEnumerable<Message>> GetUserMessagesAsync(string emailAddress);
}