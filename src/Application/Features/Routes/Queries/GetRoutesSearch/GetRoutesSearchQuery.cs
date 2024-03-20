namespace Application.Features.Routes.Queries.GetRoutesSearch;

public class GetRoutesSearchQuery
{
    public string ClassTypeCode { get; set; }
    public string CurrencyIsoCode { get; set; }
    public FlightDto Flight { get; set; }
    public FlightDto ReturnFlight { get; set; }
    public List<PassengersDto> Passengers { get; set; }
}

public class FlightDto
{
    public string From { get; set; }
    public string To { get; set; }
    public DateOnly DepartureDate { get; set; }
}

public class PassengersDto
{
    public int Count { get; set; }
    public string Type { get; set; }
}