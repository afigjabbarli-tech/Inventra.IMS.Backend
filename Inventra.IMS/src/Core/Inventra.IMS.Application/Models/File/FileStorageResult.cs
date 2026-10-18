using Inventra.IMS.Domain.Enums;

namespace Inventra.IMS.Application.Models.File
{
    public class FileStorageResult
    {
        public string OriginalFileName { get; set; } = string.Empty;
        public string StorageFileName { get; set; } = string.Empty;
        public string StorageKey { get; set; } = string.Empty;
        public long SizeBytes { get; set; }
        public string Extension { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public string? Checksum { get; set; }
        public StorageProvider StorageProvider { get; set; }
        public FileCategory FileCategory { get; set; }
    }
}
