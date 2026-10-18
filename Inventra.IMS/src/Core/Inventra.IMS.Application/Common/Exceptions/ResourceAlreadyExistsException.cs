namespace Inventra.IMS.Application.Common.Exceptions
{
    public sealed class ResourceAlreadyExistsException : Exception
    {
        public string ResourceName { get; }
        public string MemberName { get; }
        public object? MemberValue { get; }

        public ResourceAlreadyExistsException(
            string resourceName,
            string memberName,
            object? memberValue)
            : base(
                $"{resourceName} cannot be created because a record with {memberName} = '{memberValue}' already exists!")
        {
            ResourceName = resourceName;
            MemberName = memberName;
            MemberValue = memberValue;
        }
    }
}