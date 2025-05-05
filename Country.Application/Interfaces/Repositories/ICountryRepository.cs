using Country.Application.Models;
using Country.Domain.Entities;

namespace Country.Domain.Interfaces.Repositories;

public interface ICountryRepository
{
    Task<List<CountryDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CountryDto?> GetCountryByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<CountryDto> CreateCountryAsync(CountryEntity country, CancellationToken cancellationToken = default);
    Task<CountryDto?> UpdateCountryAsync(int id, CountryEntity updatedCountry, CancellationToken cancellationToken = default);
    Task<bool> DeleteCountryAsync(int id, CancellationToken cancellationToken = default);
}