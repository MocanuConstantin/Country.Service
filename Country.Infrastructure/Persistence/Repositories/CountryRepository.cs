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
        var dbItems = await context.Countries
                                    .AsNoTracking()
                                    .ToListAsync(cancellationToken);
        return dbItems.Adapt<List<CountryDto>>();
    }

    public async Task<CountryDto?> GetCountryByIdAsync(int id, CancellationToken cancellationToken)
    {
        var db = await context.Countries.FindAsync(new object[] { id }, cancellationToken);
        return db?.Adapt<CountryDto>();
    }

    public async Task<CountryDto> CreateCountryAsync(CountryDto country, CancellationToken cancellationToken)
    {
        var dbModel = country.Adapt<CountryEntity>();
        context.Countries.Add(dbModel);
        await context.SaveChangesAsync(cancellationToken);

        return dbModel.Adapt<CountryDto>();
    }

    public async Task<CountryDto?> UpdateCountryAsync(int id, CountryDto updatedCountry, CancellationToken cancellationToken)
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