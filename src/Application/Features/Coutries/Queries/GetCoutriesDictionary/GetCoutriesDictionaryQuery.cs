using Application.Common.Queryable;
using MediatR;

namespace Application.Features.Coutries.Queries.GetCoutriesDictionary;

public class GetCoutriesDictionaryQuery : IRequest<PaginateResult<GetCoutriesDictionaryViewModel>>
{
    /// <summary>
    /// Параметр поиска по содержанию имени и кода страны
    /// </summary>
    public string Search { get; set; }
}