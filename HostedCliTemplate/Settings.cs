using System.ComponentModel;

namespace HostedCliTemplate; 

/// <summary>
/// Class to contains Application Settings
/// </summary>
public sealed class Settings {
  #region Public

  /// <summary>
  /// Login
  /// </summary>
  [Description("User login")]
  public string Login { get; init; } = "";

  /// <summary>
  /// Password
  /// </summary>
  [Description("User password")]
  public string Password { get; init; } = "";

  /// <summary>
  /// Bearer
  /// </summary>
  [Description("Bearer")]
  public string Bearer { get; init; } = "";

  #endregion Public
}

