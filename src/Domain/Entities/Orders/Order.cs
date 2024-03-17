using Domain.Common;
using System.ComponentModel;

namespace Domain.Entities.Orders;

public class Order : BaseEntity 
{
    public string OfferId { get; set; }
    public string ExtId { get; set; }
    public decimal Price { get; set; }
    public decimal BaggagePrice { get; set; }
    public Guid CurrencyId { get; set; }
    public decimal CurrencyRate { get; set; }
    public string? TicketNumber { get; set; }
    public Guid OrderStatusId { get; set; }
    public Guid UserId { get; set; }
    public ICollection<OrderRoute> OrderRoutes { get; set; }
    public ICollection<OrderPassenger> OrderPassengers { get; set; }
}