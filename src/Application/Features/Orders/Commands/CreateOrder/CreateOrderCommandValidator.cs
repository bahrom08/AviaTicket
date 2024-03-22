using FluentValidation;

namespace Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand> 
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.OfferId)
            .NotEmpty()
            .WithMessage("Укажите идентификатор предложения");

        RuleFor(x => x.GatewayProviderId)
            .NotEmpty()
            .WithMessage("Укажите идентификатор источника предложения");

        RuleFor(x => x.Passengers)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Укажите идентификатор источника предложения")
            .DependentRules(() =>
            {
                RuleForEach(x => x.Passengers)
                .ChildRules(child =>
                {
                    child.RuleFor(x => x.FirstName)
                        .NotEmpty()
                        .WithMessage("Укажите имя пассажира");

                    child.RuleFor(x => x.LastName)
                        .NotEmpty()
                        .WithMessage("Укажите фамилию пассажира");

                    child.RuleFor(x => x.CitizenshipId)
                        .NotEmpty()
                        .WithMessage("Укажите гражданство пассажира");


                    child.RuleFor(x => x.DateOfBirth)
                        .NotEmpty()
                        .WithMessage("Укажите дату рождения пассажира");

                    child.RuleFor(x => x.Gender)
                        .NotEmpty()
                        .WithMessage("Укажите пол пассажира");

                    child.RuleFor(x => x.DocumentType)
                        .NotEmpty()
                        .WithMessage("Укажите тип документа");

                    child.RuleFor(x => x.DocumentNumber)
                        .NotEmpty()
                        .WithMessage("Укажите номер документа");
                });
            });
    }
}