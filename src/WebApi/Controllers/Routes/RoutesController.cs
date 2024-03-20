using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Routes;

public class RoutesController : ApiBaseController
{
    [HttpPost("search")]
    public async Task<IActionResult> Search()
    {
        return Ok();
    }
}