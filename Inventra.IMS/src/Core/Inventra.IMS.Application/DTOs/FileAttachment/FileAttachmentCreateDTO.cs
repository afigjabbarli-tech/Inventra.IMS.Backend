using Inventra.IMS.Domain.Enums;

namespace Inventra.IMS.Application.DTOs.FileAttachment
{
    public class FileAttachmentCreateDTO
    {
        public Guid FileUid { get; set; }
        public EntityType OwnerType { get; set; }
        public Guid OwnerUid { get; set; }
        public FilePurpose FilePurpose { get; set; }
        public int SortOrder { get; set; }
        public bool IsPrimary { get; set; }
    }
}
