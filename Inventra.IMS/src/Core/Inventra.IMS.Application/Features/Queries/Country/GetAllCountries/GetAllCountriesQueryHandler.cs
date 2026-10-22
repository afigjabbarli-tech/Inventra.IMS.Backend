using Inventra.IMS.Application.Abstractions.Capabilities;
using Inventra.IMS.Application.Abstractions.Services;
using Inventra.IMS.Application.DTOs.Country;
using Inventra.IMS.Domain.Enums;
using MediatR;

namespace Inventra.IMS.Application.Features.Queries.Country.GetAllCountries
{
    public class GetAllCountriesQueryHandler
        : IRequestHandler<GetAllCountriesQueryRequest, GetAllCountriesQueryResponse>
    {
        private readonly ICountryService _countryService;
        private readonly IFileAttachmentService _fileAttachmentService;
        private readonly IFileMetadataService _fileMetadataService;
        private readonly IFileStorageService _fileStorageService;

        public GetAllCountriesQueryHandler(ICountryService countryService,
            IFileAttachmentService fileAttachmentService,
            IFileMetadataService fileMetadataService,
            IFileStorageService fileStorageService)
        {
            _countryService = countryService;
            _fileAttachmentService = fileAttachmentService;
            _fileMetadataService = fileMetadataService;
            _fileStorageService = fileStorageService;
        }

        public async Task<GetAllCountriesQueryResponse> Handle(
        GetAllCountriesQueryRequest request,
        CancellationToken cancellationToken)
        {
            var countriesGetDTO = await _countryService
                .GetAllCountriesAsync(false, cancellationToken);

            var countriesWithFlags = new List<CountryWithFlagGetDTO>();

            foreach (var countryGetDTO in countriesGetDTO)
            {
                var fileAttachmentReadDTO = await _fileAttachmentService
                    .GetFileAttachmentByOwnerAsync(
                        EntityType.Country,
                        countryGetDTO.uid,
                        false,
                        cancellationToken);

                var fileMetadataReadDTO = await _fileMetadataService
                    .GetFileMetadataByUidAsync(
                        fileAttachmentReadDTO.file_uid,
                        false,
                        cancellationToken);

                var countryFlagPublicURL = _fileStorageService
                    .GeneratePublicURL(fileMetadataReadDTO.storage_key);

                var countryFlagGetDTO = new CountryFlagGetDTO
                {
                    original_file_name = fileMetadataReadDTO.original_file_name,
                    file_purpose = fileAttachmentReadDTO.file_purpose,
                    is_primary = fileAttachmentReadDTO.is_primary,
                    sort_order = fileAttachmentReadDTO.sort_order,
                    file_category = fileMetadataReadDTO.file_category,
                    file_attachment_uid = fileAttachmentReadDTO.uid,
                    url = countryFlagPublicURL
                };

                countriesWithFlags.Add(new CountryWithFlagGetDTO
                {
                    country = countryGetDTO,
                    flag = countryFlagGetDTO
                });
            }

            return new GetAllCountriesQueryResponse
            {
                countries_data = countriesWithFlags
            };
        }
    }
}
