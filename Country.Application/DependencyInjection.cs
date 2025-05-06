using Country.Application.Services;
using Country.Application.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Country.Application.Mapping;

namespace Country.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMappings();
        services.AddScoped<ICountryService, CountryService>();

        return services;
    }
}
