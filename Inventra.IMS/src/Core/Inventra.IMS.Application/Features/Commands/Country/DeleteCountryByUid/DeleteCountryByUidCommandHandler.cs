using Inventra.IMS.Application.Abstractions.Capabilities;
using Inventra.IMS.Application.Abstractions.Services;
using Inventra.IMS.Application.UofW;
using Inventra.IMS.Domain.Enums;
using MediatR;

namespace Inventra.IMS.Application.Features.Commands.Country.DeleteCountryByUid
{
    public class DeleteCountryByUidCommandHandler
        : IRequestHandler<DeleteCountryByUidCommandRequest, DeleteCountryByUidCommandResponse>
    {
        private readonly ICountryService _countryService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorageService;
        private readonly IFileAttachmentService _fileAttachmentService;
        private readonly IFileMetadataService _fileMetadataService;

        public DeleteCountryByUidCommandHandler(ICountryService countryService,
            IUnitOfWork unitOfWork, IFileStorageService fileStorageService,
            IFileAttachmentService fileAttachmentService, IFileMetadataService fileMetadataService)
        {
            _countryService = countryService;
            _unitOfWork = unitOfWork;
            _fileStorageService = fileStorageService;
            _fileAttachmentService = fileAttachmentService;
            _fileMetadataService = fileMetadataService;
        }
        public async Task<DeleteCountryByUidCommandResponse> Handle(DeleteCountryByUidCommandRequest request,
            CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            try
            {
                await _countryService
                .DeleteCountryByUidAsync(request.Uid, true, cancellationToken);

                var fileAttachmentReadDTO = await _fileAttachmentService
                    .GetFileAttachmentByOwnerAsync(EntityType.Country, request.Uid,
                    false, cancellationToken);

                var fileMetadataReadDTO = await _fileMetadataService
                    .GetFileMetadataByUidAsync(fileAttachmentReadDTO.file_uid, false, cancellationToken);

                _fileStorageService.Delete(fileMetadataReadDTO.storage_key);

                await _fileAttachmentService.DeleteFileAttachmentByOwnerAsync(
                    EntityType.Country, request.Uid, true, cancellationToken);

                await _fileMetadataService.DeleteFileMetadataByUidAsync(
                    fileMetadataReadDTO.uid, true, cancellationToken);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                await _unitOfWork.CommitTransactionAsync(cancellationToken);

                return new DeleteCountryByUidCommandResponse();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync(CancellationToken.None);

                throw;
            }
        }
    }
}
