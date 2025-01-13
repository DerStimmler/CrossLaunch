using System.Runtime.InteropServices;

namespace CrossLaunch.Features.Gamepad;

public static class KeySimulatorFactory
{
  public static IKeySimulator? CreateSimulator()
  {
    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
      return new WindowsKeySimulator();
    if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
      return new LinuxKeySimulator();
    if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
      return new MacKeySimulator();

    return null;
  }
}
