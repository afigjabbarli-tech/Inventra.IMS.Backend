using Inventra.IMS.Domain.Enums;

namespace Inventra.IMS.Application.DTOs.FileMetadata
{
    public class FileMetadataCreateDTO
    {
        public string OriginalFileName { get; set; } = string.Empty;
        public string StoredFileName { get; set; } = string.Empty;
        public string StorageKey { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public string Extension { get; set; } = string.Empty;
        public long SizeBytes { get; set; }
        public string? Checksum { get; set; }
        public StorageProvider StorageProvider { get; set; }
        public FileCategory FileCategory { get; set; }
    }
}
