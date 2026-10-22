using Inventra.IMS.Application.Abstractions.Capabilities;
using Inventra.IMS.Application.Abstractions.Services;
using Inventra.IMS.Application.DTOs.Country;
using Inventra.IMS.Domain.Enums;
using MediatR;

namespace Inventra.IMS.Application.Features.Queries.Country.GetCountryByUid
{
    public class GetCountryByUidQueryHandler : IRequestHandler<GetCountryByUidQueryRequest, GetCountryByUidQueryResponse>
    {
        private readonly ICountryService _countryService;
        private readonly IFileAttachmentService _fileAttachmentService;
        private readonly IFileMetadataService _fileMetadataService;
        private readonly IFileStorageService _fileStorageService;
        public GetCountryByUidQueryHandler(ICountryService countryService,
            IFileAttachmentService fileAttachmentService,
            IFileMetadataService fileMetadataService,
            IFileStorageService fileStorageService)
        {
            _countryService = countryService;
            _fileAttachmentService = fileAttachmentService;
            _fileMetadataService = fileMetadataService;
            _fileStorageService = fileStorageService;
        }
        public async Task<GetCountryByUidQueryResponse> Handle(GetCountryByUidQueryRequest request,
            CancellationToken cancellationToken)
        {
            var countryGetDTO = await _countryService
                .GetCountryByUidAsync(request.Uid, false, cancellationToken);

            var fileAttachmentReadDTO = await _fileAttachmentService
                .GetFileAttachmentByOwnerAsync(EntityType.Country, countryGetDTO.uid,
                false, cancellationToken);

            var fileMetadataReadDTO = await _fileMetadataService
                .GetFileMetadataByUidAsync(fileAttachmentReadDTO.file_uid,
                false, cancellationToken);

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

            var countryWithFlagGetDTO = new CountryWithFlagGetDTO
            {
                country = countryGetDTO,
                flag = countryFlagGetDTO
            };

            var getCountryByUidQueryResponse = new GetCountryByUidQueryResponse
            {
                country_data = countryWithFlagGetDTO
            };

            return getCountryByUidQueryResponse;
        }
    }
}
