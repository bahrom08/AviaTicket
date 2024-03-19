

namespace WebApi.Common.Responses;

public class BaseResponse<TData>
{
    protected BaseResponse(bool status, ErrorStatusCodeEnum? errorStatusCode = default, TData? data = default,
        Meta? meta = default, string? message = default, IDictionary<string, string[]>? errors = default)
    {
        Status = status;
        Data = data;
        Errors = errors;
        Message = message;
        ErrorCode = (short?)errorStatusCode;
        Meta = meta;
    }

    /// <summary>
    /// Статус успешного выполнения запроса true/false
    /// </summary>
    public bool Status { get; }

    /// <summary>
    /// Код ошибки в случае status = false
    /// </summary>
    public short? ErrorCode { get; }

    /// <summary>
    /// Сообщение об результате запроса
    /// </summary>
    public string? Message { get; }

    /// <summary>
    /// Список ошибок
    /// </summary>
    public IDictionary<string, string[]>? Errors { get; }

    /// <summary>
    /// Результаты ответа запроса
    /// </summary>
    public TData? Data { get; }

    /// <summary>
    /// Данные для дополнительных (пагинация, токены и т.д.)
    /// </summary>
    public Meta? Meta { get; }
}
