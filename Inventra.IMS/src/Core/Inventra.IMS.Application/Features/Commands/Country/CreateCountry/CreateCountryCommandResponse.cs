using Inventra.IMS.Application.DTOs.Country;

namespace Inventra.IMS.Application.Features.Commands.Country.CreateCountry
{
    public class CreateCountryCommandResponse
    {
        public CountryWithFlagGetDTO country_data { get; set; }
    }
}
