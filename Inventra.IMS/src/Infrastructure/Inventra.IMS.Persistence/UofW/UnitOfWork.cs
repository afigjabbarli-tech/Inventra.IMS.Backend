using Inventra.IMS.Application.Abstractions.Repositories.Country;
using Inventra.IMS.Application.Abstractions.Repositories.FileAttachment;
using Inventra.IMS.Application.Abstractions.Repositories.FileMetadata;
using Inventra.IMS.Application.UofW;
using Inventra.IMS.Persistence.Concretes.Repositories.Country;
using Inventra.IMS.Persistence.Concretes.Repositories.FileAttachment;
using Inventra.IMS.Persistence.Concretes.Repositories.FileMetadata;
using Inventra.IMS.Persistence.Contexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace Inventra.IMS.Persistence.UofW
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly InventraDbContext _context;

        private ICountryReadRepository? _countryReadRepository;
        private ICountryWriteRepository? _countryWriteRepository;
        private IFileMetadataReadRepository? _fileMetadataReadRepository;
        private IFileMetadataWriteRepository? _fileMetadataWriteRepository;
        private IFileAttachmentReadRepository? _fileAttachmentReadRepository;
        private IFileAttachmentWriteRepository? _fileAttachmentWriteRepository;

        private IDbContextTransaction? _transaction;

        private bool _disposed;

        public UnitOfWork(InventraDbContext inventraDbContext)
        {
            _context = inventraDbContext;
        }

        public ICountryReadRepository CountryReadRepository => _countryReadRepository ??= new CountryReadRepository(_context);

        public ICountryWriteRepository CountryWriteRepository => _countryWriteRepository ??= new CountryWriteRepository(_context);

        public IFileMetadataReadRepository FileMetadataReadRepository => _fileMetadataReadRepository ??= new FileMetadataReadRepository(_context);

        public IFileMetadataWriteRepository FileMetadataWriteRepository => _fileMetadataWriteRepository ??= new FileMetadataWriteRepository(_context);

        public IFileAttachmentReadRepository FileAttachmentReadRepository => _fileAttachmentReadRepository ??= new FileAttachmentReadRepository(_context);

        public IFileAttachmentWriteRepository FileAttachmentWriteRepository => _fileAttachmentWriteRepository ??= new FileAttachmentWriteRepository(_context);

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
