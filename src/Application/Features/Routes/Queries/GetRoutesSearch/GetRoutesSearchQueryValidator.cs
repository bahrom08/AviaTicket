using Application.Common.Interfaces;
using Domain.Entities.Passengers;
using Domain.Enums.ClassTypes;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Routes.Queries.GetRoutesSearch;

public class GetRoutesSearchQueryValidator : AbstractValidator<GetRoutesSearchQuery>
{
    private readonly IApplicationDbContext _dbContext;

    public GetRoutesSearchQueryValidator(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;

        RuleFor(x => x.ClassTypeCode)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Укажите класс обслуживания")
            .Must(x => ClassTypeEnum.List.Select(x => x.Value).Contains(x))
            .WithMessage("Указано неверный класс облуживания");

        RuleFor(x => x.CurrencyIsoCode)
            .NotEmpty()
            .WithMessage("Укажите валюту")
            .MustAsync(CheckCurrencyExist)
            .WithMessage("Указано неверная валюта");

        RuleFor(x => x.Flight)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Заполните поля для поиска")
            .DependentRules(() =>
            {
                RuleFor(x => x.Flight.From)
                    .NotEmpty()
                    .WithMessage("Укажите город вылета");

                RuleFor(x => x.Flight.To)
                    .NotEmpty()
                    .WithMessage("Укажите город прибытия");

                RuleFor(x => x.Flight.DepartureDate)
                    .NotEmpty()
                    .WithMessage("Укажите дату вылета");
            });

        RuleFor(x => x.ReturnFlight.From)
                    .NotEmpty()
                    .WithMessage("Укажите город вылета")
                    .When(x => x.ReturnFlight != null);

        RuleFor(x => x.ReturnFlight.To)
            .NotEmpty()
            .WithMessage("Укажите город прибытия")
            .When(x => x.ReturnFlight != null);

        RuleFor(x => x.ReturnFlight.DepartureDate)
            .NotEmpty()
            .WithMessage("Укажите дату возвращения")
            .When(x => x.ReturnFlight != null)
            .GreaterThanOrEqualTo(x => x.Flight.DepartureDate)
            .WithMessage("Дата возвращения должно быть больше")
            .When(x => x.ReturnFlight != null && x.Flight != null);

        RuleForEach(x => x.Passengers)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Укажите пассижиров")
            .DependentRules(() =>
            {

                RuleFor(x => x.Passengers)
                    .Must(CheckPassengersType)
                    .WithMessage("Указано одинаковые типы пассажиров")
                    .Must(x => x.Sum(x => x.Count) <= 9)
                    .WithMessage("Макс. 9 пассажиров")
                    .Must(x => x.Where(x => x.Type == PassengerTypeEnum.Infant.Value).Sum(x => x.Count) <= 1)
                    .WithMessage($"Макс. кол-во младенцев 1 пассажир");

            })
            .ChildRules(ch =>
            {
                ch.RuleFor(x => x.Type)
                    .NotEmpty()
                    .WithMessage("Укажите тип пасажиров")
                    .Must(x => PassengerTypeEnum.List.Select(x => x.Value).Contains(x))
                    .WithMessage("Указано неверный тип пассажиров");
            });
    }

    private static bool CheckPassengersType(List<PassengersDto> passengers)
    {
        var passengersDistinctCount = passengers.DistinctBy(x => x.Type).Count();

        if (passengersDistinctCount != passengers.Count)
            return false;

        return true;
    }

    private async Task<bool> CheckCurrencyExist(string currencyIsoCode, CancellationToken cancellationToken)
    {
        return await _dbContext.Currencies
            .AsNoTracking()
            .AnyAsync(x => x.IsoCode == currencyIsoCode, cancellationToken);
    }
}
