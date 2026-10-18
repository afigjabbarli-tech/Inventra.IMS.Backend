namespace Inventra.IMS.WebAPI.Contracts.Responses
{
    public sealed class PaginationMetadata
    {
        public int PageNumber { get; init; }

        public int PageSize { get; init; }

        public long TotalCount { get; init; }

        public long TotalPages { get; init; }

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < TotalPages;

        public static PaginationMetadata Create(
            int pageNumber,
            int pageSize,
            long totalCount)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(pageNumber));

            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(nameof(pageSize));

            if (totalCount < 0)
                throw new ArgumentOutOfRangeException(nameof(totalCount));

            return new PaginationMetadata
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = totalCount == 0
                    ? 0
                    : (totalCount + pageSize - 1) / pageSize
            };
        }

    }
}
