using System.Net;
using System.Text;
using WebApi.Common.Configurations;

namespace WebApi.Common.Middlewares;

public class SwaggerAuthMiddleware
{
    private readonly RequestDelegate _next;
    private readonly SwaggerBasicAuthConfiguration _swaggerBasicAuthConfiguration;

    public SwaggerAuthMiddleware(RequestDelegate next, SwaggerBasicAuthConfiguration swaggerBasicAuthConfiguration)
    {
        _next = next;
        _swaggerBasicAuthConfiguration = swaggerBasicAuthConfiguration;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/swagger"))
        {
            string authHeader = context.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Basic "))
            {
                var encodedUsernamePassword = authHeader.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1]?.Trim();

                if (!string.IsNullOrWhiteSpace(encodedUsernamePassword))
                {
                    var decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));

                    var username = decodedUsernamePassword.Split(':', 2)[0];
                    var password = decodedUsernamePassword.Split(':', 2)[1];

                    if (IsAuthorized(username, password))
                    {
                        await _next.Invoke(context);
                        return;
                    }
                }
            }

            context.Response.Headers["WWW-Authenticate"] = "Basic";

            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
        else
        {
            await _next.Invoke(context);
        }
    }

    private bool IsAuthorized(string username, string password)
    {
        return username.Equals(_swaggerBasicAuthConfiguration.Username, StringComparison.InvariantCultureIgnoreCase)
               && password.Equals(_swaggerBasicAuthConfiguration.Password);
    }
}
