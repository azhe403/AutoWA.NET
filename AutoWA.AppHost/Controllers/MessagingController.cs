using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace AutoWA.AppHost.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagingController : AbstractController
{
	[HttpPost("sendMessageText")]
	[ProducesResponseType((int) HttpStatusCode.OK, Type = typeof(ApiResponse))]
	public async Task<IActionResult> SendMessageText([FromBody] SendMessageTextRequest request)
	{
		var response = await Mediator.Send(request);

		return Ok(response);
	}
}