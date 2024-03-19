using Serilog;
using Application;
using System.Globalization;
using WebApi.Common.Extensions;
using Infrastructure.DataAccess;
using WebApi.Common.Middlewares;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(loggingBuilder =>
                loggingBuilder.AddSerilog());

builder.Services.AddInfrastructureDataAccessLayer(builder.Configuration);
builder.Services.AddAdminApplicationLayer(builder.Configuration);

builder.Services.AddControllerExtension();
builder.Services.AddSwaggerConfiguration(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMiddleware<SwaggerAuthMiddleware>();
    app.UseSwaggerConfiguration();
}

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(new CultureInfo("ru-RU")
    {
        NumberFormat = { CurrencyDecimalSeparator = ".", NumberDecimalSeparator = "." }
    }),
    SupportedCultures = new List<CultureInfo>() { new CultureInfo("ru") { NumberFormat = { CurrencyDecimalSeparator = ".", NumberDecimalSeparator = "." } } },
    SupportedUICultures = new List<CultureInfo>() { new CultureInfo("ru") { NumberFormat = { CurrencyDecimalSeparator = ".", NumberDecimalSeparator = "." } } }
});

app.UseHttpsRedirection();

app.UseRouting();
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseAuthorization();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();

app.MapControllers();

app.Run();