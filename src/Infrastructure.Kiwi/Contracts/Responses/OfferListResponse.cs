using Newtonsoft.Json;

namespace Infrastructure.Kiwi.Contracts.Responses;
public class OfferListResponse
{

    [JsonProperty("total_emissions_kg")]
    public string TotalEmissionsKg { get; set; }

    [JsonProperty("total_currency")]
    public string TotalCurrency { get; set; }

    [JsonProperty("total_amount")]
    public string TotalAmount { get; set; }

    [JsonProperty("tax_currency")]
    public string TaxCurrency { get; set; }

    [JsonProperty("tax_amount")]
    public string TaxAmount { get; set; }

    [JsonProperty("supported_passenger_identity_document_types")]
    public List<string> SupportedPassengerIdentityDocumentTypes { get; set; }

    [JsonProperty("slices")]
    public List<Slice> Slices { get; set; }

    [JsonProperty("private_fares")]
    public List<PrivateFare> PrivateFares { get; set; }

    [JsonProperty("payment_requirements")]
    public PaymentRequirements PaymentRequirements { get; set; }

    [JsonProperty("passengers")]
    public List<Passenger> Passengers { get; set; }

    [JsonProperty("passenger_identity_documents_required")]
    public bool PassengerIdentityDocumentsRequired { get; set; }

    [JsonProperty("partial")]
    public bool Partial { get; set; }

    [JsonProperty("owner")]
    public Owner Owner { get; set; }

    [JsonProperty("live_mode")]
    public bool LiveMode { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("expires_at")]
    public DateTime ExpiresAt { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("conditions")]
    public Conditions Conditions { get; set; }

    [JsonProperty("base_currency")]
    public string BaseCurrency { get; set; }

    [JsonProperty("base_amount")]
    public string BaseAmount { get; set; }    
}

public class Slice
{
    [JsonProperty("segments")]
    public List<Segment> Segments { get; set; }

    [JsonProperty("origin_type")]
    public string OriginType { get; set; }

    [JsonProperty("origin")]
    public Origin Origin { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("fare_brand_name")]
    public string FareBrandName { get; set; }

    [JsonProperty("duration")]
    public string Duration { get; set; }

    [JsonProperty("destination_type")]
    public string DestinationType { get; set; }

    [JsonProperty("destination")]
    public Destination Destination { get; set; }

    [JsonProperty("conditions")]
    public Conditions Conditions { get; set; }
}

public class Segment
{
    [JsonProperty("stops")]
    public List<Stop> Stops { get; set; }

    [JsonProperty("passengers")]
    public List<Passenger> Passengers { get; set; }

    [JsonProperty("origin_terminal")]
    public string OriginTerminal { get; set; }

    [JsonProperty("origin")]
    public Origin Origin { get; set; }

    [JsonProperty("operating_carrier_flight_number")]
    public string OperatingCarrierFlightNumber { get; set; }

    [JsonProperty("operating_carrier")]
    public OperatingCarrier OperatingCarrier { get; set; }

    [JsonProperty("marketing_carrier_flight_number")]
    public string MarketingCarrierFlightNumber { get; set; }

    [JsonProperty("marketing_carrier")]
    public MarketingCarrier MarketingCarrier { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("duration")]
    public string Duration { get; set; }

    [JsonProperty("distance")]
    public string Distance { get; set; }

    [JsonProperty("destination_terminal")]
    public string DestinationTerminal { get; set; }

    [JsonProperty("destination")]
    public Destination Destination { get; set; }

    [JsonProperty("departing_at")]
    public DateTime DepartingAt { get; set; }

    [JsonProperty("arriving_at")]
    public DateTime ArrivingAt { get; set; }

    [JsonProperty("aircraft")]
    public Aircraft Aircraft { get; set; }
}
public class Origin
{
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

    [JsonProperty("iata_country_code")]
    public string IataCountryCode { get; set; }

    [JsonProperty("iata_code")]
    public string IataCode { get; set; }

    [JsonProperty("iata_city_code")]
    public string IataCityCode { get; set; }

    [JsonProperty("city_name")]
    public string CityName { get; set; }

    [JsonProperty("city")]
    public City City { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }
}

public class Destination
{
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

    [JsonProperty("iata_country_code")]
    public string IataCountryCode { get; set; }

    [JsonProperty("iata_code")]
    public string IataCode { get; set; }

    [JsonProperty("iata_city_code")]
    public string IataCityCode { get; set; }

    [JsonProperty("city_name")]
    public string CityName { get; set; }

    [JsonProperty("city")]
    public City City { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("airports")]
    public List<Airport> Airports { get; set; }
}
public class Conditions
{
    [JsonProperty("change_before_departure")]
    public ChangeBeforeDeparture ChangeBeforeDeparture { get; set; }

    [JsonProperty("refund_before_departure")]
    public RefundBeforeDeparture RefundBeforeDeparture { get; set; }
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

    [JsonProperty("iata_country_code")]
    public string IataCountryCode { get; set; }

    [JsonProperty("iata_code")]
    public string IataCode { get; set; }

    [JsonProperty("iata_city_code")]
    public string IataCityCode { get; set; }

    [JsonProperty("city_name")]
    public string CityName { get; set; }

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
    public string PenaltyAmount { get; set; }

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

public class LoyaltyProgrammeAccount
{
    [JsonProperty("airline_iata_code")]
    public string AirlineIataCode { get; set; }

    [JsonProperty("account_number")]
    public string AccountNumber { get; set; }
}

public class MarketingCarrier
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("logo_symbol_url")]
    public string LogoSymbolUrl { get; set; }

    [JsonProperty("logo_lockup_url")]
    public string LogoLockupUrl { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("iata_code")]
    public string IataCode { get; set; }

    [JsonProperty("conditions_of_carriage_url")]
    public string ConditionsOfCarriageUrl { get; set; }
}

public class OperatingCarrier
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("logo_symbol_url")]
    public string LogoSymbolUrl { get; set; }

    [JsonProperty("logo_lockup_url")]
    public string LogoLockupUrl { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("iata_code")]
    public string IataCode { get; set; }

    [JsonProperty("conditions_of_carriage_url")]
    public string ConditionsOfCarriageUrl { get; set; }
}


public class Owner
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("logo_symbol_url")]
    public string LogoSymbolUrl { get; set; }

    [JsonProperty("logo_lockup_url")]
    public string LogoLockupUrl { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("iata_code")]
    public string IataCode { get; set; }

    [JsonProperty("conditions_of_carriage_url")]
    public string ConditionsOfCarriageUrl { get; set; }
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

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("loyalty_programme_accounts")]
    public List<LoyaltyProgrammeAccount> LoyaltyProgrammeAccounts { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("given_name")]
    public string GivenName { get; set; }

    [JsonProperty("fare_type")]
    public string FareType { get; set; }

    [JsonProperty("family_name")]
    public string FamilyName { get; set; }

    [JsonProperty("age")]
    public int Age { get; set; }
}

public class PaymentRequirements
{
    [JsonProperty("requires_instant_payment")]
    public bool RequiresInstantPayment { get; set; }

    [JsonProperty("price_guarantee_expires_at")]
    public DateTime PriceGuaranteeExpiresAt { get; set; }

    [JsonProperty("payment_required_by")]
    public DateTime PaymentRequiredBy { get; set; }
}

public class Power
{
    [JsonProperty("available")]
    public string Available { get; set; }
}

public class PrivateFare
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("tracking_reference")]
    public string TrackingReference { get; set; }

    [JsonProperty("tour_code")]
    public string TourCode { get; set; }

    [JsonProperty("corporate_code")]
    public string CorporateCode { get; set; }
}

public class RefundBeforeDeparture
{
    [JsonProperty("penalty_currency")]
    public string PenaltyCurrency { get; set; }

    [JsonProperty("penalty_amount")]
    public string PenaltyAmount { get; set; }

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


public class Stop
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("duration")]
    public string Duration { get; set; }

    [JsonProperty("departing_at")]
    public DateTime DepartingAt { get; set; }

    [JsonProperty("arriving_at")]
    public DateTime ArrivingAt { get; set; }

    [JsonProperty("airport")]
    public Airport Airport { get; set; }
}

public class Wifi
{
    [JsonProperty("cost")]
    public string Cost { get; set; }

    [JsonProperty("available")]
    public string Available { get; set; }
}