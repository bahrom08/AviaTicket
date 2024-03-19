using Domain.Common;
using Domain.Entities.Airports;

namespace Domain.Entities.Orders;

public class OrderRoute : BaseEntity
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
    public int DurationInSeconds { get; set; }
    public bool CanRefund { get; set; }
    public bool CanChange { get; set; }
    public Guid ArrivalAirportId { get; set; }
    public Airport ArrivalAirport { get; set; }
    public DateTime ArrivalAt { get; set; }
    public Guid DepartureAirportId { get; set; }
    public Airport DepartureAirport { get; set; }
    public DateTime DepartureAt { get; set; }

    public ICollection<OrderFlight> OrderFlights { get; set; }
}