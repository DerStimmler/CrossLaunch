using System;
using System.Diagnostics;

namespace CrossLaunch.Features.Gamepad;

public class LinuxKeySimulator : IKeySimulator
{
  public void SimulateKeyPress(string key)
  {
    var keyPressCommand = key switch
    {
      "Up" => "xdotool key Up",
      "Down" => "xdotool key Down",
      "Left" => "xdotool key Left",
      "Right" => "xdotool key Right",
      "A" => "xdotool key Return",
      _ => throw new NotImplementedException($"Key {key} not supported."),
    };

    var process = new Process
    {
      StartInfo = new ProcessStartInfo
      {
        FileName = "bash",
        Arguments = $"-c \"{keyPressCommand}\"",
        RedirectStandardOutput = true,
        UseShellExecute = false,
        CreateNoWindow = true,
      },
    };

    process.Start();
    process.WaitForExit();
  }
}
