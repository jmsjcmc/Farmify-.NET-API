namespace Farmify_API_v2.src.Application.Common.Pagination
{
    public record PagedResult<T>(
        IReadOnlyList<T> Items,
        int Page,
        int PageSize,
        int TotalCount);
}
