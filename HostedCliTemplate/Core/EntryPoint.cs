using HostedCliTemplate.Consoles;

namespace HostedCliTemplate.Core;

internal static class EntryPoint {
  private static async Task Main() {
    if (HelpScreen.ShowHelpScreen())
      return;

    await Builder.Host.StartAsync();
  }
}

