using Microsoft.Extensions.Hosting;

namespace HostedCliTemplate;

/// <summary>
/// /Main Hosted Service, put your code here
/// </summary>
public sealed class MasterHostedService : IHostedService {
  public async Task StartAsync(CancellationToken cancellationToken) {
    Console.WriteLine("Start");
  }

  public async Task StopAsync(CancellationToken cancellationToken) {
    Console.WriteLine("Stop");
  }
}

