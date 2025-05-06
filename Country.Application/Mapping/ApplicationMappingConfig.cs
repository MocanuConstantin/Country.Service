using Mapster;
using Country.Application.Models;
using Country.Domain.Entities;

namespace Country.Application.Mapping
{
    public class ApplicationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CountryDto, CountryEntity>();

            config.NewConfig<CountryEntity, CountryDto>();
        }
    }
}
