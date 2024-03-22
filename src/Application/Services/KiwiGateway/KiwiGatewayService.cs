using Infrastructure.Kiwi.Services;
using System.Text.RegularExpressions;
using Infrastructure.Kiwi.Contracts.Requests;
using Application.Features.Routes.Queries.GetRoutesSearch;
using Domain.Enums.GatewayProvider;
using RequestData = Infrastructure.Kiwi.Contracts.Requests.Data;
using Application.Common.Exceptions;

namespace Application.Services.RouteProviderGateway;

public class KiwiGatewayService : IKiwiGatewayService
{
    private readonly IKiwiService _kiwiService;

    public KiwiGatewayService(IKiwiService kiwiService)
    {
        _kiwiService = kiwiService;
    }

    public async Task<List<GetRoutesSearchViewModel>> SearchRoute(GetRoutesSearchQuery query)
    {
        var request = new GetOfferListRequest
        {
            Data = new RequestData
            {
                CabinClass = query.ClassTypeCode,
                Passengers = query.Passengers.SelectMany(dto =>
                               Enumerable.Range(1, dto.Count)
                               .Select(_ => new Passenger { Type = dto.Type }))
                               .ToList(),
                Slices = new List<Slice>
                {
                    new Slice
                    {
                        Origin = query.Flight.From,
                        Destination = query.Flight.To,
                        DepartureDate = query.Flight.DepartureDate,
                        ArrivalDate = query.ReturnFlight != null ? query.ReturnFlight.DepartureDate : default
                    }
                }
            }
        };

        var response = await _kiwiService.GetOfferList(request);

        return response.Data.Offers.Select(offer => new GetRoutesSearchViewModel
        {
            CanChange = offer.Conditions.ChangeBeforeDeparture.Allowed,
            CanRefund = offer.Conditions.RefundBeforeDeparture.Allowed,
            ClassTypeCode = offer.CabinClass,
            CurrencyIsoCode = offer.Currency,
            GatewayProviderId = GatewayProviderEnum.Kiwi.Value,
            OfferId = offer.Id,
            Price = offer.Amount,
            ExpiredAt = offer.ExpiresAt,
            Routes = offer.Slices.Select(slice => new RouteDto
            {
                DepartureAirport = new AirportDto
                {
                    Name = slice.Origin.Name,
                    City = new CityDto
                    {
                        Code = slice.Origin.City.IataCode,
                        Name = slice.Origin.City.Name
                    },
                    Code = slice.Origin.IataCode,
                    FlightAt = slice.ArrivingAt
                },
                ArrivalAirport = new AirportDto
                {
                    Name = slice.Destination.Name,
                    City = new CityDto
                    {
                        Code = slice.Destination.City.IataCode,
                        Name = slice.Destination.City.Name
                    },
                    Code = slice.Destination.IataCode,
                    FlightAt = slice.DepartingAt
                },
                DurationInSeconds = ParseIso8601Duration(slice.Duration),
                Segments = slice.Segments.Select(segment => new Segment
                {
                    Aircraft = segment.Aircraft.Name,
                    AirlineCode = segment.Airline.IataCode,
                    AirlineName = segment.Airline.Name,
                    DepartureAirport = new AirportDto
                    {
                        Name = segment.Origin.Name,
                        City = new CityDto
                        {
                            Code = segment.Origin.City.IataCode,
                            Name = segment.Origin.City.Name
                        },
                        Code = segment.Origin.IataCode,
                        FlightAt = segment.ArrivingAt,
                        Terminal = segment.OriginTerminal
                    },
                    Baggages = segment.Passengers.SelectMany(p => p.Baggages.Select(b => new BaggageDto
                    {
                        Count = b.Quantity,
                        TypeCode = b.Type
                    })).ToList(),
                    ArrivalAirport = new AirportDto
                    {
                        Name = segment.Destination.Name,
                        City = new CityDto
                        {
                            Code = segment.Destination.City.IataCode,
                            Name = segment.Destination.City.Name
                        },
                        Code = segment.Destination.IataCode,
                        FlightAt = segment.DepartingAt,
                        Terminal = segment.DestinationTerminal
                    },
                    DistanceInKm = segment.Distance,
                    DurationInSeconds = ParseIso8601Duration(segment.Duration),
                    Number = segment.Id
                }).ToList()
            }).ToList()
        }).ToList();
    }

    public async Task<GetRoutesSearchViewModel> GetOffer(string offerId)
    {
        var offerResult = await _kiwiService.GetOffer(offerId)
            ?? throw new LogicException("Предложение не найдено");
       
        var offer = offerResult.Offer;

        return new GetRoutesSearchViewModel
        {
            CanChange = offer.Conditions.ChangeBeforeDeparture.Allowed,
            CanRefund = offer.Conditions.RefundBeforeDeparture.Allowed,
            ClassTypeCode = offer.CabinClass,
            CurrencyIsoCode = offer.Currency,
            GatewayProviderId = GatewayProviderEnum.Kiwi.Value,
            OfferId = offer.Id,
            Price = offer.Amount,
            ExpiredAt = offer.ExpiresAt,
            Routes = offer.Slices.Select(slice => new RouteDto
            {
                DepartureAirport = new AirportDto
                {
                    Name = slice.Origin.Name,
                    City = new CityDto
                    {
                        Code = slice.Origin.City?.IataCode,
                        Name = slice.Origin.City?.Name
                    },
                    Code = slice.Origin.IataCode,
                    FlightAt = slice.ArrivingAt,
                },
                ArrivalAirport = new AirportDto
                {
                    Name = slice.Destination.Name,
                    City = new CityDto
                    {
                        Code = slice.Destination.City?.IataCode,
                        Name = slice.Destination.City?.Name
                    },
                    Code = slice.Destination.IataCode,
                    FlightAt = slice.DepartingAt,
                },
                DurationInSeconds = ParseIso8601Duration(slice.Duration),
                Segments = slice.Segments.Select(segment => new Segment
                {
                    Aircraft = segment.Aircraft.Name,
                    AirlineCode = segment.Airline.IataCode,
                    AirlineName = segment.Airline.Name,
                    DepartureAirport = new AirportDto
                    {
                        Name = segment.Origin.Name,
                        City = new CityDto
                        {
                            Code = segment.Origin.City.IataCode,
                            Name = segment.Origin.City.Name
                        },
                        Code = segment.Origin.IataCode,
                        FlightAt = segment.ArrivingAt,
                        Terminal = segment.OriginTerminal
                    },
                    Baggages = segment.Passengers.SelectMany(p => p.Baggages.Select(b => new BaggageDto
                    {
                        Count = b.Quantity,
                        TypeCode = b.Type
                    })).ToList(),
                    ArrivalAirport = new AirportDto
                    {
                        Name = segment.Destination.Name,
                        City = new CityDto
                        {
                            Code = segment.Destination.City.IataCode,
                            Name = segment.Destination.City.Name
                        },
                        Code = segment.Destination.IataCode,
                        FlightAt = segment.DepartingAt,
                        Terminal = segment.DestinationTerminal
                    },
                    DistanceInKm = segment.Distance,
                    DurationInSeconds = ParseIso8601Duration(segment.Duration),
                    Number = segment.Id
                }).ToList()
            }).ToList()
        };
    }

    private static int ParseIso8601Duration(string durationStr)
    {
        string pattern = @"PT(?:(?<hours>\d{1,2})H)?(?:(?<minutes>\d{1,2})M)?(?:(?<seconds>\d{1,2})S)?";

        Match match = Regex.Match(durationStr, pattern);

        int hours = match.Groups["hours"].Success ? int.Parse(match.Groups["hours"].Value) : 0;
        int minutes = match.Groups["minutes"].Success ? int.Parse(match.Groups["minutes"].Value) : 0;
        int seconds = match.Groups["seconds"].Success ? int.Parse(match.Groups["seconds"].Value) : 0;

        int totalSeconds = hours * 3600 + minutes * 60 + seconds;

        return totalSeconds;
    }
}