namespace Inventra.IMS.Application.Abstractions.Repositories.FileMetadata
{
    public interface IFileMetadataReadRepository
        : IReadRepository<Domain.Entities.FileMetadata, Guid, DateTimeOffset>
    {

    }
}
