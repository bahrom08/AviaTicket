using Domain.Common;

namespace Domain.Entities.Orders;

public class OrderStatus : BaseEntity
{
    public string Name { get; set; }
    public string Code { get; set; }
}