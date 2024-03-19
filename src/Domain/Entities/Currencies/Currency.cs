using Domain.Common;

namespace Domain.Entities.Currencies;

public class Currency : BaseEntity
{
    public string Name { get; set; }
    public string IsoNum { get; set; }
    public string IsoCode { get; set; }
    public decimal Rate { get; set; }
}