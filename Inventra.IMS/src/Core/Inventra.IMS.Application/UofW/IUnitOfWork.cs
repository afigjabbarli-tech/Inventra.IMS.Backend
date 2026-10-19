using Inventra.IMS.Application.Abstractions.Repositories.Country;
using Inventra.IMS.Application.Abstractions.Repositories.FileAttachment;
using Inventra.IMS.Application.Abstractions.Repositories.FileMetadata;

namespace Inventra.IMS.Application.UofW
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        ICountryReadRepository CountryReadRepository { get; }
        ICountryWriteRepository CountryWriteRepository { get; }
        IFileMetadataReadRepository FileMetadataReadRepository { get; }
        IFileMetadataWriteRepository FileMetadataWriteRepository { get; }
        IFileAttachmentReadRepository FileAttachmentReadRepository { get; }
        IFileAttachmentWriteRepository FileAttachmentWriteRepository { get; }
        int SaveChanges();

        Task<int> SaveChangesAsync(
            CancellationToken cancellationToken);

        void BeginTransaction();

        Task BeginTransactionAsync(
            CancellationToken cancellationToken);

        void CommitTransaction();

        Task CommitTransactionAsync(
            CancellationToken cancellationToken);

        void RollbackTransaction();

        Task RollbackTransactionAsync(
            CancellationToken cancellationToken);
    }
}
