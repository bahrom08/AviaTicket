using Application.Common.Exceptions;
using Application.Common.Extensions;
using Application.Common.Interfaces;
using Application.Features.Routes.Queries.GetRoutesSearch;
using Application.Services.GoogleFlightsGateway;
using Application.Services.RouteProviderGateway;
using AutoMapper;
using Domain.Entities.Orders;
using Domain.Enums.DocumentTypes;
using Domain.Enums.GatewayProvider;
using Domain.Enums.Genders;
using Domain.Enums.OrderStatuses;
using Domain.Enums.Passengers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler : BaseSetting, IRequestHandler<CreateOrderCommand>
{
    private readonly IKiwiGatewayService _kiwiGatewayService;
    private readonly IGoogleFlightsGatewayService _googleFlightsService;

    public CreateOrderCommandHandler(IMapper mapper,
                                     IApplicationDbContext context,
                                     IKiwiGatewayService kiwiGatewayService,
                                     IGoogleFlightsGatewayService googleFlightsService) : base(mapper, context)
    {
        _kiwiGatewayService = kiwiGatewayService;
        _googleFlightsService = googleFlightsService;
    }

    public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var offer = await GetOfferRouteById(request.OfferId, request.GatewayProviderId);

        var currency = await _dbContext.Currencies
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsoCode == offer.CurrencyIsoCode, cancellationToken)
            ?? throw new LogicException("Валюта не найдена");

        var order = new Order
        {
            Id = Guid.NewGuid(),
            OfferId = offer.OfferId,
            OrderStatusId = OrderStatusEnum.Created.Value,
            Price = offer.Price,
            CurrencyId = currency.Id
        };

        await _dbContext.Orders.AddAsync(order, cancellationToken);

        var orderRoutes = offer.Routes.Select(route => new OrderRoute
        {
            ArrivalAirportId = _dbContext.Airports.AsNoTracking().FirstOrDefault(x => x.IATACode == route.ArrivalAirport.Code)!.Id,
            DepartureAirportId = _dbContext.Airports.AsNoTracking().FirstOrDefault(x => x.IATACode == route.DepartureAirport.Code)!.Id,
            CanChange = offer.CanChange,
            CanRefund = offer.CanRefund,
            ArrivalAt = route.ArrivalAirport.FlightAt,
            DepartureAt = route.DepartureAirport.FlightAt,
            DurationInSeconds = route.DurationInSeconds,
            Id = Guid.NewGuid(),
            OrderId = order.Id
        });

        await _dbContext.OrderRoutes.AddRangeAsync(orderRoutes, cancellationToken);

        var orderPassengers = request.Passengers.Select(x => new OrderPassenger
        {
            CitizenshipId = x.CitizenshipId,
            DateOfBirth = x.DateOfBirth,
            DocumentNumber = x.DocumentNumber,
            DocumentType = PassengerDocumentTypeEnum.FromValue(x.DocumentType),
            ExpiredAt = x.ExpiredAt,
            FirstName = x.FirstName,
            Id = Guid.NewGuid(),
            IssueAt = x.IssueAt,
            LastName = x.LastName,
            MiddleName = x.MiddleName,
            OrderId = order.Id,
            Gender = GenderEnum.FromValue(x.Gender),
        });

        await _dbContext.OrderPassengers.AddRangeAsync(orderPassengers, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

    private async Task<GetRoutesSearchViewModel> GetOfferRouteById(string offerId, Guid gatewayProviderId)
    {
        if (gatewayProviderId == GatewayProviderEnum.Kiwi.Value)
        {
            return await _kiwiGatewayService.GetOffer(offerId);
        }
        else if (gatewayProviderId == GatewayProviderEnum.GoogleFlights.Value)
        {
            return await _googleFlightsService.GetOffer(offerId);
        }

        throw new LogicException("Источник предложения не найден");
    }
}