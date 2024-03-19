using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using WebApi.Common.Configurations;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Xml;

namespace WebApi.Common.Extensions;

public static class SwaggerExtension 
{
    public static void AddSwaggerConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var swaggerBasicAuthConfiguration = configuration.GetSection(SwaggerBasicAuthConfiguration.Key).Get<SwaggerBasicAuthConfiguration>();

        if (swaggerBasicAuthConfiguration?.Username == null || swaggerBasicAuthConfiguration.Password == null)
        {
            throw new Exception($"Section '{SwaggerBasicAuthConfiguration.Key}' configuration settings are not found in settings file");
        }

        services.AddSingleton(swaggerBasicAuthConfiguration);

        services.AddApiVersioning(
            options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
            }
        );

        services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        MergeDocumentationFiles();

        services.AddSwaggerGen(options =>
        {
            var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc
                (
                    $"{description.GroupName}", new OpenApiInfo()
                    {
                        Title = "AviaTiket API",
                        Version = description.ApiVersion.ToString()
                    }
                );
            }
            
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "WebApi.xml"));

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please insert JWT with Bearer into field",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                        {
                           Reference = new OpenApiReference
                           {
                             Type = ReferenceType.SecurityScheme,
                             Id = "Bearer"
                           }
                        },
                    new string[] { }
                }
            });
        });

        services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ReportApiVersions = true;
        });

        services.AddSwaggerGenNewtonsoftSupport();
    }

    public static void UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        var provider = app.ApplicationServices.GetService<IApiVersionDescriptionProvider>()!;

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.DocExpansion(DocExpansion.None);
            options.EnableDeepLinking();
            
            options.RoutePrefix = "swagger";

            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint(
                    $"/swagger/{description.GroupName}/swagger.json",
                    "AviaTiket API v" + description.ApiVersion.ToString());
            }
        });
    }

    private static void MergeDocumentationFiles()
    {
        var directory = AppDomain.CurrentDomain.BaseDirectory;

        var files = Directory.GetFiles(directory, "*.xml").ToList();

        var mainFile = files.Where(u => u.Contains("WebApi.xml")).FirstOrDefault();
        if (string.IsNullOrEmpty(mainFile))
            return;
        files.Remove(mainFile);

        if (files.Count == 0)
            return;
        var mainDoc = new XmlDocument();
        mainDoc.Load(mainFile);
        var membersNode = mainDoc.SelectSingleNode("//members");
        files.ForEach(file => {
            var doc = new XmlDocument();
            doc.Load(file);
            var nodes = doc.SelectNodes("//member");
            foreach (XmlNode node in nodes)
            {
                var importNode = mainDoc.ImportNode(node, true);
                membersNode.AppendChild(importNode);
            }
        });
        files.ForEach(u =>
        {
            File.Delete(u);
        });
        mainDoc.Save(mainFile);
    }

}
