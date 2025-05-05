
using Country.Domain.Entities;

namespace Country.Domain.Interfaces.Services;

public interface ICountryService
{
    Task<List<CountryEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CountryEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<CountryEntity> CreateAsync(CountryEntity country, CancellationToken cancellationToken = default);
    Task<CountryEntity?> UpdateAsync(int id, CountryEntity updatedCountry, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}