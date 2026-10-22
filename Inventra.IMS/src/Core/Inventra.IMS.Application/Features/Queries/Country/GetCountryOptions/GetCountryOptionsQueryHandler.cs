using Inventra.IMS.Application.Abstractions.Capabilities;
using Inventra.IMS.Application.Abstractions.Services;
using Inventra.IMS.Application.DTOs.FileAttachment;
using Inventra.IMS.Domain.Enums;
using MediatR;

namespace Inventra.IMS.Application.Features.Queries.Country.GetCountryOptions
{
    public class GetCountryOptionsQueryHandler
        : IRequestHandler<GetCountryOptionsQueryRequest, GetCountryOptionsQueryResponse>
    {
        private readonly ICountryService _countryService;
        private readonly IFileAttachmentService _fileAttachmentService; 
        private readonly IFileStorageService _fileStorageService;
        private readonly IFileMetadataService _fileMetadataService;
        public GetCountryOptionsQueryHandler(ICountryService countryService,
            IFileStorageService fileStorageService,
            IFileAttachmentService fileAttachmentService,
            IFileMetadataService fileMetadataService)
        {
            _countryService = countryService;
            _fileStorageService = fileStorageService;
            _fileAttachmentService = fileAttachmentService;
            _fileMetadataService = fileMetadataService;
        }

        public async Task<GetCountryOptionsQueryResponse> Handle(
            GetCountryOptionsQueryRequest request, CancellationToken cancellationToken)
        {
            var countryOptionsDTO = await _countryService
                .GetCountryOptionsAsync(false, cancellationToken);

            foreach (var countryOptionDTO in countryOptionsDTO)
            {
                var fileAttachmentReadDTO = await _fileAttachmentService
                    .GetFileAttachmentByOwnerAsync(EntityType.Country,
                    countryOptionDTO.uid, false, cancellationToken);

                var fileMetadataReadDTO = await _fileMetadataService
                    .GetFileMetadataByUidAsync(fileAttachmentReadDTO.file_uid,
                    false, cancellationToken);

                var countryFlagPublicURL = _fileStorageService
                    .GeneratePublicURL(fileMetadataReadDTO.storage_key);

                countryOptionDTO.flag_url = countryFlagPublicURL;
            }

            var getCountryOptionsQueryResponse = new GetCountryOptionsQueryResponse()
            {
                country_options_data = countryOptionsDTO
            };

            return getCountryOptionsQueryResponse;
        }
    }
}
