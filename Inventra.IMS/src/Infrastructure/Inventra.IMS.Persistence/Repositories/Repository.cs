using Inventra.IMS.Application.Repositories;
using Inventra.IMS.Domain.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventra.IMS.Persistence.Repositories
{
    public abstract class Repository<TEntity, TKey, TDate>
        : IRepository<TEntity, TKey, TDate>
        where TEntity : SoftDeletableEntity<TKey, TDate>, new()
        where TKey : struct, IEquatable<TKey>
        where TDate : struct
    {
        protected readonly DbContext Context;

        protected DbSet<TEntity> Table => Context.Set<TEntity>();

        protected Repository(DbContext context)
        {
            Context = context;
        }

        protected IQueryable<TEntity> Query(bool isTracking)
            => isTracking
            ? Table
            : Table.AsNoTracking<TEntity>();
    }
}
