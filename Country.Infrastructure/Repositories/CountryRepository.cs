using Country.Domain.Entities;
using Country.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Country.Infrastructure.Repositories;

public class CountryRepository : ICountryRepository
{
    private readonly CountryDb context;

    public CountryRepository(CountryDb context)
    {
        this.context = context;
    }

    public async Task<List<CountryEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.Countries
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<CountryEntity?> GetCountryByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await context.Countries
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public async Task<CountryEntity> CreateCountryAsync(CountryEntity country, CancellationToken cancellationToken)
    {
        context.Countries.Add(country);
        await context.SaveChangesAsync(cancellationToken);
        return country;
    }

    public async Task<CountryEntity?> UpdateCountryAsync(int id, CountryEntity updatedCountry, CancellationToken cancellationToken)
    {
        var country = await context.Countries.FindAsync(new object[] { id }, cancellationToken);
        if (country == null) return null;

        country.Name = updatedCountry.Name;
        country.Alpha_2_Code = updatedCountry.Alpha_2_Code;

        await context.SaveChangesAsync(cancellationToken);
        return country;
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