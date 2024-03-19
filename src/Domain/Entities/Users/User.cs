using Domain.Common;
using Domain.Entities.Regions;
using Domain.Entities.Currencies;

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
    public DateTime? LastLoginAt { get; set; }
    public Guid? CitizenshipId { get; set; }
    public Country Citizenship { get; set; }
    public Guid? CityResidenceId { get; set; }
    public City CityResidence { get; set; }
    public int Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public Guid? CurrencyId { get; set; }
    public Currency Currency { get; set; }
}