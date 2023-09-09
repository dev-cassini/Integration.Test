using Microsoft.Graph.Models;

namespace Integration.Test.BuildingBlocks.Microsoft.Messages;

public interface IGraphService
{
    Task<IEnumerable<Message>> GetUserMessagesAsync(string emailAddress);
}