﻿using Infrastructure.GoogleFlights.Contracts.Requests;
using Infrastructure.GoogleFlights.Contracts.Responses;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Infrastructure.GoogleFlights.Common.Configurations;

namespace Infrastructure.GoogleFlights.Services;

public class GoogleFlightsService : IGoogleFlightsService
{
    private readonly HttpClient _httpClient;

    public GoogleFlightsService(HttpClient httpClient, GoogleFilghtsConfiguration googleFilghtsConfiguration)
    {
        _httpClient = httpClient;
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(googleFilghtsConfiguration.Host);
        _httpClient.DefaultRequestHeaders.Add("X-Api-Key", googleFilghtsConfiguration.ApiKey);
    }

    public Task<SearchFlightsResponse> SearchFlights(SearchFlightsRequest request)
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

        //await _httpClient.PostAsync(GoogleEndpointEnum.SearchOffers, stringContent);

        return Task.FromResult(SearchOffers());
    }

    public Task<Itinerary?> GetFlight(string offerId)
    {
        var offer = SearchOffers().Data.Itineraries.Where(x => x.Id == offerId).FirstOrDefault();
        
        return Task.FromResult(offer);
    }

    private SearchFlightsResponse SearchOffers()
    {
        #region jsonData
        var json = "{\"status\":true,\"message\":\"success\",\"data\":{\"token\":\"eyJhIjoiMSIsImMiOjAsImkiOjAsImNjIjoiZWNvbm9teSIsIm8iOiJOWUNBIiwiZCI6IkxBWEEiLCJkMSI6IjIwMjQtMDMtMTEiLCJkMiI6IjIwMjQtMDMtMTgifQ==\",\"context\":{\"status\":\"incomplete\",\"sessionId\":\"ClQIARJQCk4KJGJlNjU3OGMyLWIxNjgtNDg5Yy1hZGU1LTJmN2UzNWNhMGVhNBACGiQ0MWY3YzRmNC0wMWVlLTRiYTMtYmE2ZC1mODllYmEyODBjOWI=\",\"totalResults\":10},\"itineraries\":[{\"id\":\"11442-2403111000--31722-0-13416-2403111310|13416-2403181630--31722-0-11442-2403190040\",\"price\":{\"raw\":912.21,\"formatted\":\"$735\",\"pricingOptionId\":\"hqa31rxH2JuU\"},\"legs\":[{\"id\":\"11442-2403111000--31722-0-13416-2403111310\",\"origin\":{\"id\":\"EWR\",\"name\":\"New York Newark\",\"displayCode\":\"EWR\",\"city\":\"New York\",\"country\":\"United States\",\"isHighlighted\":false},\"destination\":{\"id\":\"LAX\",\"name\":\"Los Angeles International\",\"displayCode\":\"LAX\",\"city\":\"Los Angeles\",\"country\":\"United States\",\"isHighlighted\":false},\"durationInMinutes\":370,\"stopCount\":0,\"isSmallestStops\":false,\"departure\":\"2024-03-11T10:00:00\",\"arrival\":\"2024-03-11T13:10:00\",\"timeDeltaInDays\":0,\"carriers\":{\"marketing\":[{\"id\":-31722,\"logoUrl\":\"https://logos.skyscnr.com/images/airlines/favicon/UA.png\",\"name\":\"United\"}],\"operationType\":\"fully_operated\"},\"segments\":[{\"id\":\"11442-13416-2403111000-2403111310--31722\",\"origin\":{\"flightPlaceId\":\"EWR\",\"displayCode\":\"EWR\",\"parent\":{\"flightPlaceId\":\"NYCA\",\"displayCode\":\"NYC\",\"name\":\"New York\",\"type\":\"City\"},\"name\":\"New York Newark\",\"type\":\"Airport\",\"country\":\"United States\"},\"destination\":{\"flightPlaceId\":\"LAX\",\"displayCode\":\"LAX\",\"parent\":{\"flightPlaceId\":\"LAXA\",\"displayCode\":\"LAX\",\"name\":\"Los Angeles\",\"type\":\"City\"},\"name\":\"Los Angeles International\",\"type\":\"Airport\",\"country\":\"United States\"},\"departure\":\"2024-03-11T10:00:00\",\"arrival\":\"2024-03-11T13:10:00\",\"durationInMinutes\":370,\"flightNumber\":\"2679\",\"marketingCarrier\":{\"id\":-31722,\"name\":\"United\",\"alternateId\":\"UA\",\"allianceId\":0,\"displayCode\":\"\"},\"operatingCarrier\":{\"id\":-31722,\"name\":\"United\",\"alternateId\":\"UA\",\"allianceId\":0,\"displayCode\":\"\"}}]},{\"id\":\"13416-2403181630--31722-0-11442-2403190040\",\"origin\":{\"id\":\"LAX\",\"name\":\"Los Angeles International\",\"displayCode\":\"LAX\",\"city\":\"Los Angeles\",\"country\":\"United States\",\"isHighlighted\":false},\"destination\":{\"id\":\"EWR\",\"name\":\"New York Newark\",\"displayCode\":\"EWR\",\"city\":\"New York\",\"country\":\"United States\",\"isHighlighted\":false},\"durationInMinutes\":310,\"stopCount\":0,\"isSmallestStops\":false,\"departure\":\"2024-03-18T16:30:00\",\"arrival\":\"2024-03-19T00:40:00\",\"timeDeltaInDays\":1,\"carriers\":{\"marketing\":[{\"id\":-31722,\"logoUrl\":\"https://logos.skyscnr.com/images/airlines/favicon/UA.png\",\"name\":\"United\"}],\"operationType\":\"fully_operated\"},\"segments\":[{\"id\":\"13416-11442-2403181630-2403190040--31722\",\"origin\":{\"flightPlaceId\":\"LAX\",\"displayCode\":\"LAX\",\"parent\":{\"flightPlaceId\":\"LAXA\",\"displayCode\":\"LAX\",\"name\":\"Los Angeles\",\"type\":\"City\"},\"name\":\"Los Angeles International\",\"type\":\"Airport\",\"country\":\"United States\"},\"destination\":{\"flightPlaceId\":\"EWR\",\"displayCode\":\"EWR\",\"parent\":{\"flightPlaceId\":\"NYCA\",\"displayCode\":\"NYC\",\"name\":\"New York\",\"type\":\"City\"},\"name\":\"New York Newark\",\"type\":\"Airport\",\"country\":\"United States\"},\"departure\":\"2024-03-18T16:30:00\",\"arrival\":\"2024-03-19T00:40:00\",\"durationInMinutes\":310,\"flightNumber\":\"1700\",\"marketingCarrier\":{\"id\":-31722,\"name\":\"United\",\"alternateId\":\"UA\",\"allianceId\":0,\"displayCode\":\"\"},\"operatingCarrier\":{\"id\":-31722,\"name\":\"United\",\"alternateId\":\"UA\",\"allianceId\":0,\"displayCode\":\"\"}}]}],\"isSelfTransfer\":false,\"isProtectedSelfTransfer\":false,\"farePolicy\":{\"isChangeAllowed\":false,\"isPartiallyChangeable\":false,\"isCancellationAllowed\":false,\"isPartiallyRefundable\":false},\"fareAttributes\":{},\"isMashUp\":false,\"hasFlexibleOptions\":false,\"score\":0.999},{\"id\":\"11442-2403110825--31722-0-13416-2403111135|13416-2403181630--31722-0-11442-2403190040\",\"price\":{\"raw\":870.21,\"formatted\":\"$735\",\"pricingOptionId\":\"nqV8P4L0GOB5\"},\"legs\":[{\"id\":\"11442-2403110825--31722-0-13416-2403111135\",\"origin\":{\"id\":\"EWR\",\"name\":\"New York Newark\",\"displayCode\":\"EWR\",\"city\":\"New York\",\"country\":\"United States\",\"isHighlighted\":false},\"destination\":{\"id\":\"LAX\",\"name\":\"Los Angeles International\",\"displayCode\":\"LAX\",\"city\":\"Los Angeles\",\"country\":\"United States\",\"isHighlighted\":false},\"durationInMinutes\":370,\"stopCount\":0,\"isSmallestStops\":false,\"departure\":\"2024-03-11T08:25:00\",\"arrival\":\"2024-03-11T11:35:00\",\"timeDeltaInDays\":0,\"carriers\":{\"marketing\":[{\"id\":-31722,\"logoUrl\":\"https://logos.skyscnr.com/images/airlines/favicon/UA.png\",\"name\":\"United\"}],\"operationType\":\"fully_operated\"},\"segments\":[{\"id\":\"11442-13416-2403110825-2403111135--31722\",\"origin\":{\"flightPlaceId\":\"EWR\",\"displayCode\":\"EWR\",\"parent\":{\"flightPlaceId\":\"NYCA\",\"displayCode\":\"NYC\",\"name\":\"New York\",\"type\":\"City\"},\"name\":\"New York Newark\",\"type\":\"Airport\",\"country\":\"United States\"},\"destination\":{\"flightPlaceId\":\"LAX\",\"displayCode\":\"LAX\",\"parent\":{\"flightPlaceId\":\"LAXA\",\"displayCode\":\"LAX\",\"name\":\"Los Angeles\",\"type\":\"City\"},\"name\":\"Los Angeles International\",\"type\":\"Airport\",\"country\":\"United States\"},\"departure\":\"2024-03-11T08:25:00\",\"arrival\":\"2024-03-11T11:35:00\",\"durationInMinutes\":370,\"flightNumber\":\"399\",\"marketingCarrier\":{\"id\":-31722,\"name\":\"United\",\"alternateId\":\"UA\",\"allianceId\":0,\"displayCode\":\"\"},\"operatingCarrier\":{\"id\":-31722,\"name\":\"United\",\"alternateId\":\"UA\",\"allianceId\":0,\"displayCode\":\"\"}}]},{\"id\":\"13416-2403181630--31722-0-11442-2403190040\",\"origin\":{\"id\":\"LAX\",\"name\":\"Los Angeles International\",\"displayCode\":\"LAX\",\"city\":\"Los Angeles\",\"country\":\"United States\",\"isHighlighted\":false},\"destination\":{\"id\":\"EWR\",\"name\":\"New York Newark\",\"displayCode\":\"EWR\",\"city\":\"New York\",\"country\":\"United States\",\"isHighlighted\":false},\"durationInMinutes\":310,\"stopCount\":0,\"isSmallestStops\":false,\"departure\":\"2024-03-18T16:30:00\",\"arrival\":\"2024-03-19T00:40:00\",\"timeDeltaInDays\":1,\"carriers\":{\"marketing\":[{\"id\":-31722,\"logoUrl\":\"https://logos.skyscnr.com/images/airlines/favicon/UA.png\",\"name\":\"United\"}],\"operationType\":\"fully_operated\"},\"segments\":[{\"id\":\"13416-11442-2403181630-2403190040--31722\",\"origin\":{\"flightPlaceId\":\"LAX\",\"displayCode\":\"LAX\",\"parent\":{\"flightPlaceId\":\"LAXA\",\"displayCode\":\"LAX\",\"name\":\"Los Angeles\",\"type\":\"City\"},\"name\":\"Los Angeles International\",\"type\":\"Airport\",\"country\":\"United States\"},\"destination\":{\"flightPlaceId\":\"EWR\",\"displayCode\":\"EWR\",\"parent\":{\"flightPlaceId\":\"NYCA\",\"displayCode\":\"NYC\",\"name\":\"New York\",\"type\":\"City\"},\"name\":\"New York Newark\",\"type\":\"Airport\",\"country\":\"United States\"},\"departure\":\"2024-03-18T16:30:00\",\"arrival\":\"2024-03-19T00:40:00\",\"durationInMinutes\":310,\"flightNumber\":\"1700\",\"marketingCarrier\":{\"id\":-31722,\"name\":\"United\",\"alternateId\":\"UA\",\"allianceId\":0,\"displayCode\":\"\"},\"operatingCarrier\":{\"id\":-31722,\"name\":\"United\",\"alternateId\":\"UA\",\"allianceId\":0,\"displayCode\":\"\"}}]}],\"isSelfTransfer\":false,\"isProtectedSelfTransfer\":false,\"farePolicy\":{\"isChangeAllowed\":false,\"isPartiallyChangeable\":false,\"isCancellationAllowed\":false,\"isPartiallyRefundable\":false},\"eco\":{\"ecoContenderDelta\":7.703352},\"fareAttributes\":{},\"isMashUp\":false,\"hasFlexibleOptions\":false,\"score\":0.991546},{\"id\":\"11442-2403110700--31722-0-13416-2403111009|13416-2403181630--31722-0-11442-2403190040\",\"price\":{\"raw\":734.21,\"formatted\":\"$735\",\"pricingOptionId\":\"s96Z4odS8rXG\"},\"legs\":[{\"id\":\"11442-2403110700--31722-0-13416-2403111009\",\"origin\":{\"id\":\"EWR\",\"name\":\"New York Newark\",\"displayCode\":\"EWR\",\"city\":\"New York\",\"country\":\"United States\",\"isHighlighted\":false},\"destination\":{\"id\":\"LAX\",\"name\":\"Los Angeles International\",\"displayCode\":\"LAX\",\"city\":\"Los Angeles\",\"country\":\"United States\",\"isHighlighted\":false},\"durationInMinutes\":369,\"stopCount\":0,\"isSmallestStops\":false,\"departure\":\"2024-03-11T07:00:00\",\"arrival\":\"2024-03-11T10:09:00\",\"timeDeltaInDays\":0,\"carriers\":{\"marketing\":[{\"id\":-31722,\"logoUrl\":\"https://logos.skyscnr.com/images/airlines/favicon/UA.png\",\"name\":\"United\"}],\"operationType\":\"fully_operated\"},\"segments\":[{\"id\":\"11442-13416-2403110700-2403111009--31722\",\"origin\":{\"flightPlaceId\":\"EWR\",\"displayCode\":\"EWR\",\"parent\":{\"flightPlaceId\":\"NYCA\",\"displayCode\":\"NYC\",\"name\":\"New York\",\"type\":\"City\"},\"name\":\"New York Newark\",\"type\":\"Airport\",\"country\":\"United States\"},\"destination\":{\"flightPlaceId\":\"LAX\",\"displayCode\":\"LAX\",\"parent\":{\"flightPlaceId\":\"LAXA\",\"displayCode\":\"LAX\",\"name\":\"Los Angeles\",\"type\":\"City\"},\"name\":\"Los Angeles International\",\"type\":\"Airport\",\"country\":\"United States\"},\"departure\":\"2024-03-11T07:00:00\",\"arrival\":\"2024-03-11T10:09:00\",\"durationInMinutes\":369,\"flightNumber\":\"2434\",\"marketingCarrier\":{\"id\":-31722,\"name\":\"United\",\"alternateId\":\"UA\",\"allianceId\":0,\"displayCode\":\"\"},\"operatingCarrier\":{\"id\":-31722,\"name\":\"United\",\"alternateId\":\"UA\",\"allianceId\":0,\"displayCode\":\"\"}}]},{\"id\":\"13416-2403181630--31722-0-11442-2403190040\",\"origin\":{\"id\":\"LAX\",\"name\":\"Los Angeles International\",\"displayCode\":\"LAX\",\"city\":\"Los Angeles\",\"country\":\"United States\",\"isHighlighted\":false},\"destination\":{\"id\":\"EWR\",\"name\":\"New York Newark\",\"displayCode\":\"EWR\",\"city\":\"New York\",\"country\":\"United States\",\"isHighlighted\":false},\"durationInMinutes\":310,\"stopCount\":0,\"isSmallestStops\":false,\"departure\":\"2024-03-18T16:30:00\",\"arrival\":\"2024-03-19T00:40:00\",\"timeDeltaInDays\":1,\"carriers\":{\"marketing\":[{\"id\":-31722,\"logoUrl\":\"https://logos.skyscnr.com/images/airlines/favicon/UA.png\",\"name\":\"United\"}],\"operationType\":\"fully_operated\"},\"segments\":[{\"id\":\"13416-11442-2403181630-2403190040--31722\",\"origin\":{\"flightPlaceId\":\"LAX\",\"displayCode\":\"LAX\",\"parent\":{\"flightPlaceId\":\"LAXA\",\"displayCode\":\"LAX\",\"name\":\"Los Angeles\",\"type\":\"City\"},\"name\":\"Los Angeles International\",\"type\":\"Airport\",\"country\":\"United States\"},\"destination\":{\"flightPlaceId\":\"EWR\",\"displayCode\":\"EWR\",\"parent\":{\"flightPlaceId\":\"NYCA\",\"displayCode\":\"NYC\",\"name\":\"New York\",\"type\":\"City\"},\"name\":\"New York Newark\",\"type\":\"Airport\",\"country\":\"United States\"},\"departure\":\"2024-03-18T16:30:00\",\"arrival\":\"2024-03-19T00:40:00\",\"durationInMinutes\":310,\"flightNumber\":\"1700\",\"marketingCarrier\":{\"id\":-31722,\"name\":\"United\",\"alternateId\":\"UA\",\"allianceId\":0,\"displayCode\":\"\"},\"operatingCarrier\":{\"id\":-31722,\"name\":\"United\",\"alternateId\":\"UA\",\"allianceId\":0,\"displayCode\":\"\"}}]}],\"isSelfTransfer\":false,\"isProtectedSelfTransfer\":false,\"farePolicy\":{\"isChangeAllowed\":false,\"isPartiallyChangeable\":false,\"isCancellationAllowed\":false,\"isPartiallyRefundable\":false},\"eco\":{\"ecoContenderDelta\":7.703352},\"fareAttributes\":{},\"isMashUp\":false,\"hasFlexibleOptions\":false,\"score\":0.982116},{\"id\":\"11442-2403111000--31722-0-13416-2403111310|13416-2403182135--31722-0-11442-2403190535\",\"price\":{\"raw\":1000.21,\"formatted\":\"$735\",\"pricingOptionId\":\"-DmpvBynZb0v\"},\"legs\":[{\"id\":\"11442-2403111000--31722-0-13416-2403111310\",\"origin\":{\"id\":\"EWR\",\"name\":\"New York Newark\",\"displayCode\":\"EWR\",\"city\":\"New York\",\"country\":\"United States\",\"isHighlighted\":false},\"destination\":{\"id\":\"LAX\",\"name\":\"Los Angeles International\",\"displayCode\":\"LAX\",\"city\":\"Los Angeles\",\"country\":\"United States\",\"isHighlighted\":false},\"durationInMinutes\":370,\"stopCount\":0,\"isSmallestStops\":false,\"departure\":\"2024-03-11T10:00:00\",\"arrival\":\"2024-03-11T13:10:00\",\"timeDeltaInDays\":0,\"carriers\":{\"marketing\":[{\"id\":-31722,\"logoUrl\":\"https://logos.skyscnr.com/images/airlines/favicon/UA.png\",\"name\":\"United\"}],\"operationType\":\"fully_operated\"},\"segments\":[{\"id\":\"11442-13416-2403111000-2403111310--31722\",\"origin\":{\"flightPlaceId\":\"EWR\",\"displayCode\":\"EWR\",\"parent\":{\"flightPlaceId\":\"NYCA\",\"displayCode\":\"NYC\",\"name\":\"New York\",\"type\":\"City\"},\"name\":\"New York Newark\",\"type\":\"Airport\",\"country\":\"United States\"},\"destination\":{\"flightPlaceId\":\"LAX\",\"displayCode\":\"LAX\",\"parent\":{\"flightPlaceId\":\"LAXA\",\"displayCode\":\"LAX\",\"name\":\"Los Angeles\",\"type\":\"City\"},\"name\":\"Los Angeles International\",\"type\":\"Airport\",\"country\":\"United States\"},\"departure\":\"2024-03-11T10:00:00\",\"arrival\":\"2024-03-11T13:10:00\",\"durationInMinutes\":370,\"flightNumber\":\"2679\",\"marketingCarrier\":{\"id\":-31722,\"name\":\"United\",\"alternateId\":\"UA\",\"allianceId\":0,\"displayCode\":\"\"},\"operatingCarrier\":{\"id\":-31722,\"name\":\"United\",\"alternateId\":\"UA\",\"allianceId\":0,\"displayCode\":\"\"}}]},{\"id\":\"13416-2403182135--31722-0-11442-2403190535\",\"origin\":{\"id\":\"LAX\",\"name\":\"Los Angeles International\",\"displayCode\":\"LAX\",\"city\":\"Los Angeles\",\"country\":\"United States\",\"isHighlighted\":false},\"destination\":{\"id\":\"EWR\",\"name\":\"New York Newark\",\"displayCode\":\"EWR\",\"city\":\"New York\",\"country\":\"United States\",\"isHighlighted\":false},\"durationInMinutes\":300,\"stopCount\":0,\"isSmallestStops\":false,\"departure\":\"2024-03-18T21:35:00\",\"arrival\":\"2024-03-19T05:35:00\",\"timeDeltaInDays\":1,\"carriers\":{\"marketing\":[{\"id\":-31722,\"logoUrl\":\"https://logos.skyscnr.com/images/airlines/favicon/UA.png\",\"name\":\"United\"}],\"operationType\":\"fully_operated\"},\"segments\":[{\"id\":\"13416-11442-2403182135-2403190535--31722\",\"origin\":{\"flightPlaceId\":\"LAX\",\"displayCode\":\"LAX\",\"parent\":{\"flightPlaceId\":\"LAXA\",\"displayCode\":\"LAX\",\"name\":\"Los Angeles\",\"type\":\"City\"},\"name\":\"Los Angeles International\",\"type\":\"Airport\",\"country\":\"United States\"},\"destination\":{\"flightPlaceId\":\"EWR\",\"displayCode\":\"EWR\",\"parent\":{\"flightPlaceId\":\"NYCA\",\"displayCode\":\"NYC\",\"name\":\"New York\",\"type\":\"City\"},\"name\":\"New York Newark\",\"type\":\"Airport\",\"country\":\"United States\"},\"departure\":\"2024-03-18T21:35:00\",\"arrival\":\"2024-03-19T05:35:00\",\"durationInMinutes\":300,\"flightNumber\":\"1082\",\"marketingCarrier\":{\"id\":-31722,\"name\":\"United\",\"alternateId\":\"UA\",\"allianceId\":0,\"displayCode\":\"\"},\"operatingCarrier\":{\"id\":-31722,\"name\":\"United\",\"alternateId\":\"UA\",\"allianceId\":0,\"displayCode\":\"\"}}]}],\"isSelfTransfer\":false,\"isProtectedSelfTransfer\":false,\"farePolicy\":{\"isChangeAllowed\":false,\"isPartiallyChangeable\":false,\"isCancellationAllowed\":false,\"isPartiallyRefundable\":false},\"eco\":{\"ecoContenderDelta\":18.136036},\"fareAttributes\":{},\"tags\":[\"second_cheapest\",\"second_shortest\"],\"isMashUp\":false,\"hasFlexibleOptions\":false,\"score\":0.938925}]}}";
        #endregion

        return JsonConvert.DeserializeObject<SearchFlightsResponse>(json) ?? new SearchFlightsResponse();
    }
}
