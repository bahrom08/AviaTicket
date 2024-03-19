using Domain.Common;

namespace Domain.Entities.Regions;

public class Country: BaseEntity
{
    public string Name { get; set; }
    public string Code { get; set; }
}