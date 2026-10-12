namespace Inventra.IMS.Domain.Common.Interfaces
{
    public interface IAuditable<TKey, TDate>
        where TKey : struct, IEquatable<TKey>
        where TDate : struct
    {
        TKey? CreatedBy { get; set; }
        TDate CreatedAt { get; set; }
        TKey? LastModifiedBy { get; set; }
        TDate? LastModifiedAt { get; set; }
    }
}
