using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Routes;

public class RoutesController : ApiBaseController
{
    [HttpGet]
    public async Task<IActionResult> Search()
    {
        return Ok();
    }
}
