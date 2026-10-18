using Inventra.IMS.Application.Models.File;

namespace Inventra.IMS.Application.Abstractions.Capabilities
{
    public interface IFileStorageService
    {
        Task<FileStorageResult> UploadAsync(FileUploadParameters parameters,
            int length, CancellationToken cancellationToken);
    }
}
