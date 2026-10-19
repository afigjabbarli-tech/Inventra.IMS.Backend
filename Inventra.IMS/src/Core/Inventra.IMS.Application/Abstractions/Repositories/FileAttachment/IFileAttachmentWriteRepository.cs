namespace Inventra.IMS.Application.Abstractions.Repositories.FileAttachment
{
    public interface IFileAttachmentWriteRepository
        : IWriteRepository<Domain.Entities.FileAttachment, Guid, DateTimeOffset>
    {

    }
}
