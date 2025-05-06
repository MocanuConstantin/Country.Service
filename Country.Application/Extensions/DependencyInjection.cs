using Country.Application.Services;
using Country.Application.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Country.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICountryService, CountryService>();

        return services;
    }
}
