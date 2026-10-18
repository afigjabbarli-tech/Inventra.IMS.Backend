using Inventra.IMS.WebAPI.Contracts.Responses;
using System.Text.Json.Serialization;

namespace Inventra.IMS.WebAPI.Common.Responses
{
    public sealed class ApiResponse<T>
    {
        public bool Success { get; init; }
        public string Message { get; init; } = string.Empty;
        public string? Code { get; init; }
        public T? Data { get; init; }
        public IReadOnlyCollection<ApiError> Errors { get; init; }
        = Array.Empty<ApiError>();
        public PaginationMetadata? Pagination { get; init; }
        public IDictionary<string, object?>? Metadata { get; init; }
        public string? TraceId { get; init; }
        public DateTimeOffset Timestamp { get; init; }
        = DateTimeOffset.UtcNow;
        [JsonIgnore]
        public bool IsSuccess => Success;

        public static ApiResponse<T> Succeed(
            T? data,
            string message = "Operation completed successfully.",
            string? code = null,
            PaginationMetadata? pagination = null,
            IDictionary<string, object?>? metadata = null,
            string? traceId = null)
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Code = code,
                Data = data,
                Errors = Array.Empty<ApiError>(),
                Pagination = pagination,
                Metadata = metadata,
                TraceId = traceId
            };
        }

        public static ApiResponse<T> Fail(
            string message,
            IReadOnlyCollection<ApiError>? errors = null,
            string? code = null,
            string? traceId = null,
            IDictionary<string, object?>? metadata = null)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Code = code,
                Data = default,
                Errors = errors ?? Array.Empty<ApiError>(),
                Pagination = null,
                Metadata = metadata,
                TraceId = traceId
            };
        }
    }
}
