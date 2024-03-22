using Application.Features.Coutries.Queries.GetCoutriesDictionary;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common.Responses;

namespace WebApi.Controllers.Regions;

public class CountriesController: ApiBaseController
{
    /// <summary>
    /// API для списка стран и гражданств
    /// </summary>
    /// <param name="request">Параметры запроса</param>
    /// <returns></returns>
    [HttpGet("dictionary")]
    [ProducesResponseType(typeof(SuccessResponse<List<GetCoutriesDictionaryViewModel>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDictionary([FromQuery] GetCoutriesDictionaryQuery request)
    {
        var data = await Mediator.Send(request);

        return Ok(new SuccessResponse<List<GetCoutriesDictionaryViewModel>>(data.Items, meta: new Meta
        {
            Pagination = data.Pagination
        }));
    }
}
