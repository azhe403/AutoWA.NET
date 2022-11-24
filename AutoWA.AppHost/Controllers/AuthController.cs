using Microsoft.AspNetCore.Mvc;

namespace AutoWA.AppHost.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : AbstractController
{
	[HttpGet]
	public async Task<IActionResult> ScanQr()
	{
		await Mediator.Send(new SendMessageTextRequest());

		return Ok(true);
	}

}