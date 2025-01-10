using System;
using System.Threading;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using CrossLaunch.Features.Gamepad;

namespace CrossLaunch;

internal class Program
{
  // Initialization code. Don't use any Avalonia, third-party APIs or any
  // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
  // yet and stuff might break.
  [STAThread]
  public static void Main(string[] args)
  {
    var cts = new CancellationTokenSource();
    GamepadHandler.HandleGamepadInput(cts.Token);

    BuildAvaloniaApp()
      .StartWithClassicDesktopLifetime(
        args,
        lifetime =>
        {
          lifetime.ShutdownRequested += OnShutdownRequested;
          return;

          void OnShutdownRequested(object? sender, ShutdownRequestedEventArgs e)
          {
            cts.Cancel();
          }
        }
      );
  }

  // Avalonia configuration, don't remove; also used by visual designer.
  public static AppBuilder BuildAvaloniaApp()
  {
    return AppBuilder.Configure<App>().UsePlatformDetect().WithInterFont().LogToTrace();
  }
}
