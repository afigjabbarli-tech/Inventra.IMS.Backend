using Inventra.IMS.Application.Abstractions.Repositories;
using Inventra.IMS.Domain.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventra.IMS.Persistence.Concretes.Repositories
{
    public abstract class Repository<TEntity, TKey, TDate>
        : IRepository<TEntity, TKey, TDate>
        where TEntity : SoftDeletableEntity<TKey, TDate>, new()
        where TKey : struct, IEquatable<TKey>
        where TDate : struct
    {
        protected readonly DbContext Context;

        protected DbSet<TEntity> Table => Context.Set<TEntity>();

        protected Repository(DbContext dbContext)
        {
            Context = dbContext;
        }

        protected IQueryable<TEntity> Query(bool isTracking)
            => isTracking
            ? Table
            : Table.AsNoTracking();
    }
}
