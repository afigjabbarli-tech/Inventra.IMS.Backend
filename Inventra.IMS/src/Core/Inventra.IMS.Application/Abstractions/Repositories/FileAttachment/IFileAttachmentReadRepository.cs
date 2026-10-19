namespace Inventra.IMS.Application.Abstractions.Repositories.FileAttachment
{
    public interface IFileAttachmentReadRepository
        : IReadRepository<Domain.Entities.FileAttachment, Guid, DateTimeOffset>
    {

    }
}
