using Inventra.IMS.Application.UnitOfWork;
using Inventra.IMS.Persistence.Contexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace Inventra.IMS.Persistence.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly InventraDbContext _context;

        private IDbContextTransaction? _transaction;

        private bool _disposed;

        public UnitOfWork(InventraDbContext inventraDbContext)
        {
            _context = inventraDbContext;
        }

        public void BeginTransaction()
        {
            ThrowIfDisposed();

            if (_transaction is not null)
                throw new InvalidOperationException(
                    "A transaction is already active.");

            _transaction = _context.Database
            .BeginTransaction();
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken)
        {
            ThrowIfDisposed();

            if (_transaction is not null)
                throw new InvalidOperationException(
                    "A transaction is already active.");

            _transaction = await _context.Database
                .BeginTransactionAsync(cancellationToken);
        }

        public void CommitTransaction()
        {
            ThrowIfDisposed();

            EnsureTransactionExists();

            try
            {
                _transaction!.Commit();
            }
            finally
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken)
        {
            ThrowIfDisposed();

            EnsureTransactionExists();

            try
            {
                await _transaction!.CommitAsync(
                    cancellationToken);
            }
            finally
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            _transaction?.Dispose();

            _transaction = null;

            _disposed = true;

            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            if (_disposed)
                return;

            if (_transaction is not null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }

            _disposed = true;

            GC.SuppressFinalize(this);
        }

        public void RollbackTransaction()
        {
            ThrowIfDisposed();

            if (_transaction is null)
                return;

            try
            {
                _transaction.Rollback();
            }
            finally
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken)
        {
            ThrowIfDisposed();

            if (_transaction is null)
                return;

            try
            {
                await _transaction.RollbackAsync(
                    cancellationToken);
            }
            finally
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public int SaveChanges()
        {
            ThrowIfDisposed();

            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            ThrowIfDisposed();

            return await _context.SaveChangesAsync(
                cancellationToken);
        }

        private void EnsureTransactionExists()
        {
            if (_transaction is null)
                throw new InvalidOperationException(
                    "No active transaction exists.");
        }

        private void ThrowIfDisposed()
        {
            ObjectDisposedException.ThrowIf(
                _disposed,
                this);
        }
    }
}
