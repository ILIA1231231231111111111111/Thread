using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Thread.API.Common;

[Route("api/v1")]
public class ApiController : ControllerBase
{
    private IMediator? _mediator;
    
    protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    
    protected Guid UserId => GetCurrentUserId();

    private Guid GetCurrentUserId()
    {
        var value = HttpContext.User?.FindFirst("IdentityId")?.Value ?? string.Empty;
        return Guid.TryParse(value, out Guid id) is true ? id : Guid.Empty;
    }
}