namespace Inventra.IMS.Application.UnitOfWork
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
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
