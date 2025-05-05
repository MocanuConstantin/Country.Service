using Country.Application.Models;
using Country.Domain.Entities;

namespace Country.Application.Interfaces.Services;

public interface ICountryService
{
    Task<List<CountryDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CountryDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<CountryDto> CreateAsync(CountryEntity country, CancellationToken cancellationToken = default);
    Task<CountryDto?> UpdateAsync(int id, CountryEntity updatedCountry, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}