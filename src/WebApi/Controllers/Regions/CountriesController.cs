using Microsoft.AspNetCore.Mvc;
using WebApi.Common.Responses;

namespace WebApi.Controllers.Regions;

public class CountriesController: ApiBaseController
{
    [HttpGet("dictionary")]
    public async Task<IActionResult> GetDictionary([FromQuery] string search)
    {
        return Ok();
    }
}
