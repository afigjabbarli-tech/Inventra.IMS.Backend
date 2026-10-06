using Inventra.IMS.Application.Repositories;
using Inventra.IMS.Domain.Common.Entities;

namespace Inventra.IMS.Persistence.Repositories
{
    public class ReadRepository<TEntity, TKey, TDate>
        : Repository<TEntity, TKey, TDate>,
        IReadRepository<TEntity, TKey, TDate>
        where TEntity : SoftDeletableEntity<TKey, TDate>, new()
        where TKey : struct, IEquatable<TKey>
        where TDate : struct
    {

    }
}
