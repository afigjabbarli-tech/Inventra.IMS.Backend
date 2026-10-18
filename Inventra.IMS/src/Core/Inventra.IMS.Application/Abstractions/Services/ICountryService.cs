using Inventra.IMS.Application.DTOs.Country;

namespace Inventra.IMS.Application.Abstractions.Services
{
    public interface ICountryService
    {
        Task<CountryGetDTO> CreateCountryAsync(CountryPostDTO countryPostDTO,
            CancellationToken cancellationToken);
    }
}
