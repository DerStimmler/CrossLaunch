using System.Reflection;
using Avalonia;
using Avalonia.Controls;
using CrossLaunch.Features.GitHub;

namespace CrossLaunch;

public partial class MainWindow : Window
{
  public static readonly StyledProperty<bool> IsUpdateAvailableProperty = AvaloniaProperty.Register<MainWindow, bool>(
    nameof(IsUpdateAvailable)
  );

  public static readonly StyledProperty<string> CurrentVersionProperty = AvaloniaProperty.Register<MainWindow, string>(
    nameof(CurrentVersion)
  );

  public static readonly StyledProperty<string> LatestVersionProperty = AvaloniaProperty.Register<MainWindow, string>(
    nameof(LatestVersion)
  );

  private readonly GitHubService _gitHubService;

  public MainWindow()
  {
    InitializeComponent();
    DataContext = this;

    _gitHubService = new GitHubService();

    Load();
  }

  public bool IsUpdateAvailable
  {
    get => GetValue(IsUpdateAvailableProperty);
    set => SetValue(IsUpdateAvailableProperty, value);
  }

  public string CurrentVersion
  {
    get => GetValue(CurrentVersionProperty);
    set => SetValue(CurrentVersionProperty, value);
  }

  public string LatestVersion
  {
    get => GetValue(LatestVersionProperty);
    set => SetValue(LatestVersionProperty, value);
  }

  private async void Load()
  {
    var currentVersion = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? string.Empty;
    currentVersion = currentVersion[..currentVersion.LastIndexOf('.')];
    CurrentVersion = $"v{currentVersion}";

    var latestVersion = await _gitHubService.GetLatestReleaseVersion("DerStimmler", "CrossLaunch");

    if (latestVersion is null)
    {
      IsUpdateAvailable = false;
      return;
    }

    LatestVersion = $"v{latestVersion}";

    if (latestVersion != currentVersion)
      IsUpdateAvailable = true;
  }
}
