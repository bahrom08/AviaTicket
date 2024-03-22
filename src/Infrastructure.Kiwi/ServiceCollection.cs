using Infrastructure.Kiwi.Common.Configurations;
using Infrastructure.Kiwi.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Kiwi;

public static class ServiceCollection
{
    public static  void AddKiwiProvider(this IServiceCollection services, IConfiguration configuration)
    {
        var conf = new KiwiProviderConfiguration();

        services.AddSingleton(conf);

        services.AddHttpClient<IKiwiService, KiwiService>();
    }
}