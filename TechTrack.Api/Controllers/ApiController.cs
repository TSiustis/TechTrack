using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TechTrack.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Produces("application/json")]
[Route("api/v1")]
public abstract class ApiController : ControllerBase
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}
