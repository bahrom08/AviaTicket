using Domain.Common;

namespace Domain.Entities.Users;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }
    public string? Password { get; set; }
    public string? PasswordSalt { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Guid CitizenshipId { get; set; }
    public int Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Guid? PassportTypeId { get; set; }
    public string PasportNumber { get; set; }
    public Guid CurrencyId { get; set; }
    public DateTime PassportExpiredAt { get; set; }
}