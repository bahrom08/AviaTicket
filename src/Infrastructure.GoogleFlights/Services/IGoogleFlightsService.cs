using Infrastructure.GoogleFlights.Contracts.Requests;
using Infrastructure.GoogleFlights.Contracts.Responses;

namespace Infrastructure.GoogleFlights.Services;

public interface IGoogleFlightsService
{
    Task<SearchFlightsResponse> SearchFlights(SearchFlightsRequest request);
    Task<Itinerary?> GetFlight(string offerId);
}