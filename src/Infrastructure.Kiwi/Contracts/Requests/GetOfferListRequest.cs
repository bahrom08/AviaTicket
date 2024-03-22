using Newtonsoft.Json;

namespace Infrastructure.Kiwi.Contracts.Requests;

public class GetOfferListRequest
{
    public Data Data { get; set; }
}

public class Data
{
    [JsonProperty("slices")]
    public List<Slice> Slices { get; set; }

    [JsonProperty("passengers")]
    public List<Passenger> Passengers { get; set; }

    [JsonProperty("cabin_class")]
    public string CabinClass { get; set; }

    [JsonProperty("currency")]
    public string CurrencyCode { get; set; }
}


public class Passenger
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("age")]
    public int? Age { get; set; }
}

public class Slice
{
    [JsonProperty("origin")]
    public string Origin { get; set; }

    [JsonProperty("destination")]
    public string Destination { get; set; }

    [JsonProperty("departure_date")]
    public DateTime DepartureDate { get; set; }

    [JsonProperty("arrival_date")]
    public DateTime ArrivalDate { get; set; }
}