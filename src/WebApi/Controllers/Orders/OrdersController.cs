using WebApi.Common.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Orders.Commands.CreateOrder;

namespace WebApi.Controllers.Orders;

public class OrdersController : ApiBaseController
{
    /// <summary>
    /// Создание заказа
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
    {
        await Mediator.Send(command);

        return Ok(new SuccessResponse<string>("Ok"));
    }
}