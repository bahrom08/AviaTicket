using Application.Features.Currencies.Queries.GetCurrenciesDictionary;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebApi.Common.Responses;

namespace WebApi.Controllers.Currencies;

public class CurrenciesController : ApiBaseController
{

    /// <summary>
    /// HI
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet("dictionary")]
    [SwaggerOperation(
        Summary = "Список валют",
        Description = "API возвращает список валют"
    )]
    public async Task<IActionResult> GetDictionary([FromQuery][SwaggerSchema(Required = new[] { "Description" })] GetCurrenciesDictionaryQuery request)
    {
        var data = await Mediator.Send(request);

        return Ok(new SuccessResponse<List<GetCurrenciesDictionaryViewModel>>(data));
    }
}