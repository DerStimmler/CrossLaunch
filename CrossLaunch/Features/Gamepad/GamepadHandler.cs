using System.Threading;
using Silk.NET.Input;

namespace CrossLaunch.Features.Gamepad;

public class GamepadHandler
{
  private static IKeySimulator? _keySimulator;

  public static void HandleGamepadInput(IInputContext inputContext, CancellationToken ct)
  {
    _keySimulator = KeySimulatorFactory.CreateSimulator();

    if (_keySimulator is null)
      return;

    var gamepadInput = new GamepadInput(inputContext);

    gamepadInput.ButtonPressed += key =>
    {
      _keySimulator.SimulateKeyPress(key);
    };

    gamepadInput.StartPollingAsync(ct);
  }
}
