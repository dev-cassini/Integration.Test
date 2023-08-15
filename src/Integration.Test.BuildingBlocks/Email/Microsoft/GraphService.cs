using Microsoft.Graph;
using Microsoft.Graph.Models;

namespace Integration.Test.BuildingBlocks.Email.Microsoft;

public class GraphService : IGraphService
{
    private readonly GraphServiceClient _graphServiceClient;

    public GraphService(GraphServiceClient graphServiceClient)
    {
        _graphServiceClient = graphServiceClient;
    }

    public async Task<IEnumerable<Message>> GetUserMessagesAsync(string emailAddress)
    {
        var users = await _graphServiceClient
            .Users
            .GetAsync(configuration =>
            {
                configuration.QueryParameters.Filter = $"mail eq '{emailAddress}'";
                configuration.QueryParameters.Top = 1;
            });
        
        var user = users!.Value!.Single();

        var messages = await _graphServiceClient
            .Users[user.Id]
            .Messages.GetAsync();

        return messages!.Value!;
    }
}