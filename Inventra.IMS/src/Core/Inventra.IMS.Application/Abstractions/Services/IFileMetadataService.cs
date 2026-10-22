using Inventra.IMS.Application.DTOs.FileMetadata;

namespace Inventra.IMS.Application.Abstractions.Services
{
    public interface IFileMetadataService
    {
        Task<FileMetadataReadDTO> CreateFileMetadataAsync(FileMetadataCreateDTO fileMetadataCreateDTO,
            CancellationToken cancellationToken);

        Task<FileMetadataReadDTO> GetFileMetadataByUidAsync(Guid uid, 
            bool isTracking, CancellationToken cancellationToken);

        Task DeleteFileMetadataByUidAsync(Guid uid,
            bool isTracking, CancellationToken cancellationToken);
    }
}
