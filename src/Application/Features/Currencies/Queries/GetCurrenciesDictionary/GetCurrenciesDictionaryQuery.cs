using MediatR;

namespace Application.Features.Currencies.Queries.GetCurrenciesDictionary;

public class GetCurrenciesDictionaryQuery : IRequest<List<GetCurrenciesDictionaryViewModel>>
{
    public string Search { get; set; }
}