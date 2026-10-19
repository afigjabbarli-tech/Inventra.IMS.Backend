using Inventra.IMS.Application.Abstractions.Repositories.FileMetadata;
using Inventra.IMS.Persistence.Contexts;

namespace Inventra.IMS.Persistence.Concretes.Repositories.FileMetadata
{
    public sealed class FileMetadataWriteRepository
        : WriteRepository<Domain.Entities.FileMetadata, Guid, DateTimeOffset>,
        IFileMetadataWriteRepository
    {
        public FileMetadataWriteRepository(InventraDbContext inventraDbContext)
            : base(inventraDbContext) { }
    }
}
