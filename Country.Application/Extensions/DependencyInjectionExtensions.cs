using Country.Application.Services;
using Country.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Country.Application.Extensions;

/// <summary>
/// Provides extension methods to register Application layer services.
/// </summary>
public static class DependencyInjectionExtensions
{
    /// <summary>
    /// Adds Application layer services (e.g., use case services).
    /// </summary>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICountryService, CountryService>();

        return services;
    }
}
