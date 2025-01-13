using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Silk.NET.Input;

namespace CrossLaunch.Features.Gamepad;

public class GamepadInput
{
  private readonly IInputContext _inputContext;
  private readonly int _pollingInterval;
  private bool _isRunning;
  private Button? _previousButton; // For fixing holding the button down

  public GamepadInput(IInputContext inputContext, int pollingInterval = 50)
  {
    _inputContext = inputContext;
    _pollingInterval = pollingInterval;
  }

  public event Action<string>? ButtonPressed;

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
    var controller = _inputContext.Gamepads.Count > 0 ? _inputContext.Gamepads[0] : null;

    if (controller is not { IsConnected: true })
      return;

    // Clear the previous button state if no button is pressed
    if (!controller.Buttons.Any(b => b.Pressed))
    {
      _previousButton = null;
      return;
    }

    foreach (var button in controller.Buttons)
    {
      if (!button.Pressed || (_previousButton is not null && _previousButton.Value.Name == button.Name))
        continue;

      PublishButtonPressedEvent(button);

      _previousButton = button;
    }
  }

  private void PublishButtonPressedEvent(Button button)
  {
    switch (button.Name)
    {
      case ButtonName.DPadUp:
        ButtonPressed?.Invoke("Up");
        break;
      case ButtonName.DPadDown:
        ButtonPressed?.Invoke("Down");
        break;
      case ButtonName.DPadLeft:
        ButtonPressed?.Invoke("Left");
        break;
      case ButtonName.DPadRight:
        ButtonPressed?.Invoke("Right");
        break;
      case ButtonName.A:
        ButtonPressed?.Invoke("A");
        break;
    }
  }
}
