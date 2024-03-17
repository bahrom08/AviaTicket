using Domain.Common;

namespace Domain.Entities.Orders;

public class OrderPassenger : BaseEntity
{
    public Guid OrderId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int GenderId { get; set; }

    public Order Order { get; set; }
}

public class PessengerDocument
{
    public Guid CitizenshipId { get; set; }
    public string CitizenshipCode { get; set; }
}