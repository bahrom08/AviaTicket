using Newtonsoft.Json;

namespace Infrastructure.Kiwi.Contracts.Responses;

public class GetOfferListResponse
{
    [JsonProperty("data")]
    public Data Data { get; set; }
}

public class Aircraft
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("iata_code")]
    public string IataCode { get; set; }
}

public class Airport
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("time_zone")]
    public string TimeZone { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("longitude")]
    public double Longitude { get; set; }

    [JsonProperty("latitude")]
    public double Latitude { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("icao_code")]
    public string IcaoCode { get; set; }

    [JsonProperty("iata_code")]
    public string IataCode { get; set; }

    [JsonProperty("city")]
    public City City { get; set; }
}

public class Amenities
{
    [JsonProperty("wifi")]
    public Wifi Wifi { get; set; }

    [JsonProperty("seat")]
    public Seat Seat { get; set; }

    [JsonProperty("power")]
    public Power Power { get; set; }
}

public class Baggage
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("quantity")]
    public int Quantity { get; set; }
}

public class Cabin
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("marketing_name")]
    public string MarketingName { get; set; }

    [JsonProperty("amenities")]
    public Amenities Amenities { get; set; }
}

public class ChangeBeforeDeparture
{
    [JsonProperty("penalty_currency")]
    public string PenaltyCurrency { get; set; }

    [JsonProperty("penalty_amount")]
    public decimal PenaltyAmount { get; set; }

    [JsonProperty("allowed")]
    public bool Allowed { get; set; }
}

public class City
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("iata_country_code")]
    public string IataCountryCode { get; set; }

    [JsonProperty("iata_code")]
    public string IataCode { get; set; }
}

public class Conditions
{
    [JsonProperty("change_before_departure")]
    public ChangeBeforeDeparture ChangeBeforeDeparture { get; set; }

    [JsonProperty("refund_before_departure")]
    public RefundBeforeDeparture RefundBeforeDeparture { get; set; }
}

public class Data
{
    [JsonProperty("offers")]
    public List<Offer> Offers { get; set; }
}

public class Offer
{
    [JsonProperty("currency")]
    public string Currency { get; set; }

    [JsonProperty("amount")]
    public decimal Amount { get; set; }

    [JsonProperty("slices")]
    public List<Slice> Slices { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("expires_at")]
    public DateTime ExpiresAt { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("conditions")]
    public Conditions Conditions { get; set; }

    [JsonProperty("cabin_class")]
    public string CabinClass { get; set; }
}

public class Passenger
{
    [JsonProperty("passenger_id")]
    public string PassengerId { get; set; }

    [JsonProperty("fare_basis_code")]
    public string FareBasisCode { get; set; }

    [JsonProperty("cabin_class_marketing_name")]
    public string CabinClassMarketingName { get; set; }

    [JsonProperty("cabin_class")]
    public string CabinClass { get; set; }

    [JsonProperty("cabin")]
    public Cabin Cabin { get; set; }

    [JsonProperty("baggages")]
    public List<Baggage> Baggages { get; set; }
}

public class Power
{
    [JsonProperty("available")]
    public string Available { get; set; }
}

public class RefundBeforeDeparture
{
    [JsonProperty("penalty_currency")]
    public string PenaltyCurrency { get; set; }

    [JsonProperty("penalty_amount")]
    public decimal PenaltyAmount { get; set; }

    [JsonProperty("allowed")]
    public bool Allowed { get; set; }
}

public class Seat
{
    [JsonProperty("pitch")]
    public string Pitch { get; set; }

    [JsonProperty("legroom")]
    public string Legroom { get; set; }
}

public class Segment
{
    [JsonProperty("passengers")]
    public List<Passenger> Passengers { get; set; }

    [JsonProperty("origin_terminal")]
    public string OriginTerminal { get; set; }

    [JsonProperty("origin")]
    public Airport Origin { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("duration")]
    public string Duration { get; set; }

    [JsonProperty("distance")]
    public double Distance { get; set; }

    [JsonProperty("destination_terminal")]
    public string DestinationTerminal { get; set; }

    [JsonProperty("destination")]
    public Airport Destination { get; set; }    

    [JsonProperty("departing_at")]
    public DateTime DepartingAt { get; set; }

    [JsonProperty("arriving_at")]
    public DateTime ArrivingAt { get; set; }

    [JsonProperty("aircraft")]
    public Aircraft Aircraft { get; set; }

    [JsonProperty("airline")]
    public Airline Airline { get; set; }
}

public class Airline
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string IataCode { get; set; }
}

public class Slice
{
    [JsonProperty("segments")]
    public List<Segment> Segments { get; set; }

    [JsonProperty("origin_type")]
    public string OriginType { get; set; }

    [JsonProperty("origin")]
    public Airport Origin { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("duration")]
    public string Duration { get; set; }

    [JsonProperty("destination_type")]
    public string DestinationType { get; set; }

    [JsonProperty("destination")]
    public Airport Destination { get; set; }

    [JsonProperty("departing_at")]
    public DateTime DepartingAt { get; set; }

    [JsonProperty("arriving_at")]
    public DateTime ArrivingAt { get; set; }
}

public class Wifi
{
    [JsonProperty("cost")]
    public string Cost { get; set; }

    [JsonProperty("available")]
    public string Available { get; set; }
}

