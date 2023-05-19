using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HostedCliTemplate.Consoles;

public static class HelpScreen {
  
  private static string Header() {
    var asm = Assembly.GetEntryAssembly();

    string product = asm.GetCustomAttribute<AssemblyProductAttribute>()?.Product?.Trim() ?? asm?.GetName()?.Name ?? "***";
    string version = asm.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version?.Trim() ?? "1.0.0.0";
    string copyright = asm.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright?.Trim() ?? "";

    return string.Join(Environment.NewLine,
      $"{product} version {version} {copyright}"
    ); 
  }

  private static bool IsHelpScreen() {
    var args = Environment
      .GetCommandLineArgs()
      .Skip(1)
      .ToArray();

    if (args.Length <= 0)
      return true;

    var helps = new HashSet<string>(StringComparer.OrdinalIgnoreCase) {
      "?",
      "help",
      "h",
      "hlp"
    };

    return args
      .Select(item => item.TrimStart(' ', '\t', '-', '/', '\\'))
      .Any(helps.Contains);
  }

  public static string HelpText() {
    return string.Join(Environment.NewLine,
      Header()
    ); 
  }

  public static bool ShowHelpScreen() {
    if (!IsHelpScreen())
      return false;

    Console.WriteLine(Header());

    return true;
  }
}

