using System;
using System.Runtime.InteropServices;

namespace CrossLaunch.Features.Gamepad;

public class MacKeySimulator : IKeySimulator
{
  public void SimulateKeyPress(string key)
  {
    // This is a simplified version. You need to map your key codes to macOS virtual key codes.
    // For simplicity, we're using the "Return" key here.

    var keyCode = key switch
    {
      "Up" => 126,
      "Down" => 125,
      "Left" => 123,
      "Right" => 124,
      "A" => 36, // "Return" key code on macOS
      _ => throw new NotImplementedException($"Key {key} not supported."),
    };

    var eventSource = CGBEventSourceCreate();
    var keyDownEvent = CGEventCreateKeyboardEvent(eventSource, keyCode, true); // Key Down
    CGEventPost(1, keyDownEvent); // 1 represents key press event
  }

  [DllImport("ApplicationServices")]
  private static extern void CGEventPost(int eventType, IntPtr eventSource);

  [DllImport("ApplicationServices")]
  private static extern IntPtr CGEventCreateKeyboardEvent(IntPtr eventSource, int keycode, bool keyDown);

  [DllImport("ApplicationServices")]
  private static extern IntPtr CGBEventSourceCreate();
}
