using Country.Domain.Entities;

namespace Country.Domain.Interfaces.Repositories;

public interface ICountryRepository
{
    Task<List<CountryEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CountryEntity?> GetCountryByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<CountryEntity> CreateCountryAsync(CountryEntity country, CancellationToken cancellationToken = default);
    Task<CountryEntity?> UpdateCountryAsync(int id, CountryEntity updatedCountry, CancellationToken cancellationToken = default);
    Task<bool> DeleteCountryAsync(int id, CancellationToken cancellationToken = default);
}