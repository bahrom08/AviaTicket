using Domain.Common;
using Domain.Entities.Regions;

namespace Domain.Entities.Airports;

public class Airport : BaseEntity
{
    public string Name { get; set; }
    public Guid CityId { get; set; }
    public City City { get; set; }
    public string IATACode { get; set; }
}