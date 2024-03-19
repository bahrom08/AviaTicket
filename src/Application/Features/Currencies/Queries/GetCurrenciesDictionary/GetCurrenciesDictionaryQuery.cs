using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace Application.Features.Currencies.Queries.GetCurrenciesDictionary;

/// <summary>
/// Hi hello
/// </summary>
[SwaggerSchema(Required = new[] { "Description" })]
public class GetCurrenciesDictionaryQuery : IRequest<List<GetCurrenciesDictionaryViewModel>>
{
    /// <summary>
    /// Фраза для поиска по имени и iso code
    /// </summary>
    public string Search { get; set; }
}