using System;
using System.Threading;
using System.Threading.Tasks;
using SharpDX.XInput;

namespace CrossLaunch.Features.Gamepad;

public class GamepadInput
{
  private readonly Controller _controller = new(UserIndex.One);
  private readonly int _pollingInterval;
  private bool _isRunning;
  private GamepadButtonFlags _previousButtons; //For fixing holding the button down

  public GamepadInput(int pollingInterval = 50)
  {
    _pollingInterval = pollingInterval;
  }

  public event Action<string> ButtonPressed = null!;

  public void StartPollingAsync(CancellationToken ct)
  {
    _isRunning = true;

    Task.Run(
      async () =>
      {
        while (_isRunning && !ct.IsCancellationRequested)
        {
          UpdateState();
          await Task.Delay(_pollingInterval, ct);
        }

        StopPolling();
      },
      ct
    );
  }

  public void StopPolling()
  {
    _isRunning = false;
  }

  private void UpdateState()
  {
    if (!_controller.IsConnected)
      return;

    var state = _controller.GetState();
    var buttons = state.Gamepad.Buttons;

    if (buttons == _previousButtons)
      return;

    if (buttons.HasFlag(GamepadButtonFlags.DPadUp))
      ButtonPressed("Up");
    else if (buttons.HasFlag(GamepadButtonFlags.DPadDown))
      ButtonPressed("Down");
    else if (buttons.HasFlag(GamepadButtonFlags.DPadLeft))
      ButtonPressed("Left");
    else if (buttons.HasFlag(GamepadButtonFlags.DPadRight))
      ButtonPressed("Right");
    else if (buttons.HasFlag(GamepadButtonFlags.A) && !_previousButtons.HasFlag(GamepadButtonFlags.A))
      ButtonPressed("A");

    _previousButtons = buttons;
  }
}
