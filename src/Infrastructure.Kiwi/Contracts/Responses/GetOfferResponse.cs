using Newtonsoft.Json;

namespace Infrastructure.Kiwi.Contracts.Responses;
public class GetOfferResponse
{
    [JsonProperty("offer")]
    public Offer Offer { get; set; }
}

