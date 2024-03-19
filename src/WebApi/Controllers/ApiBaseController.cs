using Application.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

//[Authorize]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class ApiBaseController : ControllerBase
{
    private IMediator? _mediator;

    protected IMediator Mediator => _mediator
        ??= (IMediator?)HttpContext.RequestServices.GetService(typeof(IMediator))

    ?? throw new LogicException($"{GetType().Name} - Mediator not found");
}