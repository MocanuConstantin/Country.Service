using Country.Application.Models;
using Country.Domain.Entities;

namespace Country.Application.Interfaces.Services;

public interface ICountryService
{
    Task<List<CountryDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CountryDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<CountryDto> CreateAsync(CountryDto country, CancellationToken cancellationToken = default);
    Task<CountryDto?> UpdateAsync(int id, CountryDto updatedCountry, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}