namespace Inventra.IMS.Domain.Common.Entities
{
    public abstract class BaseEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public TKey Uid { get; private set; }
    }
}
