using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventra.IMS.Domain.Common.Entities
{
    public abstract class BaseEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        [Key]
        [Column(name: "uid", Order = 0, TypeName = "uuid")]
        public TKey Uid { get; private set; }
    }
}
