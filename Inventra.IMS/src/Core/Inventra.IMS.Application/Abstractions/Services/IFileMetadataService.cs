using Inventra.IMS.Application.DTOs.FileMetadata;

namespace Inventra.IMS.Application.Abstractions.Services
{
    public interface IFileMetadataService
    {
        Task<FileMetadataReadDTO> CreateFileMetadataAsync(FileMetadataCreateDTO fileMetadataCreateDTO,
            CancellationToken cancellationToken);
    }
}
