
using Country.Domain.Entities;
using Country.Domain.Interfaces.Repositories;
using Country.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace Country.Application.Services;

public class CountryService : ICountryService
{
    private readonly ICountryRepository repository;
    private readonly ILogger<CountryService> logger;

    public CountryService(ICountryRepository repository, ILogger<CountryService> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<List<CountryEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            return await repository.GetAllAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to get all CountryEntities");
            return new List<CountryEntity>();
        }
    }

    public async Task<CountryEntity?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.GetCountryByIdAsync(id, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to get country by ID {Id}", id);
            return null;
        }
    }

    public async Task<CountryEntity> CreateAsync(CountryEntity country, CancellationToken cancellationToken = default)
    {
        try
        {
            return await repository.CreateCountryAsync(country, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to create CountryEntity");
            throw;
        }
    }

    public async Task<CountryEntity?> UpdateAsync(int id, CountryEntity updatedCountry, CancellationToken cancellationToken = default)
    {
        try
        {
            return await repository.UpdateCountryAsync(id, updatedCountry, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to update CountryEntity");
            throw;
        }
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            return await repository.DeleteCountryAsync(id, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to delete CountryEntity");
            throw;
        }
    }
}