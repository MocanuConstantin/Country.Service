using Country.Application.Interfaces.Repositories;
using Country.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Country.Infrastructure.Persistence.Extensions;

public static class DependencyInjection
{
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
