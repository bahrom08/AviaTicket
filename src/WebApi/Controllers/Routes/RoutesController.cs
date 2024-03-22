using Application.Features.Routes.Queries.GetRoutesSearch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.Common.Responses;

namespace WebApi.Controllers.Routes;

public class RoutesController : ApiBaseController
{
    private readonly ILogger<RoutesController> _logger;

    public RoutesController(ILogger<RoutesController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// API для поиска маршрутов
    /// </summary>
    /// <param name="request">Параметры запроса</param>
    /// <returns></returns>
    [HttpPost("search")]
    public async Task<IActionResult> Search([FromBody] GetRoutesSearchQuery request)
    {
        _logger.LogInformation("{className} - {method} - {message}", GetType().Name, "Search", JsonConvert.SerializeObject(request));

        var data = await Mediator.Send(request);

        return Ok(new SuccessResponse<List<GetRoutesSearchViewModel>>(data));
    }
}