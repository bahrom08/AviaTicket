using Application.Common.Enums;
using MediatR;
using Newtonsoft.Json;
using System.Buffers.Text;
using System.Reflection;

namespace Application.Features.Routes.Queries.GetRoutesSearch;

public class GetRoutesSearchQuery : IRequest<List<GetRoutesSearchViewModel>>
{
    /// <summary>
    /// Класс обслуживания
    /// </summary>
    public string ClassTypeCode { get; set; }

    /// <summary>
    /// Валюта
    /// </summary>
    public string CurrencyIsoCode { get; set; }

    /// <summary>
    /// Маршрут
    /// </summary>
    public FlightDto Flight { get; set; }

    /// <summary>
    /// Обратный маршрут
    /// </summary>
    public FlightDto? ReturnFlight { get; set; }

    /// <summary>
    /// Пассажиры
    /// </summary>
    public List<PassengersDto> Passengers { get; set; }

    /// <summary>
    /// Параметры фильтрации
    /// </summary>
    public FilterDto? Filters { get; set; }

    /// <summary>
    /// Параметры сортировки
    /// </summary>
    public SortDto Sort { get; set; }

    public string Base64()
    {
        var json = JsonConvert.SerializeObject(this, Formatting.None);
        byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(json);
        return Convert.ToBase64String(jsonBytes);
    }
}

public class FlightDto
{
    /// <summary>
    /// Город отбытия
    /// </summary>
    public string From { get; set; }

    /// <summary>
    /// Город прибытия
    /// </summary>
    public string To { get; set; }

    /// <summary>
    /// Дата отбытия
    /// </summary>
    public DateTime DepartureDate { get; set; }
}

/// <summary>
/// Объект пассажиров маршрута
/// </summary>
public class PassengersDto
{
    /// <summary>
    /// Количество пассажиров
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Тип пассжира, доступные значения ADULT, CHILD, INFANT
    /// </summary>
    public string Type { get; set; }
}

public class SortDto
{
    /// <summary>
    /// Свойство для сортировки, доступные значения "DepartureDate" - 0, "Price" - 1, "StopsCount" - 2, "Airline" - 3
    /// </summary>
    public RoteSortEnum Property { get; set; }

    /// <summary>
    /// Если значение true cортировка будет по убиванию
    /// </summary>
    public bool Desc { get; set; }
}

public class FilterDto
{
    /// <summary>
    /// Цена от
    /// </summary>
    public decimal? FromPrice { get; set; }

    /// <summary>
    /// Цена до
    /// </summary>
    public decimal? ToPrice { get; set; }

    /// <summary>
    /// Количество пересадок
    /// </summary>
    public int? StopsCount { get; set; }

    /// <summary>
    /// Код авиакомпании
    /// </summary>
    public string? AirlineCode { get; set; }

    /// <summary>
    /// Название авиакомпании
    /// </summary>
    public string? AirlineName { get; set; }
}