using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace HostedCliTemplate.Core;

/// <summary>
/// Kernel
/// </summary>
public static class Kernel {
  #region Private Data

  private static readonly Lazy<Settings> LazySettings = new(() => {
    var options = Host
      .Services
      .GetService<IOptions<Settings>>();

    return options is null
      ? new Settings()
      : options.Value;
  });

  #endregion Private Data

  #region Public

  /// <summary>
  /// Host
  /// </summary>
  public static IHost Host => Builder.Host;

  /// <summary>
  /// Logger
  /// </summary>
  public static ILogger<T> Logger<T>() => Host
    .Services
    .GetService<ILogger<T>>() ?? NullLogger<T>.Instance;

  /// <summary>
  /// Settings
  /// </summary>
  public static Settings Settings => LazySettings.Value;

  /// <summary>
  /// Configuration
  /// </summary>
  public static IConfiguration Configuration => Host.Services.GetService<IConfiguration>()!;

  #endregion Public
}

