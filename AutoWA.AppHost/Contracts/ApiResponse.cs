using System.Diagnostics;

namespace AutoWA.AppHost.Contracts;

public class ApiResponse
{
	private readonly Stopwatch _stopwatch;

	public bool IsSuccess { get; set; }
	public TimeSpan Duration { get; set; }

	public ApiResponse()
	{
		_stopwatch = Stopwatch.StartNew();

	}

	public ApiResponse Success()
	{
		IsSuccess = true;
		Duration = _stopwatch.Elapsed;

		return this;
	}
}