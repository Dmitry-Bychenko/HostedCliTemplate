using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HostedCliTemplate.Core;

internal static class Builder {
  #region Private Data

  private static readonly Lazy<IHost> LazyHostBuilder = new(() => {
    string BasePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
    string Prefix = Assembly.GetEntryAssembly().GetName().Name;

    return new HostBuilder()
      .ConfigureHostConfiguration(configHost => {
        configHost.SetBasePath(BasePath);
        configHost.AddJsonFile("HostSettings.json", optional: true);
        configHost.AddEnvironmentVariables(prefix: Prefix);
        configHost.AddCommandLine(Environment.GetCommandLineArgs());
      })
      .ConfigureAppConfiguration((hostContext, configApp) => {
        configApp.SetBasePath(BasePath);
        configApp.AddJsonFile("AppSettings.json", optional: true);
        configApp.AddJsonFile(
        $"AppSettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true);
        configApp.AddEnvironmentVariables(prefix: Prefix);
        configApp.AddCommandLine(Environment.GetCommandLineArgs());
      })
      .ConfigureServices((hostContext, services) => {
        services.AddLogging();

        services.Configure<Settings>(hostContext.Configuration.GetSection("Application"));
        
        StartUp.Configure(services);
                
        services.AddHostedService<MasterHostedService>();
      })
      .ConfigureLogging((hostContext, configLogging) => {
        configLogging.AddConsole();
      })
      .UseConsoleLifetime()
      .Build();
  });

  #endregion Private Data

  #region Public

  /// <summary>
  /// Host
  /// </summary>
  public static IHost Host => LazyHostBuilder.Value;

  #endregion Public
}

