using Inventra.IMS.Application.Abstractions.Repositories.FileMetadata;
using Inventra.IMS.Persistence.Contexts;

namespace Inventra.IMS.Persistence.Concretes.Repositories.FileMetadata
{
    public sealed class FileMetadataReadRepository
        : ReadRepository<Domain.Entities.FileMetadata, Guid, DateTimeOffset>,
        IFileMetadataReadRepository
    {
        public FileMetadataReadRepository(InventraDbContext inventraDbContext)
            : base(inventraDbContext) { }
    }
}
