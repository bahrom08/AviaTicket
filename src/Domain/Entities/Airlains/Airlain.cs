using Domain.Common;

namespace Domain.Entities.Airlains;

public class Airlain : BaseEntity
{
    public string Name { get; set; }
    public string IATACode { get; set; }
}