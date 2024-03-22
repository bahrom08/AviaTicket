using Application.Features.Routes.Queries.GetRoutesSearch;

namespace Application.Services.GoogleFlightsGateway;
public interface IGoogleFlightsGatewayService
{
    Task<List<GetRoutesSearchViewModel>> SearchRoute(GetRoutesSearchQuery query);
    Task<GetRoutesSearchViewModel> GetOffer(string offerId);
}