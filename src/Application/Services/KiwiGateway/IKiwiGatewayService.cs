using Application.Features.Routes.Queries.GetRoutesSearch;
using Infrastructure.Kiwi.Contracts.Responses;

namespace Application.Services.RouteProviderGateway;

public interface IKiwiGatewayService
{
    Task<List<GetRoutesSearchViewModel>> SearchRoute(GetRoutesSearchQuery query);
    Task<GetRoutesSearchViewModel> GetOffer(string offerId);
}