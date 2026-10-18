using AutoMapper;
using Inventra.IMS.Application.Abstractions.Services;
using Inventra.IMS.Application.Common.Exceptions;
using Inventra.IMS.Application.DTOs.Country;
using Inventra.IMS.Application.UofW;
using Inventra.IMS.Domain.Entities;

namespace Inventra.IMS.Persistence.Concretes.Services
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CountryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CountryGetDTO> CreateCountryAsync(CountryPostDTO countryPostDTO, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.CountryReadRepository
                .ExistAsync(
                    country => country.Alpha2Code.Equals(
                        countryPostDTO.alpha2_code.Trim().ToUpperInvariant()),
                    cancellationToken))
            {
                throw new ResourceAlreadyExistsException(
                    nameof(Country),
                    nameof(Country.Alpha2Code),
                    countryPostDTO.alpha2_code.Trim().ToUpperInvariant());
            }

            if (await _unitOfWork.CountryReadRepository
                .ExistAsync(
                    country => country.Alpha3Code.Equals(
                        countryPostDTO.alpha3_code.Trim().ToUpperInvariant()),
                    cancellationToken))
            {
                throw new ResourceAlreadyExistsException(
                    nameof(Country),
                    nameof(Country.Alpha3Code),
                    countryPostDTO.alpha3_code.Trim().ToUpperInvariant());
            }

            if (await _unitOfWork.CountryReadRepository
                .ExistAsync(
                    country => country.NumericCode.Equals(
                        countryPostDTO.numeric_code.Trim()),
                    cancellationToken))
            {
                throw new ResourceAlreadyExistsException(
                    nameof(Country),
                    nameof(Country.NumericCode),
                    countryPostDTO.numeric_code.Trim());
            }

            var country = _mapper.Map<Country>(countryPostDTO);

            var addedCountry = await _unitOfWork.CountryWriteRepository
                   .AddAsync(country, cancellationToken);

            var countryGetDTO = _mapper.Map<CountryGetDTO>(addedCountry);

            return countryGetDTO;
        }
    }
}
