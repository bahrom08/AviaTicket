namespace Application.Features.Routes.Queries.GetRoutesSearch;

public class GetRoutesSearchViewModel
{
    public string OfferId { get; set; }
    public List<string> OfferItemIds { get; set; }
    public DateTime TimeLimit { get; set; }
    public decimal Price { get; set; }
    public string CurrencyIsoCode { get; set; }
    public List<RouteDto> Routes { get; set; }
}

public class RouteDto
{
    public int DurationInSeconds { get; set; }
    public List<Segment> Segments { get; set; }
}

public class Segment
{
    public string Number { get; set; }
    public string AirlineName { get; set; }
    public string AirlineCode { get; set; }
    public string Aircraft { get; set; }
    public int DurationInSeconds { get; set; }
    public int DistanceInKm { get; set; }
    public bool CanRefund { get; set; }
    public bool CanChange { get; set; }
    public string ClassTypeCode { get; set; }
    public List<BaggageDto> Baggages { get; set; }
    public AirportDto ArrivalAirport { get; set; }
    public AirportDto DepartureAirport { get; set; }
}

public class BaggageDto
{
    public string TypeCode { get; set; }
    public int Weight { get; set; }
    public int Count { get; set; }
}

public class AirportDto
{
    public DateTime FlightAt { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public CityDto City { get; set; }
    public string? Terminal { get; set; }
}

public class CityDto
{
    public string Name { get; set; }
    public string Code { get; set; }
}