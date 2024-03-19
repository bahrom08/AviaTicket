using Domain.Common;

namespace Domain.Entities.Regions;

public class City : BaseEntity
{
    public string Name { get; set; }
    public string IATACode { get; set; }
    public Guid CountryId { get; set; }
    public Country Country { get; set; }
}