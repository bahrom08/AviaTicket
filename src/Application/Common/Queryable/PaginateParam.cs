namespace Application.Common.Queryable;

public class PaginateParam
{
    public PaginateParam(int totalItems, int? pageNumber, int? pageSize)
    {
        TotalItems = totalItems;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
    public int? PageNumber { get; }

    public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize!);

    public int? PageSize { get; }

    public int TotalItems { get; }

    public bool HasPreviousPage
    {
        get
        {
            return PageNumber > 1;
        }
    }

    public bool HasNextPage
    {
        get
        {
            return PageNumber < TotalPages;
        }
    }
}