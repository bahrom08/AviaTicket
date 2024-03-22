using AutoMapper;
using Domain.Entities.Regions;

namespace Application.Features.Coutries.Queries.GetCoutriesDictionary;
public class GetCoutriesDictionaryMapper : Profile
{
    public GetCoutriesDictionaryMapper()
    {
        CreateMap<Country, GetCoutriesDictionaryViewModel>();
    }
}
