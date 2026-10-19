using Inventra.IMS.Domain.Enums;

namespace Inventra.IMS.Application.DTOs.FileMetadata
{
    public class FileMetadataReadDTO
    {
        public Guid uid { get; set; }
        public string original_file_name { get; set; } = string.Empty;
        public string stored_file_name { get; set; } = string.Empty;
        public string storage_key { get; set; } = string.Empty;
        public string content_type { get; set; } = string.Empty;
        public string extension { get; set; } = string.Empty;
        public long size_bytes { get; set; }
        public string? checksum { get; set; }
        public StorageProvider storage_provider { get; set; }
        public FileCategory file_category { get; set; }

        public DateTimeOffset created_at { get; set; }
        public DateTimeOffset? last_modified_at { get; set; }

        public Guid? created_by { get; set; }
        public Guid? last_modified_by { get; set; }
    }
}
