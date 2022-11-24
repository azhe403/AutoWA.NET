using Microsoft.Playwright;

namespace AutoWA.AppHost.Services;

public class WhatsAppService
{
	private const string WebWhatsappUrl = "https://web.whatsapp.com/";
	private readonly IHostEnvironment _env;
	private readonly ILogger<WhatsAppService> _logger;

	public WhatsAppService(
		IHostEnvironment env,
		ILogger<WhatsAppService> logger
	)
	{
		_env = env;
		_logger = logger;
	}

	private async Task<IBrowserContext> OpenWebPage(string sessionName)
	{
		var baseDir = Environment.CurrentDirectory + $"/Storage/Data/WhatsApp/{sessionName}";

		_logger.LogInformation("Userdata Dir: " + baseDir);

		var playwright = await Playwright.CreateAsync();

		var browser = await playwright
			.Chromium
			.LaunchPersistentContextAsync(
				userDataDir: $"{baseDir}/userdata/",
				options: new BrowserTypeLaunchPersistentContextOptions
				{
					Headless = false,
					SlowMo = 100
				}
			);

		return browser;
	}

	public async Task SendMessageText(SendMessageTextRequest request)
	{
		_logger.LogInformation("Opening web page..");
		var browserContext = await OpenWebPage(request.SessionName);
		var page = await browserContext.NewPageAsync();

		var directSend = WebWhatsappUrl + $"send?phone={request.PhoneNumber}&text={request.Message}&type=phone_number&app_absent=0";
		await page.GotoAsync(directSend);

		_logger.LogInformation("Sending message..");
		await page.ClickAsync("[data-testid=\"compose-btn-send\"]");

		await Task.Delay(1000);

		_logger.LogInformation("Closing web page..");
		await browserContext.CloseAsync();
	}
}