using Inventra.IMS.Domain.Common.Entities;
using System.Linq.Expressions;

namespace Inventra.IMS.Application.Repositories
{
    public interface IReadRepository<TEntity, TKey, TDate>
        : IRepository<TEntity, TKey, TDate>
        where TEntity : SoftDeletableEntity<TKey, TDate>, new()
        where TKey : struct, IEquatable<TKey>
        where TDate : struct
    {
        TEntity? GetByUid(
            TKey uid,
            bool isTracking);

        Task<TEntity?> GetByUidAsync(
            TKey uid,
            bool isTracking,
            CancellationToken cancellationToken);

        IQueryable<TEntity> GetAllAsQueryable(
            bool isTracking);

        List<TEntity> GetAllAsList(
            bool isTracking);

        Task<List<TEntity>> GetAllAsListAsync(
            bool isTracking,
            CancellationToken cancellationToken);

        TEntity? GetByCondition(
            Expression<Func<TEntity, bool>> predicate,
            bool isTracking);

        Task<TEntity?> GetByConditionAsync(
            Expression<Func<TEntity, bool>> predicate,
            bool isTracking,
            CancellationToken cancellationToken);

        IQueryable<TEntity> GetWhereAsQueryable(
            Expression<Func<TEntity, bool>> predicate,
            bool isTracking);

        List<TEntity> GetWhereAsList(
            Expression<Func<TEntity, bool>> predicate,
            bool isTracking);

        Task<List<TEntity>> GetWhereAsListAsync(
            Expression<Func<TEntity, bool>> predicate,
            bool isTracking,
            CancellationToken cancellationToken);

        int Count();

        Task<int> CountAsync(
            CancellationToken cancellationToken);

        int CountWhere(
            Expression<Func<TEntity, bool>> predicate);

        Task<int> CountWhereAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken);

        bool Exist(
            Expression<Func<TEntity, bool>> predicate);

        Task<bool> ExistAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken);
    }
}
