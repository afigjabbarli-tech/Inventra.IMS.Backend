using Inventra.IMS.Domain.Common.Interfaces;

namespace Inventra.IMS.Domain.Common.Entities
{
    public abstract class AuditableEntity<TKey, TDate>
        : BaseEntity<TKey>, IAuditable<TKey, TDate>
        where TKey : struct, IEquatable<TKey>
        where TDate : struct
    {
        public TKey? CreatedBy { get; private set; }

        public TDate CreatedAt { get; private set; }

        public TKey? LastModifiedBy { get; private set; }

        public TDate? LastModifiedAt { get; private set; }
    }
}
