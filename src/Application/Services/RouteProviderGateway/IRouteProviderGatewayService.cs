using Application.Features.Routes.Queries.GetRoutesSearch;

namespace Application.Services.RouteProviderGateway;

public interface IRouteProviderGatewayService
{
    Task<GetRoutesSearchViewModel> SearchRoute(GetRoutesSearchQuery query);
}