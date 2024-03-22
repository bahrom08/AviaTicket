using System.Text;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Newtonsoft.Json.Serialization;
using Infrastructure.Kiwi.Contracts.Requests;
using Infrastructure.Kiwi.Contracts.Responses;
using Infrastructure.Kiwi.Common.Configurations;

namespace Infrastructure.Kiwi.Services;

public class KiwiService : IKiwiService
{
    private readonly HttpClient _httpClient;
    private readonly KiwiProviderConfiguration _providerConfiguration;

    public KiwiService(HttpClient httpClient,
                       KiwiProviderConfiguration providerConfiguration)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(providerConfiguration.Host);
        _httpClient.DefaultRequestHeaders.Add("X-Api-Key", providerConfiguration.ApiKey);
        _providerConfiguration = providerConfiguration;
    }

    public Task<GetOfferListResponse> GetOfferList(GetOfferListRequest request)
    {
        var requestBody = JsonConvert.SerializeObject(request, new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        });

        _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("ContentType", "application/json");
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var stringContent = new StringContent(requestBody, Encoding.UTF8, "application/json");

        //await _httpClient.PostAsync(KiwiEndpointEnum.GetOfferList, stringContent);

        return Task.FromResult(GetOffers());
    }

    public Task<GetOfferResponse?> GetOffer(string offerId)
    {
        return Task.FromResult(GetOffers().Data.Offers.Where(x => x.Id == offerId).Select(x => new GetOfferResponse
        {
            Offer = x
        }).FirstOrDefault());
    }

    private GetOfferListResponse GetOffers()
    {
        return new GetOfferListResponse
        {
            Data = new Contracts.Responses.Data
            {
                Offers = new List<Offer>
                {
                    new Offer
                    {
                        CabinClass = "ECONOMY",
                        Amount = 1500,
                        Conditions = new Conditions
                        {
                            ChangeBeforeDeparture = new ChangeBeforeDeparture
                            {
                                Allowed = true,
                                PenaltyAmount = 250,
                                PenaltyCurrency = "TJS"
                            },
                            RefundBeforeDeparture = new RefundBeforeDeparture
                            {
                                Allowed = true,
                                PenaltyAmount = 300,
                                PenaltyCurrency = "TJS"
                            }
                        },
                        CreatedAt = DateTime.Now,
                        Currency = "TJS",
                        ExpiresAt = DateTime.Now.AddMinutes(15),
                        Id = Guid.Parse("ca701289-832f-4711-8199-61b537981f10").ToString(),
                        Slices = new List<Contracts.Responses.Slice>
                        {
                            new Contracts.Responses.Slice
                            {
                                Id = Guid.NewGuid().ToString(),
                                OriginType = "airport",
                                Origin = new Airport
                                {
                                    City = new City
                                    {
                                        IataCode = "LBD",
                                        IataCountryCode = "TJ",
                                        Id = Guid.NewGuid().ToString(),
                                        Name = "Худжанд"
                                    },
                                    Type = "airport",
                                    IataCode = "LBD",
                                    IcaoCode = "UTDL",
                                    Id = Guid.NewGuid().ToString(),
                                    Name = "Международный Аэропорт Худжанд",
                                    TimeZone = "UTC+5"
                                },
                                Destination = new Airport
                                {
                                    City = new City
                                    {
                                        IataCode = "DXB",
                                        IataCountryCode = "AE",
                                        Id = Guid.NewGuid().ToString(),
                                        Name = "Дубай"
                                    },
                                    IataCode = "DXB",
                                    Name = "Международный аэропорт Дубай",
                                    IcaoCode = "OMDB",
                                    Id = Guid.NewGuid().ToString(),
                                    TimeZone = "UTC+4",
                                    Type = "airport"
                                },
                                DestinationType = "airport",
                                Duration = "PT02H26M",
                                ArrivingAt = new DateTime(2024, 01, 01, 00, 00, 00, DateTimeKind.Utc),
                                DepartingAt = new DateTime(2024, 01, 01, 00, 45, 00, DateTimeKind.Utc),
                                Segments = new List<Segment>
                                {
                                    new Segment
                                    {
                                        Aircraft = new Aircraft
                                        {
                                            Name = "Airbus A318",
                                            IataCode = "318"
                                        },
                                        Airline = new Airline
                                        {
                                            Id = Guid.NewGuid().ToString(),
                                            Name = "Somon Air",
                                            IataCode = "SZ"
                                        },
                                        ArrivingAt = new DateTime(2024, 01, 01, 00, 00, 00, DateTimeKind.Utc),
                                        DepartingAt = new DateTime(2024, 01, 01, 00, 45, 00, DateTimeKind.Utc),
                                        Origin = new Airport
                                        {
                                            City = new City
                                            {
                                                IataCode = "LBD",
                                                IataCountryCode = "TJ",
                                                Id = Guid.NewGuid().ToString(),
                                                Name = "Худжанд"
                                            },
                                            IataCode = "LBD",
                                            IcaoCode = "UTDL",
                                            Id = Guid.NewGuid().ToString(),
                                            Name = "Международный Аэропорт Худжанд",
                                            TimeZone = "UTC+5",
                                            Type = "airport"
                                        },
                                        OriginTerminal = "A",
                                        Distance = 203,
                                        Duration = "PT00H45M",
                                        Destination = new Airport
                                        {
                                            City = new City
                                            {
                                                Id = Guid.NewGuid().ToString(),
                                                IataCode = "DYU",
                                                IataCountryCode = "TJ",
                                                Name = "Душанбе"
                                            },
                                            IataCode = "DYU",
                                            IcaoCode = "UTDD",
                                            Id = Guid.NewGuid().ToString(),
                                            Name = "Международный Аэропорт Душанбе",
                                            TimeZone = "UTC+5",
                                            Type = "airport"
                                        },
                                        DestinationTerminal = "B",
                                        Id = Guid.NewGuid().ToString(),
                                        Passengers = new List<Contracts.Responses.Passenger>
                                        {
                                            new Contracts.Responses.Passenger
                                            {
                                                CabinClass = "ECONOMY",
                                                Cabin = new Cabin
                                                {
                                                    MarketingName = "Эконом класс",
                                                    Name = "ECONOMY"
                                                },
                                                Baggages = new List<Baggage>
                                                {
                                                    new Baggage
                                                    {
                                                        Quantity = 1,
                                                        Type = "CHECKED"
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        };
    }
}