using Application.Features.Coutries.Queries.GetCoutriesDictionary;
using Application.Features.Currencies.Queries.GetCurrenciesDictionary;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebApi.Common.Responses;

namespace WebApi.Controllers.Currencies;

public class CurrenciesController : ApiBaseController
{

    /// <summary>
    /// API возвращает список валют
    /// </summary>
    /// <param name="request">Параметры запроса</param>
    /// <returns></returns>
    [HttpGet("dictionary")]
    [ProducesResponseType(typeof(SuccessResponse<List<GetCurrenciesDictionaryViewModel>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDictionary([FromQuery] GetCurrenciesDictionaryQuery request)
    {
        var data = await Mediator.Send(request);

        return Ok(new SuccessResponse<List<GetCurrenciesDictionaryViewModel>>(data));
    }
}