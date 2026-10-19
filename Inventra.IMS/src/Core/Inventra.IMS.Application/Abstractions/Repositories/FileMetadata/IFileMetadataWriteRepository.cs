namespace Inventra.IMS.Application.Abstractions.Repositories.FileMetadata
{
    public interface IFileMetadataWriteRepository
        : IWriteRepository<Domain.Entities.FileMetadata, Guid, DateTimeOffset>
    {

    }
}
