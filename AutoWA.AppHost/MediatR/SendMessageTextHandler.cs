using FluentValidation;
using MediatR;

namespace AutoWA.AppHost.MediatR;

public class SendMessageTextHandler : IRequestHandler<SendMessageTextRequest, ApiResponse>
{
	private readonly ILogger<SendMessageTextHandler> _logger;
	private readonly WhatsAppService _whatsAppService;
	private readonly UserDbContext _userDbContext;

	public SendMessageTextHandler(
		ILogger<SendMessageTextHandler> logger,
		WhatsAppService whatsAppService,
		UserDbContext userDbContext
	)
	{
		_logger = logger;
		_whatsAppService = whatsAppService;
		_userDbContext = userDbContext;
	}

	public async Task<ApiResponse> Handle(
		SendMessageTextRequest request,
		CancellationToken cancellationToken
	)
	{
		ApiResponse apiResponse = new();

		var user = _userDbContext.Users.ToList();

		await _whatsAppService.SendMessageText(request);

		return apiResponse.Success();
	}
}

public class SendMessageTextRequest : IRequest<ApiResponse>
{
	public string Message { get; set; }
	public string PhoneNumber { get; set; }
	public string SessionName { get; set; }
}

public class SendMessageTextValidator : AbstractValidator<SendMessageTextRequest>
{
	public SendMessageTextValidator()
	{
		RuleFor(x => x.PhoneNumber).NotEmpty();
		RuleFor(x => x.Message).NotEmpty();
		RuleFor(x => x.SessionName).NotEmpty();
	}
}