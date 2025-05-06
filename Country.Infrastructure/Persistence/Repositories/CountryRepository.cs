using Country.Application.Models;
using Country.Application.Interfaces.Repositories;
using Country.Infrastructure.Persistence.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Country.Infrastructure.Persistence.Repositories;

public class CountryRepository : ICountryRepository
{
    private readonly CountryDb context;

    public CountryRepository(CountryDb context)
    {
        this.context = context;
    }

    public async Task<List<CountryDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.Countries
            .AsNoTracking()
            .ProjectToType<CountryDto>()
            .ToListAsync(cancellationToken);
    }

    public async Task<CountryDto?> GetCountryByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await context.Countries
            .AsNoTracking()
            .ProjectToType<CountryDto>()
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public async Task<CountryDto> CreateCountryAsync(CountryEntity country, CancellationToken cancellationToken)
    {
        context.Countries.Add(country);
        await context.SaveChangesAsync(cancellationToken);
        return country.Adapt<CountryDto>();
    }

    public async Task<CountryDto?> UpdateCountryAsync(int id, CountryEntity updatedCountry, CancellationToken cancellationToken)
    {
        var country = await context.Countries.FindAsync(new object[] { id }, cancellationToken);
        if (country == null) return null;

        country.Name = updatedCountry.Name;
        country.Alpha2Code = updatedCountry.Alpha2Code;

        await context.SaveChangesAsync(cancellationToken);
        return country.Adapt<CountryDto>();
    }

    public async Task<bool> DeleteCountryAsync(int id, CancellationToken cancellationToken)
    {
        var country = await context.Countries.FindAsync(new object[] { id }, cancellationToken);
        if (country == null) return false;

        context.Countries.Remove(country);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }
}