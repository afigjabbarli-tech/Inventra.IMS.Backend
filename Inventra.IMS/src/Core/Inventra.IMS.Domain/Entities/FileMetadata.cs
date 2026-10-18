using Inventra.IMS.Domain.Common.Entities;
using Inventra.IMS.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventra.IMS.Domain.Entities
{
    [Table(name: "files", Schema = "public")]
    public class FileMetadata : SoftDeletableEntity<Guid, DateTimeOffset>
    {
        [Column("original_file_name", Order = 8, TypeName = "text")]
        public string OriginalFileName { get; set; } = string.Empty;

        [Column("stored_file_name", Order = 9, TypeName = "text")]
        public string StoredFileName { get; set; } = string.Empty;

        [Column("storage_key", Order = 10, TypeName = "text")]
        public string StorageKey { get; set; } = string.Empty;

        [Column("content_type", Order = 11, TypeName = "text")]
        public string ContentType { get; set; } = string.Empty;

        [Column("extension", Order = 12, TypeName = "varchar(50)")]
        public string Extension { get; set; } = string.Empty;

        [Column("size_bytes", Order = 13, TypeName = "bigint")]
        public long SizeBytes { get; set; }

        [Column("checksum", Order = 14, TypeName = "varchar(128)")]
        public string? Checksum { get; set; }

        [Column("storage_provider", Order = 15, TypeName = "integer")]
        public StorageProvider StorageProvider { get; set; }

        [Column("file_category", Order = 16, TypeName = "integer")]
        public FileCategory FileCategory { get; set; }
    }
}
