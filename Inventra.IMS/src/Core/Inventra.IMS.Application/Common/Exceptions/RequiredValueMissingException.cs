namespace Inventra.IMS.Application.Common.Exceptions
{
    public sealed class RequiredValueMissingException : Exception
    {
        public string MemberName { get; }
        public RequiredValueMissingException(string memberName)
            : base($"Required value '{memberName}' was not provided!")
        {
            MemberName = memberName;
        }
    }
}
