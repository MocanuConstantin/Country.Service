using Country.Application.Models;
using Country.Domain.Entities;

namespace Country.Application.Interfaces.Repositories;

public interface ICountryRepository
{
    Task<List<CountryDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CountryDto?> GetCountryByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<CountryDto> CreateCountryAsync(CountryDto country, CancellationToken cancellationToken = default);
    Task<CountryDto?> UpdateCountryAsync(int id, CountryDto updatedCountry, CancellationToken cancellationToken = default);
    Task<bool> DeleteCountryAsync(int id, CancellationToken cancellationToken = default);
}