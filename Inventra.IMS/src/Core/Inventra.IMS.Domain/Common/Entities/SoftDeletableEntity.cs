using Inventra.IMS.Domain.Common.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventra.IMS.Domain.Common.Entities
{
    public abstract class SoftDeletableEntity<TKey, TDate>
        : AuditableEntity<TKey, TDate>, ISoftDeletable<TKey, TDate>
        where TKey : struct, IEquatable<TKey>
        where TDate : struct
    {
        [Column(name: "is_deleted", Order = 5, TypeName = "boolean")]
        public bool IsDeleted { get; set; }

        [Column(name: "deleted_at", Order = 6, TypeName = "timestamp with time zone")]
        public TDate? DeletedAt { get; set; }

        [Column(name: "deleted_by", Order = 7, TypeName = "uuid")]
        public TKey? DeletedBy { get; set; }
    }
}
