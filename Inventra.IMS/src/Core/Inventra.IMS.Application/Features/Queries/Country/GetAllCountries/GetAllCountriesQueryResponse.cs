using Inventra.IMS.Application.DTOs.Country;

namespace Inventra.IMS.Application.Features.Queries.Country.GetAllCountries
{
    public class GetAllCountriesQueryResponse
    {
        public List<CountryWithFlagGetDTO> countries_data { get; set; }    
    }
}
