using Inventra.IMS.Application.Abstractions.Repositories;
using Inventra.IMS.Application.Abstractions.Repositories.FileAttachment;
using Inventra.IMS.Persistence.Contexts;

namespace Inventra.IMS.Persistence.Concretes.Repositories.FileAttachment
{
    public sealed class FileAttachmentReadRepository
        : ReadRepository<Domain.Entities.FileAttachment, Guid, DateTimeOffset>,
        IFileAttachmentReadRepository
    {
        public FileAttachmentReadRepository(InventraDbContext inventraDbContext)
        : base(inventraDbContext) { }
    }
}
