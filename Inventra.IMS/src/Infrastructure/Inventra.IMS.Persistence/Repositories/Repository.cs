using Inventra.IMS.Application.Repositories;
using Inventra.IMS.Domain.Common.Entities;

namespace Inventra.IMS.Persistence.Repositories
{
    public abstract class Repository<TEntity, TKey, TDate>
        : IRepository<TEntity, TKey, TDate>
        where TEntity : SoftDeletableEntity<TKey, TDate>, new()
        where TKey : struct, IEquatable<TKey>
        where TDate : struct
    {

    }
}
