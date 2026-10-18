using Inventra.IMS.Domain.Common.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventra.IMS.Domain.Common.Entities
{
    public abstract class AuditableEntity<TKey, TDate>
        : BaseEntity<TKey>, IAuditable<TKey, TDate>
        where TKey : struct, IEquatable<TKey>
        where TDate : struct
    {
        [Column(name: "created_by", Order = 1, TypeName = "uuid")]
        public TKey? CreatedBy { get; set; }

        [Column(name: "created_at", Order = 2, TypeName = "timestamp with time zone")]
        public TDate CreatedAt { get; set; }

        [Column(name: "last_modified_by", Order = 3, TypeName = "uuid")]
        public TKey? LastModifiedBy { get; set; }

        [Column(name: "last_modified_at", Order = 4, TypeName = "timestamp with time zone")]
        public TDate? LastModifiedAt { get; set; }
    }
}
