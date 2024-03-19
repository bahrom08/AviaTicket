namespace Application.Common.Queryable;

public class PaginateResult<T>
{
    public List<T> Items { get; set; }
    public PaginateParam Pagination { get; set; }
}