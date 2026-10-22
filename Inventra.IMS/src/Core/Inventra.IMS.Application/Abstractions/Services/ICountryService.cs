using Inventra.IMS.Application.DTOs.Country;

namespace Inventra.IMS.Application.Abstractions.Services
{
    public interface ICountryService
    {
        Task<CountryGetDTO> CreateCountryAsync(CountryPostDTO countryPostDTO,
            CancellationToken cancellationToken);

        Task<CountryGetDTO> GetCountryByUidAsync(Guid uid,
            bool isTarcking, CancellationToken cancellationToken);

        Task<List<CountryGetDTO>> GetAllCountriesAsync(
            bool isTarcking, CancellationToken cancellationToken);

        Task<List<CountryOptionDTO>> GetCountryOptionsAsync(bool isTracking,
        CancellationToken cancellationToken);

        Task DeleteCountryByUidAsync(Guid uid,
            bool isTracking, CancellationToken cancellationToken);
    }
}
