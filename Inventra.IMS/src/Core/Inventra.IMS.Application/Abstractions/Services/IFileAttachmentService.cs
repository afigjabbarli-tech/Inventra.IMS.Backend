using Inventra.IMS.Application.DTOs.FileAttachment;

namespace Inventra.IMS.Application.Abstractions.Services
{
    public interface IFileAttachmentService
    {
        Task<FileAttachmentReadDTO> CreateFileAttachmentAsync(
            FileAttachmentCreateDTO fileAttachmentCreateDTO,
            CancellationToken cancellationToken);
    }
}
