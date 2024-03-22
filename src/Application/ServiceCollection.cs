using Application.Common.Behaviours;
using Application.Services.GoogleFlightsGateway;
using Application.Services.RouteProviderGateway;
using FluentValidation;
using Infrastructure.GoogleFlights;
using Infrastructure.Kiwi;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class ServiceCollection
{
    public static void AddAdminApplicationLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddKiwiProvider(configuration);
        services.AddGoogleFlightsProvider(configuration);

        services.AddTransient<IKiwiGatewayService, KiwiGatewayService>();
        services.AddTransient<IGoogleFlightsGatewayService, GoogleFlightsGatewayService>();
    }
}
