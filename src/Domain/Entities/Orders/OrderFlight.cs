using Domain.Common;
using Domain.Entities.Airlains;
using Domain.Entities.Airports;
using Domain.Enums.ClassTypes;

namespace Domain.Entities.Orders;

public class OrderFlight : BaseEntity
{
    public Guid RoteId { get; set; }
    public OrderRoute OrderRoute { get; set; }
    public string Number { get; set; }
    public Guid AirlineId { get; set; }
    public Airlain Airlain { get; set; }
    public string? Aircraft { get; set; }
    public int DurationInSeconds { get; set; }
    public double DistanceInKm { get; set; }
    public ClassTypeEnum ClassType { get; set; }
    public ICollection<FlightBaggage> BaggageJson { get; set; }
    public Guid ArrivalAirportId { get; set; }
    public Airport ArrivalAirport { get; set; }
    public Guid DepatureAirportId { get; set; }
    public Airport DepatureAirport { get; set; }
}

public class FlightBaggage
{
    public string BaggageTypeName { get; set; }
    public int Weight { get; set; }
    public int Count { get; set; }
}