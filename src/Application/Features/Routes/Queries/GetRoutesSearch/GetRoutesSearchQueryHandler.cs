using MediatR;
using Application.Common.Enums;
using Microsoft.Extensions.Caching.Memory;
using Application.Services.GoogleFlightsGateway;
using Application.Services.RouteProviderGateway;

namespace Application.Features.Routes.Queries.GetRoutesSearch;

public class GetRoutesSearchQueryHandler : IRequestHandler<GetRoutesSearchQuery, List<GetRoutesSearchViewModel>>
{
    private readonly IMemoryCache _cache;
    private readonly IKiwiGatewayService _kiwiGatewayService;
    private readonly IGoogleFlightsGatewayService _googleFlightsGatewayService;

    public GetRoutesSearchQueryHandler(IKiwiGatewayService kiwiGatewayService,
                                       IGoogleFlightsGatewayService googleFlightsGatewayService,
                                       IMemoryCache cache)
    {
        _kiwiGatewayService = kiwiGatewayService;
        _googleFlightsGatewayService = googleFlightsGatewayService;
        _cache = cache;
    }

    public Task<List<GetRoutesSearchViewModel>> Handle(GetRoutesSearchQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = request.Base64();

        if (_cache.TryGetValue(cacheKey, out List<GetRoutesSearchViewModel> resultCache))
        {
            if (resultCache.Count > 0)
                return Task.FromResult(resultCache);
        }

        var tasks = new List<Task>();

        var kiwiTaskResponse = _kiwiGatewayService.SearchRoute(request);
        var googleFlightsTaskResponse = _googleFlightsGatewayService.SearchRoute(request);

        tasks.Add(kiwiTaskResponse);
        tasks.Add(googleFlightsTaskResponse);

        Task.WaitAll(tasks.ToArray(), cancellationToken);

        var result = kiwiTaskResponse.Result;
        result.AddRange(googleFlightsTaskResponse.Result);

        result = Filtering(result, request);
        result = Sorting(result, request);

        if (!string.IsNullOrEmpty(cacheKey) && result.Count > 0)
            _cache.Set(cacheKey, result, TimeSpan.FromMinutes(15));

        return Task.FromResult(result);
    }

    private List<GetRoutesSearchViewModel> Filtering(List<GetRoutesSearchViewModel> result, GetRoutesSearchQuery request)
    {
        result = result.Where(x => x.Routes.Any(x => x.Segments.Any(x => x.DepartureAirport.FlightAt >= request.Flight.DepartureDate))).ToList();
        result = result.Where(x => x.ClassTypeCode == request.ClassTypeCode).ToList();
        result = result.Where(x => x.CurrencyIsoCode == request.CurrencyIsoCode).ToList();
        result = result.Where(x => x.Routes.Any(x => x.DepartureAirport.Code == request.Flight.From)).ToList();
        result = result.Where(x => x.Routes.Any(x => x.ArrivalAirport.Code == request.Flight.To)).ToList();

        if (request.Filters != null)
        {
            if (request.Filters.FromPrice.HasValue)
                result = result.Where(x => x.Price >= request.Filters.FromPrice.Value).ToList();

            if (request.Filters.ToPrice.HasValue)
                result = result.Where(x => x.Price >= request.Filters.ToPrice.Value).ToList();

            if (!string.IsNullOrWhiteSpace(request.Filters.AirlineCode))
                result = result.Where(x => x.Routes.Any(x => x.Segments.Any(x => x.AirlineCode == request.Filters.AirlineCode))).ToList();

            if (!string.IsNullOrWhiteSpace(request.Filters.AirlineName))
                result = result.Where(x => x.Routes.Any(x => x.Segments.Any(x => !string.IsNullOrEmpty(x.AirlineName) &&
                                                                                x.AirlineName.ToLower().Contains(request.Filters.AirlineName.ToLower())))).ToList();

            if (request.Filters.StopsCount.HasValue)
                result = result.Where(x => x.Routes.Any(x => x.Segments.Count == request.Filters.StopsCount)).ToList();
        }

        return result;
    }

    private List<GetRoutesSearchViewModel> Sorting(List<GetRoutesSearchViewModel> result, GetRoutesSearchQuery request)
    {
        if (request.Sort != null)
        {
            switch (request.Sort.Property)
            {
                case RoteSortEnum.DepartureDate:
                    result = request.Sort.Desc ? result.OrderByDescending(x => x.Routes.First().Segments.First().DepartureAirport.FlightAt).ToList() :
                                                 result.OrderBy(x => x.Routes.First().Segments.First().DepartureAirport.FlightAt).ToList();
                    break;
                case RoteSortEnum.Price:
                    result = request.Sort.Desc ? result.OrderByDescending(x => x.Price).ToList() :
                                                 result.OrderBy(x => x.Price).ToList();
                    break;
                case RoteSortEnum.StopsCount:
                    result = request.Sort.Desc ? result.OrderByDescending(x => x.Routes.First().Segments.Count).ToList() :
                                                 result.OrderBy(x => x.Routes.First().Segments.Count).ToList();
                    break;
                case RoteSortEnum.Airline:
                    result = request.Sort.Desc ? result.OrderByDescending(x => x.Routes.First().Segments.First().AirlineName).ToList() :
                                                 result.OrderBy(x => x.Routes.First().Segments.First().AirlineName).ToList();
                    break;
                default:
                    result = result.OrderBy(x => x.Routes.First().Segments.First().DepartureAirport.FlightAt).ToList();
                    break;
            }
        }

        return result;
    }
}