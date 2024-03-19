using Domain.Common;
using Domain.Entities.Regions;
using Domain.Enums.DocumentTypes;
using Domain.Enums.Genders;

namespace Domain.Entities.Orders;

public class OrderPassenger : BaseEntity
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public GenderEnum Gender { get; set; }
    public Guid CitizenshipId { get; set; }
    public Country Citizenship { get; set; }
    public PassengerDocumentTypeEnum DocumentType { get; set; }
    public string DocumentNumber { get; set; }
    public DateOnly? IssueAt { get; set; }
    public DateOnly? ExpiredAt { get; set; }
}