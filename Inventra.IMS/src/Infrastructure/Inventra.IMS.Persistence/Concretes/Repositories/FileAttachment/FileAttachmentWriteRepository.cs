using Inventra.IMS.Application.Abstractions.Repositories.FileAttachment;
using Inventra.IMS.Persistence.Contexts;

namespace Inventra.IMS.Persistence.Concretes.Repositories.FileAttachment
{
    public sealed class FileAttachmentWriteRepository
        : WriteRepository<Domain.Entities.FileAttachment, Guid, DateTimeOffset>,
        IFileAttachmentWriteRepository
    {
        public FileAttachmentWriteRepository(InventraDbContext inventraDbContext)
        : base(inventraDbContext) { }
    }
}
