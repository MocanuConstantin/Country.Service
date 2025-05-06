using Mapster;
using Country.Api.Models.Requests;
using Country.Api.Models.Responses;
using Country.Application.Models;

namespace Country.Api.Mapping
{
    public class ApiMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CountryRequest, CountryDto>();

            config.NewConfig<CountryDto, CountryResponse>();
        }
    }
}
