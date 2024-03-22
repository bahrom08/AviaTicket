using Newtonsoft.Json;

namespace Infrastructure.GoogleFlights.Contracts.Responses;

public class SearchFlightsResponse
{
    [JsonProperty("status")]
    public bool Status { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("data")]
    public Data Data { get; set; }
}

public class Carriers
{
    [JsonProperty("marketing")]
    public List<Marketing> Marketing { get; set; }

    [JsonProperty("operationType")]
    public string OperationType { get; set; }
}

public class Context
{
    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("sessionId")]
    public string SessionId { get; set; }

    [JsonProperty("totalResults")]
    public int TotalResults { get; set; }
}

public class Data
{
    [JsonProperty("token")]
    public string Token { get; set; }

    [JsonProperty("context")]
    public Context Context { get; set; }

    [JsonProperty("itineraries")]
    public List<Itinerary> Itineraries { get; set; }
}

public class Destination
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("displayCode")]
    public string DisplayCode { get; set; }

    [JsonProperty("city")]
    public string City { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("isHighlighted")]
    public bool IsHighlighted { get; set; }

    [JsonProperty("flightPlaceId")]
    public string FlightPlaceId { get; set; }

    [JsonProperty("parent")]
    public Parent Parent { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }
}

public class FareAttributes
{
}

public class FarePolicy
{
    [JsonProperty("isChangeAllowed")]
    public bool IsChangeAllowed { get; set; }

    [JsonProperty("isPartiallyChangeable")]
    public bool IsPartiallyChangeable { get; set; }

    [JsonProperty("isCancellationAllowed")]
    public bool IsCancellationAllowed { get; set; }

    [JsonProperty("isPartiallyRefundable")]
    public bool IsPartiallyRefundable { get; set; }
}

public class Itinerary
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("price")]
    public Price Price { get; set; }

    [JsonProperty("fareClass")]
    public string FareClassCode { get; set; }

    [JsonProperty("legs")]
    public List<Leg> Legs { get; set; }

    [JsonProperty("isSelfTransfer")]
    public bool IsSelfTransfer { get; set; }

    [JsonProperty("isProtectedSelfTransfer")]
    public bool IsProtectedSelfTransfer { get; set; }

    [JsonProperty("farePolicy")]
    public FarePolicy FarePolicy { get; set; }

    [JsonProperty("fareAttributes")]
    public FareAttributes FareAttributes { get; set; }

    [JsonProperty("isMashUp")]
    public bool IsMashUp { get; set; }

    [JsonProperty("hasFlexibleOptions")]
    public bool HasFlexibleOptions { get; set; }

    [JsonProperty("score")]
    public double Score { get; set; }

    public DateTime ExpiredAt { get; set; }
}

public class Leg
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("origin")]
    public Origin Origin { get; set; }

    [JsonProperty("destination")]
    public Destination Destination { get; set; }

    [JsonProperty("durationInMinutes")]
    public int DurationInMinutes { get; set; }

    [JsonProperty("stopCount")]
    public int StopCount { get; set; }

    [JsonProperty("isSmallestStops")]
    public bool IsSmallestStops { get; set; }

    [JsonProperty("departure")]
    public DateTime DepartureAt { get; set; }

    [JsonProperty("arrival")]
    public DateTime ArrivalAt { get; set; }

    [JsonProperty("timeDeltaInDays")]
    public int TimeDeltaInDays { get; set; }

    [JsonProperty("carriers")]
    public Carriers Carriers { get; set; }

    [JsonProperty("segments")]
    public List<Segment> Segments { get; set; }
}

public class Marketing
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("logoUrl")]
    public string LogoUrl { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }
}

public class MarketingCarrier
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("alternateId")]
    public string AlternateId { get; set; }

    [JsonProperty("allianceId")]
    public int AllianceId { get; set; }

    [JsonProperty("displayCode")]
    public string DisplayCode { get; set; }
}

public class OperatingCarrier
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("alternateId")]
    public string AlternateId { get; set; }

    [JsonProperty("allianceId")]
    public int AllianceId { get; set; }

    [JsonProperty("displayCode")]
    public string DisplayCode { get; set; }
}

public class Origin
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("displayCode")]
    public string DisplayCode { get; set; }

    [JsonProperty("city")]
    public string City { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("isHighlighted")]
    public bool IsHighlighted { get; set; }

    [JsonProperty("flightPlaceId")]
    public string FlightPlaceId { get; set; }

    [JsonProperty("parent")]
    public Parent Parent { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }
}

public class Parent
{
    [JsonProperty("flightPlaceId")]
    public string FlightPlaceId { get; set; }

    [JsonProperty("displayCode")]
    public string DisplayCode { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }
}

public class Price
{
    [JsonProperty("raw")]
    public decimal Raw { get; set; }

    [JsonProperty("formatted")]
    public string Formatted { get; set; }

    [JsonProperty("pricingOptionId")]
    public string PricingOptionId { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; }
}

public class Segment
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("origin")]
    public Origin Origin { get; set; }

    [JsonProperty("destination")]
    public Destination Destination { get; set; }

    [JsonProperty("departure")]
    public DateTime DepartureAt { get; set; }

    [JsonProperty("arrival")]
    public DateTime ArrivalAt { get; set; }

    [JsonProperty("durationInMinutes")]
    public int DurationInMinutes { get; set; }

    [JsonProperty("flightNumber")]
    public string FlightNumber { get; set; }

    [JsonProperty("marketingCarrier")]
    public MarketingCarrier MarketingCarrier { get; set; }

    [JsonProperty("operatingCarrier")]
    public OperatingCarrier OperatingCarrier { get; set; }
}

