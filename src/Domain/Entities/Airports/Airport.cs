using Domain.Common;

namespace Domain.Entities.Airports;

public class Airport : BaseEntity
{
    public string Name { get; set; }
    public Guid CityId { get; set; }
    public string IATACode { get; set; }
}