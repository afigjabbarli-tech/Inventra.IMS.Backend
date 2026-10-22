using Inventra.IMS.Application.DTOs.FileAttachment;
using Inventra.IMS.Domain.Enums;

namespace Inventra.IMS.Application.Abstractions.Services
{
    public interface IFileAttachmentService
    {
        Task<FileAttachmentReadDTO> CreateFileAttachmentAsync(
            FileAttachmentCreateDTO fileAttachmentCreateDTO,
            CancellationToken cancellationToken);

        Task<FileAttachmentReadDTO> GetFileAttachmentByOwnerAsync(
            EntityType ownerType, Guid ownerUid,
            bool isTarcking, CancellationToken cancellationToken);

        Task DeleteFileAttachmentByOwnerAsync(
            EntityType ownerType, Guid ownerUid,
            bool isTarcking, CancellationToken cancellationToken);
    }
}
