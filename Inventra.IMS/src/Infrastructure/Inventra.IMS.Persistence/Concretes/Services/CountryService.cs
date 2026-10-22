using AutoMapper;
using AutoMapper.QueryableExtensions;
using Inventra.IMS.Application.Abstractions.Services;
using Inventra.IMS.Application.Common.Exceptions;
using Inventra.IMS.Application.DTOs.Country;
using Inventra.IMS.Application.UofW;
using Inventra.IMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task<CountryGetDTO> CreateCountryAsync(CountryPostDTO countryPostDTO,
            CancellationToken cancellationToken)
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

        public async Task<CountryGetDTO> GetCountryByUidAsync(Guid uid,
            bool isTarcking, CancellationToken cancellationToken)
        {
            var country = await _unitOfWork.CountryReadRepository
                .GetByUidAsync(uid, isTarcking, cancellationToken);

            if (country is null)
            {
                throw new NotFoundException(
                $"Country with UID '{uid}' was not found!");
            }

            var countryGetDTO = _mapper.Map<CountryGetDTO>(country);

            return countryGetDTO;
        }

        public async Task DeleteCountryByUidAsync(Guid uid, 
            bool isTracking, CancellationToken cancellationToken)
        {
            var country = await _unitOfWork.CountryReadRepository
                .GetByUidAsync(uid, isTracking, cancellationToken);

            if(country is null)
            {
                throw new NotFoundException(
                $"Country with UID '{uid}' was not found!");
            }

            _unitOfWork.CountryWriteRepository.Remove(country);
        }

        public async Task<List<CountryGetDTO>> GetAllCountriesAsync(
        bool isTracking,
        CancellationToken cancellationToken)
        {
            var countriesGetDTO = await _unitOfWork.CountryReadRepository
                .GetAllAsQueryable(isTracking)
                .ProjectTo<CountryGetDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return countriesGetDTO;
        }

        public async Task<List<CountryOptionDTO>> GetCountryOptionsAsync(bool isTracking,
        CancellationToken cancellationToken)
        {
            var countryOptionsDTO = await _unitOfWork.CountryReadRepository
                .GetAllAsQueryable(isTracking)
                .ProjectTo<CountryOptionDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return countryOptionsDTO;
        }
    }
}
