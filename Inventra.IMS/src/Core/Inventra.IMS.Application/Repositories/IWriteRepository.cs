using Inventra.IMS.Domain.Common.Entities;

namespace Inventra.IMS.Application.Repositories
{
    public interface IWriteRepository<TEntity, TKey, TDate>
        : IRepository<TEntity, TKey, TDate>
        where TEntity : SoftDeletableEntity<TKey, TDate>, new()
        where TKey : struct, IEquatable<TKey>
        where TDate : struct
    {

    }
}
