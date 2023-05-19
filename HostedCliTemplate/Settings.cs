namespace HostedCliTemplate; 

/// <summary>
/// Class to contains Application Settings
/// </summary>
public sealed class Settings {
  #region Public

  /// <summary>
  /// Login
  /// </summary>
  public string Login { get; init; } = "";

  /// <summary>
  /// Password
  /// </summary>
  public string Password { get; init; } = "";

  /// <summary>
  /// Bearer
  /// </summary>
  public string Bearer { get; init; } = "";

  #endregion Public
}

