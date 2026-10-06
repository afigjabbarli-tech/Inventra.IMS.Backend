namespace Inventra.IMS.Domain.Common.Interfaces
{
    public interface IAuditable<TKey, TDate>
        where TKey : struct, IEquatable<TKey>
        where TDate : struct
    {
        TKey? CreatedBy { get; }
        TDate CreatedAt { get; }
        TKey? LastModifiedBy { get; }
        TDate? LastModifiedAt { get; }
    }
}
