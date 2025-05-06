using Country.Application.Models;
using Country.Application.Interfaces.Repositories;
using Country.Application.Interfaces.Services;
using Mapster;
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

    public async Task<List<CountryDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var entities = await repository.GetAllAsync(cancellationToken);
            return entities;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to get all CountryEntities");
            return new List<CountryDto>();
        }
    }

    public async Task<CountryDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await repository.GetCountryByIdAsync(id, cancellationToken);
            return entity;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to get country by ID {Id}", id);
            return null;
        }
    }

    public async Task<CountryDto> CreateAsync(CountryDto country, CancellationToken cancellationToken = default)
    {
        try
        {
            var createdCountry = await repository.CreateCountryAsync(country, cancellationToken);
            return createdCountry.Adapt<CountryDto>();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to create CountryEntity");
            throw;
        }
    }

    public async Task<CountryDto?> UpdateAsync(int id, CountryDto updatedCountry, CancellationToken cancellationToken = default)
    {
        try
        {
            var updated = await repository.UpdateCountryAsync(id, updatedCountry, cancellationToken);
            return updated?.Adapt<CountryDto>();
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