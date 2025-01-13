using System.Diagnostics.CodeAnalysis;
using WindowsInput;

namespace CrossLaunch.Features.Gamepad;

[SuppressMessage("Interoperability", "CA1416:Plattformkompatibilität überprüfen")]
public class WindowsKeySimulator : IKeySimulator
{
  private readonly InputSimulator _inputSimulator;

  public WindowsKeySimulator()
  {
    _inputSimulator = new InputSimulator();
  }

  public void SimulateKeyPress(string key)
  {
    switch (key)
    {
      case "Up":
        _inputSimulator.Keyboard.KeyPress(VirtualKeyCode.UP);
        break;
      case "Down":
        _inputSimulator.Keyboard.KeyPress(VirtualKeyCode.DOWN);
        break;
      case "Left":
        _inputSimulator.Keyboard.KeyPress(VirtualKeyCode.LEFT);
        break;
      case "Right":
        _inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RIGHT);
        break;
      case "A":
        _inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        break;
    }
  }
}
