using System.Threading;
using WindowsInput;
using WindowsInput.Native;

namespace CrossLaunch.Features.Gamepad;

public class GamepadHandler
{
  private static readonly KeyboardSimulator KeyboardSimulator = new(new InputSimulator());

  public static void HandleGamepadInput(CancellationToken ct)
  {
    var gamepadInput = new GamepadInput();

    gamepadInput.ButtonPressed += direction =>
    {
      SimulateArrowKeyPress(direction);
    };

    gamepadInput.StartPollingAsync(ct);
  }

  private static void SimulateArrowKeyPress(string direction)
  {
    switch (direction)
    {
      case "Up":
        KeyboardSimulator.KeyPress(VirtualKeyCode.UP);
        break;
      case "Down":
        KeyboardSimulator.KeyPress(VirtualKeyCode.DOWN);
        break;
      case "Left":
        KeyboardSimulator.KeyPress(VirtualKeyCode.LEFT);
        break;
      case "Right":
        KeyboardSimulator.KeyPress(VirtualKeyCode.RIGHT);
        break;
      case "A":
        KeyboardSimulator.KeyPress(VirtualKeyCode.RETURN);
        break;
    }
  }
}
