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
            var dtos = await repository.GetAllAsync(cancellationToken);
            return dtos;
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
            var dto = await repository.GetCountryByIdAsync(id, cancellationToken);
            return dto;
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
            var createdDto = await repository.CreateCountryAsync(country, cancellationToken);
            return createdDto.Adapt<CountryDto>();
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
            var dto = await repository.UpdateCountryAsync(id, updatedCountry, cancellationToken);
            return dto;
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