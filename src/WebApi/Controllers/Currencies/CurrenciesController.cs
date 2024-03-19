using Application.Features.Currencies.Queries.GetCurrenciesDictionary;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebApi.Common.Responses;

namespace WebApi.Controllers.Currencies;

public class CurrenciesController : ApiBaseController
{

    [HttpGet("dictionary")]
    [SwaggerOperation(
        Summary = "Список валют",
        Description = "API возвращает список валют",
        Tags = new[] { "Валюта", "Currency" }
    )]
    public async Task<IActionResult> GetDictionary([FromQuery] GetCurrenciesDictionaryQuery request)
    {
        var data = await Mediator.Send(request);

        return Ok(new SuccessResponse<List<GetCurrenciesDictionaryViewModel>>(data));
    }
}