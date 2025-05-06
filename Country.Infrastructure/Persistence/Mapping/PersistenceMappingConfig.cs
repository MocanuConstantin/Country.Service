using Mapster;
using Country.Infrastructure.Persistence.Entities;
using Country.Application.Models;

namespace Country.Infrastructure.Persistence.Mapping
{
    public class PersistenceMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CountryEntity, CountryDto>();

            config.NewConfig<CountryDto, CountryEntity>();
        }
    }
}
