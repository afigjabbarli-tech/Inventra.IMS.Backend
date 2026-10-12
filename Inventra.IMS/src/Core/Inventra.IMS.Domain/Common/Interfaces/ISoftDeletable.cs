namespace Inventra.IMS.Domain.Common.Interfaces
{
    public interface ISoftDeletable<TKey, TDate>
        where TKey : struct, IEquatable<TKey>
        where TDate : struct
    {
        bool IsDeleted { get; set; }
        TDate? DeletedAt { get; set; }
        TKey? DeletedBy { get; set; }
    }
}
