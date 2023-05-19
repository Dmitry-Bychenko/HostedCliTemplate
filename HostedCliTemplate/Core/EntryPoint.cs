namespace HostedCliTemplate.Core;

internal static class EntryPoint {
  private static async Task Main() {
    await Builder.Host.StartAsync();
  }
}

