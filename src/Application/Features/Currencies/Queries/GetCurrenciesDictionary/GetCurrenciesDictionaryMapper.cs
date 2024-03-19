using AutoMapper;
using Domain.Entities.Currencies;

namespace Application.Features.Currencies.Queries.GetCurrenciesDictionary;

public class GetCurrenciesDictionaryMapper : Profile
{
    public GetCurrenciesDictionaryMapper()
    {
        CreateMap<Currency, GetCurrenciesDictionaryViewModel>();
    }
}