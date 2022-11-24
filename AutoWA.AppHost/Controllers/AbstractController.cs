using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutoWA.AppHost.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AbstractController : ControllerBase
{
	internal IMediator Mediator => HttpContext.RequestServices.GetRequiredService<IMediator>();
}