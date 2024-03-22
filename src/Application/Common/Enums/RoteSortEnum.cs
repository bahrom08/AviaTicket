namespace Application.Common.Enums;

/// <summary>
/// Список возможных параметров для фильтрации, доступные значения "DepartureDate" - 0, "Price" - 1, "StopsCount" - 2, "Airline" - 3
/// </summary>
public enum RoteSortEnum
{
    /// <summary>
    /// По дате
    /// </summary>
    DepartureDate,
    
    /// <summary>
    /// По цене
    /// </summary>
    Price,
    

    /// <summary>
    /// По количеству пересадок
    /// </summary>
    StopsCount,
    
    /// <summary>
    /// По авиакомпании
    /// </summary>
    Airline
}