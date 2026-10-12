using Inventra.IMS.Domain.Common.Interfaces;

namespace Inventra.IMS.Domain.Common.Entities
{
    public abstract class SoftDeletableEntity<TKey, TDate>
        : AuditableEntity<TKey, TDate>, ISoftDeletable<TKey, TDate>
        where TKey : struct, IEquatable<TKey>
        where TDate : struct
    {
        public bool IsDeleted { get; set; }

        public TDate? DeletedAt { get; set; }

        public TKey? DeletedBy { get; set; }
    }
}
