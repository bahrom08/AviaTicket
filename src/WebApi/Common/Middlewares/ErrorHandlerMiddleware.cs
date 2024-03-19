using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Net;
using WebApi.Common.Responses;
using Application.Common.Exceptions;

namespace WebApi.Common.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly ILogger _logger;
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger(GetType().Name);
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var env = context.RequestServices.GetRequiredService<IWebHostEnvironment>();

            var response = context.Response;
            response.StatusCode = (int)HttpStatusCode.OK;
            context.Response.ContentType = "application/json";
            ErrorResponse errorResponse;

            switch (error)
            {
                case ValidationException e:
                    errorResponse = new ErrorResponse(ErrorStatusCodeEnum.BAD_REQUEST, e.Message, e.Errors);
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case FluentValidation.ValidationException e:
                    errorResponse = new ErrorResponse(ErrorStatusCodeEnum.BAD_REQUEST, e.Message);
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case NullDataException e:
                    errorResponse = new ErrorResponse(ErrorStatusCodeEnum.RESOURCE_NOT_FOUND, e.Message);
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                //case TokenExpiredException e:
                //    errorResponse = new ErrorResponse(ErrorStatusCodeEnum.TOKEN_EXPIRED, e.Message);
                //    break;
                //case UnauthorizedException e:
                //    errorResponse = new ErrorResponse(ErrorStatusCodeEnum.ERROR_AUTH, e.Message);
                //    break;
                //case RefreshTokenExpiredException e:
                //    errorResponse = new ErrorResponse(ErrorStatusCodeEnum.TOKEN_REFRESH_EXPIRED, e.Message);
                //    break;
                case LogicException e:
                    errorResponse = new ErrorResponse(ErrorStatusCodeEnum.BAD_REQUEST, e.Message);
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    if (env.IsDevelopment())
                    {
                        throw;
                    }
                    errorResponse = new ErrorResponse(ErrorStatusCodeEnum.UNKNOWN_ERROR, "Неизвестная ошибка");
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;

                    _logger.LogError(
                        "Request {method} {url} => Message: {message}, StackTrace: {stackTrace}",
                        context.Request?.Method,
                        context.Request?.Path.Value,
                        error.InnerException != null ? error.InnerException.Message : error.Message,
                        error.StackTrace);

                    break;
            }

            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            await response.WriteAsync(JsonConvert.SerializeObject(errorResponse, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            }));
        }
    }
}
