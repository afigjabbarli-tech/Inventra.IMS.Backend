using Inventra.IMS.Domain.Common.Entities;
using Inventra.IMS.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventra.IMS.Domain.Entities
{
    [Table("file_attachments", Schema = "public")]
    public class FileAttachment : SoftDeletableEntity<Guid, DateTimeOffset>
    {
        [Column("file_uid", Order = 8, TypeName = "uuid")]
        public Guid FileUid { get; set; }

        [Column("owner_type", Order = 9, TypeName = "integer")]
        public EntityType OwnerType { get; set; }

        [Column("owner_uid", Order = 10, TypeName = "uuid")]
        public Guid OwnerUid { get; set; }

        [Column("file_purpose", Order = 11, TypeName = "integer")]
        public FilePurpose FilePurpose { get; set; }

        [Column("sort_order", Order = 12, TypeName = "integer")]
        public int SortOrder { get; set; }

        [Column("is_primary", Order = 13, TypeName = "boolean")]
        public bool IsPrimary { get; set; }
    }
}
