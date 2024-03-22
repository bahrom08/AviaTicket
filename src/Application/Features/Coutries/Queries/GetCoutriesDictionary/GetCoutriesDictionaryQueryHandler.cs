using Application.Common.Extensions;
using Application.Common.Interfaces;
using Application.Common.Queryable;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities.Regions;
using MediatR;

namespace Application.Features.Coutries.Queries.GetCoutriesDictionary;

public class GetCoutriesDictionaryQueryHandler : BaseSetting, IRequestHandler<GetCoutriesDictionaryQuery, PaginateResult<GetCoutriesDictionaryViewModel>>
{
    public GetCoutriesDictionaryQueryHandler(IMapper mapper, IApplicationDbContext context) : base(mapper, context)
    {
    }

    public async Task<PaginateResult<GetCoutriesDictionaryViewModel>> Handle(GetCoutriesDictionaryQuery request, CancellationToken cancellationToken)
    {
        var query = _dbContext.Countries
            .OrderBy(x => x.Name)
            .AsQueryable();

        query = ApplyFilters(query, request);


        return await query.ProjectTo<GetCoutriesDictionaryViewModel>(_mapper.ConfigurationProvider)
                          .PaginateResultAsync(cancellationToken: cancellationToken);
    }

    private static IQueryable<Country> ApplyFilters(IQueryable<Country> query, GetCoutriesDictionaryQuery request)
    {
        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            query = query.Where(x => x.Name.ToLower().Contains(request.Search.ToLower()) ||
                                     x.Code.ToLower().Contains(request.Search.ToLower()));
        }

        return query;
    }
}