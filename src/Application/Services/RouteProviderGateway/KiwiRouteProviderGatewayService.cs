using Application.Features.Routes.Queries.GetRoutesSearch;

namespace Application.Services.RouteProviderGateway;

public class KiwiRouteProviderGatewayService : IRouteProviderGatewayService
{
    public Task<GetRoutesSearchViewModel> SearchRoute(GetRoutesSearchQuery query)
    {
        throw new NotImplementedException();
    }
}
