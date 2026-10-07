using Inventra.IMS.Domain.Common.Entities;

namespace Inventra.IMS.Application.Repositories
{
    public interface IWriteRepository<TEntity, TKey, TDate>
        : IRepository<TEntity, TKey, TDate>
        where TEntity : SoftDeletableEntity<TKey, TDate>, new()
        where TKey : struct, IEquatable<TKey>
        where TDate : struct
    {
        TEntity Add(TEntity entity);

        Task<TEntity> AddAsync(
            TEntity entity,
            CancellationToken cancellationToken);

        void AddRange(IEnumerable<TEntity> entities);

        Task AddRangeAsync(
            IEnumerable<TEntity> entities,
            CancellationToken cancellationToken);

        TEntity Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
