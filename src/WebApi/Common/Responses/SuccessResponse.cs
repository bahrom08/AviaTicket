namespace WebApi.Common.Responses;

public class SuccessResponse<TData> : BaseResponse<TData>
{
    public SuccessResponse(TData? data = default, string? message = default, Meta? meta = default)
        : base(true, default, data, meta, message)
    {
    }
}
