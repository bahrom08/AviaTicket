using MediatR;
using AutoMapper;
using Domain.Entities.Currencies;
using Application.Common.Extensions;
using Application.Common.Interfaces;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Currencies.Queries.GetCurrenciesDictionary;

public class GetCurrenciesDictionaryQueryHandler : BaseSetting, IRequestHandler<GetCurrenciesDictionaryQuery, List<GetCurrenciesDictionaryViewModel>>
{
    public GetCurrenciesDictionaryQueryHandler(IMapper mapper, IApplicationDbContext context) : base(mapper, context)
    {
    }

    public async Task<List<GetCurrenciesDictionaryViewModel>> Handle(GetCurrenciesDictionaryQuery request, CancellationToken cancellationToken)
    {
        var query = _dbContext.Currencies
            .OrderBy(x => x.Name)
            .AsQueryable();

        query = ApplyFilters(query, request);


        return await query
            .ProjectTo<GetCurrenciesDictionaryViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    private static IQueryable<Currency> ApplyFilters(IQueryable<Currency> query, GetCurrenciesDictionaryQuery request)
    {
        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            query = query.Where(x => x.Name.ToLower().Contains(request.Search.ToLower()) ||
                                     x.IsoCode.ToLower().Contains(request.Search.ToLower()));
        }

        return query;
    }
}
