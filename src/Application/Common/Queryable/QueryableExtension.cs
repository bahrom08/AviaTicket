using Microsoft.EntityFrameworkCore;

namespace Application.Common.Queryable;

public static class QueryableExtension
{
    public static async Task<PaginateResult<T>> PaginateResultAsync<T>(this IQueryable<T> query,
                                                                   int? page = 1,
                                                                   int? pageSize = 10,
                                                                   CancellationToken cancellationToken =
                                                                   default)
                                                                   where T : class
    {
        var currentPage = page == null || page == 0 ? 1 : page;
        pageSize = pageSize == null ? 10 : pageSize;
        pageSize = pageSize > 100 ? 100 : pageSize;

        var count = await query.CountAsync(cancellationToken);

        var pagination = new PaginateParam(count, currentPage, pageSize);

        var skip = pageSize * (currentPage - 1);

        var list = await query.Skip(skip.Value).Take(pageSize.Value).ToListAsync(cancellationToken);

        return new PaginateResult<T>() { Pagination = pagination, Items = list };
    }
}