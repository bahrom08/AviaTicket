using Application.Features.Routes.Queries.GetRoutesSearch;
using Infrastructure.GoogleFlights.Services;
using Infrastructure.GoogleFlights.Contracts.Requests;
using Domain.Enums.GatewayProvider;
using Domain.Enums.Passengers;
using Application.Common.Exceptions;

namespace Application.Services.GoogleFlightsGateway;
public class GoogleFlightsGatewayService : IGoogleFlightsGatewayService
{
    private readonly IGoogleFlightsService _googleFlightsService;

    public GoogleFlightsGatewayService(IGoogleFlightsService googleFlightsService)
    {
        _googleFlightsService = googleFlightsService;
    }

    public async Task<GetRoutesSearchViewModel> GetOffer(string offerId)
    {
        var offer = await _googleFlightsService.GetFlight(offerId)
            ?? throw new LogicException("Предложение не найдено");

        return new GetRoutesSearchViewModel
        {
            GatewayProviderId = GatewayProviderEnum.GoogleFlights.Value,
            CanChange = offer.FarePolicy.IsChangeAllowed,
            CanRefund = offer.FarePolicy.IsCancellationAllowed,
            ClassTypeCode = offer.FareClassCode,
            CurrencyIsoCode = offer.Price.Currency,
            Price = offer.Price.Raw,
            OfferId = offer.Id,
            ExpiredAt = offer.ExpiredAt,
            Routes = offer.Legs.Select(route => new RouteDto
            {
                ArrivalAirport = new AirportDto
                {
                    Name = route.Destination.Name,
                    City = new CityDto
                    {
                        Name = route.Destination.Parent.Name,
                        Code = route.Destination.Parent.DisplayCode
                    },
                    Code = route.Destination.DisplayCode,
                    FlightAt = route.ArrivalAt
                },
                DepartureAirport = new AirportDto
                {
                    Name = route.Origin.Name,
                    City = new CityDto
                    {
                        Name = route.Origin.Parent.Name,
                        Code = route.Origin.Parent.DisplayCode
                    },
                    Code = route.Origin.DisplayCode,
                    FlightAt = route.DepartureAt
                },
                DurationInSeconds = route.DurationInMinutes * 60,
                Segments = route.Segments.Select(segment => new Segment
                {
                    AirlineCode = segment.MarketingCarrier.AlternateId,
                    AirlineName = segment.MarketingCarrier.Name,
                    ArrivalAirport = new AirportDto
                    {
                        Name = segment.Destination.Name,
                        City = new CityDto
                        {
                            Name = segment.Destination.Parent.Name,
                            Code = segment.Destination.Parent.DisplayCode
                        },
                        Code = segment.Destination.DisplayCode,
                        FlightAt = segment.ArrivalAt
                    },
                    DepartureAirport = new AirportDto
                    {
                        Name = segment.Origin.Name,
                        City = new CityDto
                        {
                            Name = segment.Origin.Parent.Name,
                            Code = segment.Origin.Parent.DisplayCode
                        },
                        Code = segment.Origin.DisplayCode,
                        FlightAt = segment.DepartureAt
                    },
                    DurationInSeconds = segment.DurationInMinutes * 60,
                    Number = segment.FlightNumber
                }).ToList(),
            }).ToList()
        };
    }

    public async Task<List<GetRoutesSearchViewModel>> SearchRoute(GetRoutesSearchQuery query)
    {
        var request = new SearchFlightsRequest
        {
            From = query.Flight.From,
            To = query.Flight.To,
            DepartDate = query.Flight.DepartureDate,
            ReturnDate = query.ReturnFlight != null ? query.ReturnFlight.DepartureDate : default,
            Currency = query.CurrencyIsoCode,
            AdultsCount = query.Passengers.Where(x => x.Type == PassengerTypeEnum.Adult.Value).Count(),
            ChildrenCount = query.Passengers.Where(x => x.Type == PassengerTypeEnum.Child.Value).Count(),
            InfantsCount = query.Passengers.Where(x => x.Type == PassengerTypeEnum.Infant.Value).Count(),
        };

        var response = await _googleFlightsService.SearchFlights(request);

        return response.Data.Itineraries.Select(offer => new GetRoutesSearchViewModel
        {
            GatewayProviderId = GatewayProviderEnum.GoogleFlights.Value,
            CanChange = offer.FarePolicy.IsChangeAllowed,
            CanRefund = offer.FarePolicy.IsCancellationAllowed,
            ClassTypeCode = offer.FareClassCode,
            CurrencyIsoCode = offer.Price.Currency,
            Price = offer.Price.Raw,
            OfferId = offer.Id,
            ExpiredAt = offer.ExpiredAt,
            Routes = offer.Legs.Select(route => new RouteDto
            {
                ArrivalAirport = new AirportDto
                {
                    Name = route.Destination.Name,
                    City = new CityDto
                    {
                        Name = route.Destination.Parent?.Name,
                        Code = route.Destination.Parent?.DisplayCode
                    },
                    Code = route.Destination.DisplayCode,
                    FlightAt = route.ArrivalAt
                },
                DepartureAirport = new AirportDto
                {
                    Name = route.Origin.Name,
                    City = new CityDto
                    {
                        Name = route.Origin.Parent?.Name,
                        Code = route.Origin.Parent?.DisplayCode
                    },
                    Code = route.Origin.DisplayCode,
                    FlightAt = route.DepartureAt
                },
                DurationInSeconds = route.DurationInMinutes * 60,
                Segments = route.Segments.Select(segment => new Segment
                {
                    AirlineCode = segment.MarketingCarrier.AlternateId,
                    AirlineName = segment.MarketingCarrier.Name,
                    ArrivalAirport = new AirportDto
                    {
                        Name = segment.Destination.Name,
                        City = new CityDto
                        {
                            Name = segment.Destination.Parent.Name,
                            Code = segment.Destination.Parent.DisplayCode
                        },
                        Code = segment.Destination.DisplayCode,
                        FlightAt = segment.ArrivalAt
                    },
                    DepartureAirport = new AirportDto
                    {
                        Name = segment.Origin.Name,
                        City = new CityDto
                        {
                            Name = segment.Origin.Parent.Name,
                            Code = segment.Origin.Parent.DisplayCode
                        },
                        Code = segment.Origin.DisplayCode,
                        FlightAt = segment.DepartureAt
                    },
                    DurationInSeconds = segment.DurationInMinutes * 60,
                    Number = segment.FlightNumber
                }).ToList(),
            }).ToList()

        }).ToList();
    }
}