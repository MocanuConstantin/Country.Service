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
        var entities = await context.Countries
                                    .AsNoTracking()
                                    .ToListAsync(cancellationToken);
        return entities.Adapt<List<CountryDto>>();
    }

    public async Task<CountryDto?> GetCountryByIdAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await context.Countries.FindAsync(new object[] { id }, cancellationToken);
        return entity?.Adapt<CountryDto>();
    }

    public async Task<CountryDto> CreateCountryAsync(CountryDto country, CancellationToken cancellationToken)
    {
        var entity = country.Adapt<CountryEntity>();
        context.Countries.Add(entity);

        await context.SaveChangesAsync(cancellationToken);
        return entity.Adapt<CountryDto>();
    }

    public async Task<CountryDto?> UpdateCountryAsync(int id, CountryDto updatedCountry, CancellationToken cancellationToken)
    {
        var entity = await context.Countries.FindAsync(new object[] { id }, cancellationToken);
        if (entity == null) return null;

        //country.Name = updatedCountry.Name;
        //country.Alpha2Code = updatedCountry.Alpha2Code;
        updatedCountry.Adapt(entity);

        await context.SaveChangesAsync(cancellationToken);
        return entity.Adapt<CountryDto>();
    }

    public async Task<bool> DeleteCountryAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await context.Countries.FindAsync(new object[] { id }, cancellationToken);
        if (entity == null) return false;

        context.Countries.Remove(entity);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }
}