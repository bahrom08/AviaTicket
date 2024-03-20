using Newtonsoft.Json;

namespace Infrastructure.GoogleFlights.Contracts.Responses;

public class GetItinerariesResponse
{
    [JsonProperty("itineraries")]
    public List<Itinerary> Itineraries { get; set; }

    [JsonProperty("legs")]
    public List<Leg> Legs { get; set; }

    [JsonProperty("segments")]
    public List<Segment> Segments { get; set; }
}

public class BookingMetadata
{
    [JsonProperty("metadata_set")]
    public string MetadataSet { get; set; }

    [JsonProperty("signature")]
    public string Signature { get; set; }
}

public class CheapestPrice
{
    [JsonProperty("amount")]
    public double Amount { get; set; }

    [JsonProperty("update_status")]
    public string UpdateStatus { get; set; }

    [JsonProperty("last_updated")]
    public DateTime LastUpdated { get; set; }

    [JsonProperty("quote_age")]
    public int QuoteAge { get; set; }
}

public class Fare
{
    [JsonProperty("segment_id")]
    public string SegmentId { get; set; }

    [JsonProperty("fare_basis_code")]
    public string FareBasisCode { get; set; }

    [JsonProperty("booking_code")]
    public string BookingCode { get; set; }

    [JsonProperty("fare_family")]
    public string FareFamily { get; set; }
}

public class Item
{
    [JsonProperty("agent_id")]
    public string AgentId { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("segment_ids")]
    public List<string> SegmentIds { get; set; }

    [JsonProperty("price")]
    public Price Price { get; set; }

    [JsonProperty("booking_proposition")]
    public string BookingProposition { get; set; }

    [JsonProperty("transfer_protection")]
    public string TransferProtection { get; set; }

    [JsonProperty("max_redirect_age")]
    public int MaxRedirectAge { get; set; }

    [JsonProperty("fares")]
    public List<Fare> Fares { get; set; }

    [JsonProperty("opaque_id")]
    public string OpaqueId { get; set; }

    [JsonProperty("booking_metadata")]
    public BookingMetadata BookingMetadata { get; set; }

    [JsonProperty("ticket_attributes")]
    public List<object> TicketAttributes { get; set; }

    [JsonProperty("flight_attributes")]
    public List<object> FlightAttributes { get; set; }
}

public class Itinerary
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("leg_ids")]
    public List<string> LegIds { get; set; }

    [JsonProperty("pricing_options")]
    public List<PricingOption> PricingOptions { get; set; }

    [JsonProperty("score")]
    public double Score { get; set; }

    [JsonProperty("cheapest_price")]
    public CheapestPrice CheapestPrice { get; set; }

    [JsonProperty("pricing_options_count")]
    public int PricingOptionsCount { get; set; }
}

public class Leg
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("origin_place_id")]
    public int OriginPlaceId { get; set; }

    [JsonProperty("destination_place_id")]
    public int DestinationPlaceId { get; set; }

    [JsonProperty("departure")]
    public DateTime Departure { get; set; }

    [JsonProperty("arrival")]
    public DateTime Arrival { get; set; }

    [JsonProperty("segment_ids")]
    public List<string> SegmentIds { get; set; }

    [JsonProperty("duration")]
    public int Duration { get; set; }

    [JsonProperty("stop_count")]
    public int StopCount { get; set; }

    [JsonProperty("marketing_carrier_ids")]
    public List<int> MarketingCarrierIds { get; set; }

    [JsonProperty("operating_carrier_ids")]
    public List<int> OperatingCarrierIds { get; set; }

    [JsonProperty("stop_ids")]
    public List<List<int>> StopIds { get; set; }
}

public class Price
{
    [JsonProperty("amount")]
    public double Amount { get; set; }

    [JsonProperty("update_status")]
    public string UpdateStatus { get; set; }

    [JsonProperty("last_updated")]
    public DateTime LastUpdated { get; set; }

    [JsonProperty("quote_age")]
    public int QuoteAge { get; set; }
}

public class PricingOption
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("agent_ids")]
    public List<string> AgentIds { get; set; }

    [JsonProperty("price")]
    public Price Price { get; set; }

    [JsonProperty("unpriced_type")]
    public string UnpricedType { get; set; }

    [JsonProperty("items")]
    public List<Item> Items { get; set; }

    [JsonProperty("transfer_type")]
    public string TransferType { get; set; }

    [JsonProperty("score")]
    public double Score { get; set; }

    [JsonProperty("pricing_option_fare")]
    public PricingOptionFare PricingOptionFare { get; set; }
}

public class PricingOptionFare
{
    [JsonProperty("attribute_labels")]
    public List<object> AttributeLabels { get; set; }

    [JsonProperty("brand_names")]
    public List<object> BrandNames { get; set; }
}

public class Segment
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("origin_place_id")]
    public int OriginPlaceId { get; set; }

    [JsonProperty("destination_place_id")]
    public int DestinationPlaceId { get; set; }

    [JsonProperty("arrival")]
    public DateTime Arrival { get; set; }

    [JsonProperty("departure")]
    public DateTime Departure { get; set; }

    [JsonProperty("duration")]
    public int Duration { get; set; }

    [JsonProperty("marketing_flight_number")]
    public string MarketingFlightNumber { get; set; }

    [JsonProperty("marketing_carrier_id")]
    public int MarketingCarrierId { get; set; }

    [JsonProperty("operating_carrier_id")]
    public int OperatingCarrierId { get; set; }

    [JsonProperty("mode")]
    public string Mode { get; set; }
}

