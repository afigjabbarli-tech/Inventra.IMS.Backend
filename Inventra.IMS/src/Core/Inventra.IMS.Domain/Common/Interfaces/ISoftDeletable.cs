namespace Inventra.IMS.Domain.Common.Interfaces
{
    public interface ISoftDeletable<TKey, TDate>
        where TKey : struct, IEquatable<TKey>
        where TDate : struct
    {
        bool IsDeleted { get; }
        TDate? DeletedAt { get; }
        TKey? DeletedBy { get; }
    }
}
