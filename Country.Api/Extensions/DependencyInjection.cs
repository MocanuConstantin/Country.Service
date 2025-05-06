using Microsoft.OpenApi.Models;

namespace Country.Api.Extensions;


/// <summary>
/// Provides extension methods for registering API-layer services.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds API-related services like controllers and Swagger generation.
    /// </summary>
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Country API",
                Version = "v1",
                Description = "API for managing countries"
            });
        });

        return services;
    }

    /// <summary>
    /// Configures Swagger middleware in the request pipeline.
    /// </summary>
    public static IApplicationBuilder UseApiSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Country API v1");
            options.RoutePrefix = string.Empty;
        });

        return app;
    }
}