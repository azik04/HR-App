using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace App.Infrastructure.BackgroundJob;

public class HostCheckBackgroundJob : BackgroundService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<HostCheckBackgroundJob> _logger;

    private const string Url = "https://localhost:5164";

    public HostCheckBackgroundJob(IHttpClientFactory httpClientFactory, ILogger<HostCheckBackgroundJob> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();

                client.Timeout = TimeSpan.FromSeconds(10);

                var response = await client.GetAsync(Url, stoppingToken);

                if (response.IsSuccessStatusCode)
                    _logger.LogInformation("Application is working.");

                else
                    _logger.LogWarning("Application is DOWN. Status code: {StatusCode}", response.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Application is DOWN.");

                // Send email here
            }

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}
