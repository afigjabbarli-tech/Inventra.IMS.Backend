using Inventra.IMS.Application.Abstractions.Repositories.Country;

namespace Inventra.IMS.Application.UofW
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        ICountryReadRepository CountryReadRepository { get; }
        ICountryWriteRepository CountryWriteRepository { get; }

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
