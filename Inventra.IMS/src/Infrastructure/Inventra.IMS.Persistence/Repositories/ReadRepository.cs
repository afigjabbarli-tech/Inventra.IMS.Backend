using Inventra.IMS.Application.Repositories;
using Inventra.IMS.Domain.Common.Entities;
using Inventra.IMS.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Inventra.IMS.Persistence.Repositories
{
    public class ReadRepository<TEntity, TKey, TDate>
        : Repository<TEntity, TKey, TDate>,
        IReadRepository<TEntity, TKey, TDate>
        where TEntity : SoftDeletableEntity<TKey, TDate>, new()
        where TKey : struct, IEquatable<TKey>
        where TDate : struct
    {
        public ReadRepository(InventraDbContext inventraDbContext)
            : base(inventraDbContext) { }

        public virtual TEntity? GetByUid(TKey uid, bool isTracking)
        {
            return Query(isTracking)
                .SingleOrDefault(e => e.Uid.Equals(uid));
        }

        public virtual async Task<TEntity?> GetByUidAsync(TKey uid,
            bool isTracking, CancellationToken cancellationToken)
        {
            return await Query(isTracking)
                .SingleOrDefaultAsync(e => e.Uid.Equals(uid), cancellationToken);
        }

        public virtual IQueryable<TEntity> GetAllAsQueryable(bool isTracking)
        {
            return Query(isTracking);
        }

        public virtual List<TEntity> GetAllAsList(bool isTracking)
        {
            return Query(isTracking).ToList();
        }

        public virtual async Task<List<TEntity>> GetAllAsListAsync(
            bool isTracking, CancellationToken cancellationToken)
        {
            return await Query(isTracking).ToListAsync(cancellationToken);
        }

        public virtual TEntity? GetByCondition(Expression<Func<TEntity, bool>> predicate,
            bool isTracking)
        {
            return Query(isTracking)
                .FirstOrDefault(predicate);
        }

        public virtual async Task<TEntity?> GetByConditionAsync(Expression<Func<TEntity, bool>> predicate,
            bool isTracking, CancellationToken cancellationToken)
        {
            return await Query(isTracking)
                .FirstOrDefaultAsync(predicate, cancellationToken); 
        }

        public virtual IQueryable<TEntity> GetWhereAsQueryable(
            Expression<Func<TEntity, bool>> predicate,
            bool isTracking)
        {
            return Query(isTracking).Where(predicate);
        }

        public virtual List<TEntity> GetWhereAsList(
            Expression<Func<TEntity, bool>> predicate,
            bool isTracking)
        {
            return Query(isTracking).Where(predicate).ToList();
        }

        public virtual async Task<List<TEntity>> GetWhereAsListAsync(
            Expression<Func<TEntity, bool>> predicate,
            bool isTracking, CancellationToken cancellationToken)
        {
            return await Query(isTracking).Where(predicate).ToListAsync(cancellationToken);
        }

        public virtual int Count()
        {
            return Query(false).Count();
        }

        public virtual async Task<int> CountAsync(CancellationToken cancellationToken)
        {
            return await Query(false).CountAsync(cancellationToken);
        }

        public virtual int CountWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return Query(false).Count(predicate);
        }

        public virtual async Task<int> CountWhereAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken)
        {
            return await Query(false).CountAsync(predicate, cancellationToken);
        }

        public virtual bool Exist(Expression<Func<TEntity, bool>> predicate)
        {
            return Query(false).Any(predicate);
        }

        public virtual async Task<bool> ExistAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken)
        {
            return await Query(false).AnyAsync(predicate, cancellationToken);
        }
    }
}
