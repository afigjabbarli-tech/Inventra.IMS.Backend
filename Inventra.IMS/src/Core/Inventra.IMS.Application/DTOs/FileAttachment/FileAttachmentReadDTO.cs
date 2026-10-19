using Inventra.IMS.Domain.Enums;

namespace Inventra.IMS.Application.DTOs.FileAttachment
{
    public class FileAttachmentReadDTO
    {
        public Guid uid { get; set; }

        public Guid file_uid { get; set; }

        public EntityType owner_type { get; set; }

        public Guid owner_uid { get; set; }

        public FilePurpose file_purpose { get; set; }

        public int sort_order { get; set; }

        public bool is_primary { get; set; }

        public DateTimeOffset created_at { get; set; }

        public DateTimeOffset? last_modified_at { get; set; }

        public Guid? created_by { get; set; }

        public Guid? last_modified_by { get; set; }
    }
}
