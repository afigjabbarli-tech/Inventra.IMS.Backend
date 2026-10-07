using Inventra.IMS.Application.Repositories;
using Inventra.IMS.Domain.Common.Entities;
using Inventra.IMS.Persistence.Contexts;

namespace Inventra.IMS.Persistence.Repositories
{
    public class WriteRepository<TEntity, TKey, TDate>
        : Repository<TEntity, TKey, TDate>,
        IWriteRepository<TEntity, TKey, TDate>
        where TEntity : SoftDeletableEntity<TKey, TDate>, new()
        where TKey : struct, IEquatable<TKey>
        where TDate : struct
    {
        public WriteRepository(InventraDbContext inventraDbContext)
            : base(inventraDbContext){ }

        public virtual TEntity Add(TEntity entity)
        {
            return Table.Add(entity).Entity;
        }

        public virtual async Task<TEntity> AddAsync(
            TEntity entity,
            CancellationToken cancellationToken)
        {
            var entry = await Table.AddAsync(entity, cancellationToken);

            return entry.Entity;
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            Table.AddRange(entities);
        }

        public virtual Task AddRangeAsync(
            IEnumerable<TEntity> entities,
            CancellationToken cancellationToken)
        {
            return Table.AddRangeAsync(entities, cancellationToken);
        }

        public virtual TEntity Update(TEntity entity)
        {
            return Table.Update(entity).Entity;
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            Table.UpdateRange(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            Table.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            Table.RemoveRange(entities);
        }
    }
}
