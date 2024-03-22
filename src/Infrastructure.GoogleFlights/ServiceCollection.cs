using Microsoft.Extensions.Configuration;
using Infrastructure.GoogleFlights.Services;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.GoogleFlights.Common.Configurations;

namespace Infrastructure.GoogleFlights;

public static class ServiceCollection
{
    public static void AddGoogleFlightsProvider(this IServiceCollection services, IConfiguration configuration)
    {
        var conf = new GoogleFilghtsConfiguration();

        services.AddSingleton(conf);

        services.AddHttpClient<IGoogleFlightsService, GoogleFlightsService>();
    }
}