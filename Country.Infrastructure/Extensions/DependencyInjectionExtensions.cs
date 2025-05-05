using Country.Domain.Interfaces.Repositories;
using Country.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Country.Infrastructure.Extensions;

/// <summary>
/// Extension methods for configuring infrastructure services.
/// </summary>
public static class DependencyInjectionExtensions
{
    /// <summary>
    /// Adds infrastructure-layer services, such as DbContext and repositories.
    /// </summary>
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration,
        string connectionStringName = "CountryDatabase")
    {
        services.AddDbContext<CountryDb>(options =>
            options.UseSqlServer(configuration.GetConnectionString(connectionStringName)));

        services.AddScoped<ICountryRepository, CountryRepository>();

        return services;
    }
}
