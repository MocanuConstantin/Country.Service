using Country.Api.Mapping;
using Microsoft.OpenApi.Models;

namespace Country.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddMappings();
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