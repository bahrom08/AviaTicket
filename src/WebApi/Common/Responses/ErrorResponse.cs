namespace WebApi.Common.Responses;

public class ErrorResponse : BaseResponse<string>
{
    public ErrorResponse(ErrorStatusCodeEnum errorStatusCode, string? message = default,
       IDictionary<string, string[]>? errors = default) : base(false, errorStatusCode, default, default, message, errors)
    {
    }
}
