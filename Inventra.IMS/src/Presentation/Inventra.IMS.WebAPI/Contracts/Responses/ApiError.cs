namespace Inventra.IMS.WebAPI.Contracts.Responses
{
    public sealed class ApiError
    {
        public string Code { get; init; } = string.Empty;

        public string Message { get; init; } = string.Empty;

        public string? Field { get; init; }

        public object? AttemptedValue { get; init; }

        public IDictionary<string, object?>? Details { get; init; }
    }
}
