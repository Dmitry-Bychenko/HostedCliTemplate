using Microsoft.Extensions.Hosting;

namespace HostedCliTemplate;

/// <summary>
/// /Main Hosted Service, put your code here
/// </summary>
public sealed class MasterHostedService : BackgroundService {
   protected override Task ExecuteAsync(CancellationToken stoppingToken) {
    Console.WriteLine("Stop");

    return Task.CompletedTask;
  }
}

