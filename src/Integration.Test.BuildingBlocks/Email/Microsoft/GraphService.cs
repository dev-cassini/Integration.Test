using Microsoft.Graph;

namespace Integration.Test.BuildingBlocks.Email.Microsoft;

public class GraphService : IGraphService
{
    private readonly GraphServiceClient _graphServiceClient;

    public GraphService(GraphServiceClient graphServiceClient)
    {
        _graphServiceClient = graphServiceClient;
    }
}