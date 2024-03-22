using MediatR;

namespace Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderCommand : IRequest
{
    /// <summary>
    /// Id предложения
    /// </summary>
    public string OfferId { get; set; }

    /// <summary>
    /// Источник предложения
    /// </summary>
    public Guid GatewayProviderId { get; set; }

    /// <summary>
    /// Пассажиры
    /// </summary>
    public List<PassengerDto> Passengers { get; set; }
}

public class PassengerDto
{
    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Отчество
    /// </summary>
    public string? MiddleName { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateOnly DateOfBirth { get; set; }
    
    /// <summary>
    /// Пол
    /// </summary>
    public string Gender { get; set; }
    
    /// <summary>
    /// Id гражданства
    /// </summary>
    public Guid CitizenshipId { get; set;}
    
    /// <summary>
    /// Тип документа
    /// </summary>
    public string DocumentType { get; set; }
    
    /// <summary>
    /// Серийный номер документа
    /// </summary>
    public string DocumentNumber { get; set; }
    
    /// <summary>
    /// Дата выдачи документа
    /// </summary>
    public DateOnly? IssueAt { get; set; }
    
    /// <summary>
    /// Срок истечение документа
    /// </summary>
    public DateOnly? ExpiredAt { get; set; }
}