using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using CrossLaunch.Features;

namespace CrossLaunch;

public partial class GameSelection : UserControl
{
  public static readonly StyledProperty<ObservableCollection<GameItemVm>> ItemsProperty = AvaloniaProperty.Register<
    GameSelection,
    ObservableCollection<GameItemVm>
  >(nameof(Items));

  public static readonly StyledProperty<bool> IsGameRunningProperty = AvaloniaProperty.Register<GameSelection, bool>(
    nameof(IsGameRunning)
  );

  public static readonly StyledProperty<string> RunningGameNameProperty = AvaloniaProperty.Register<
    GameSelection,
    string
  >(nameof(RunningGameName));

  private readonly GameService _gameService;

  public GameSelection()
  {
    InitializeComponent();

    DataContext = this;
    Items = [];

    _gameService = new GameService();

    Foo();
  }

  public bool IsGameRunning
  {
    get => GetValue(IsGameRunningProperty);
    set => SetValue(IsGameRunningProperty, value);
  }

  public string RunningGameName
  {
    get => GetValue(RunningGameNameProperty);
    set => SetValue(RunningGameNameProperty, value);
  }

  public ObservableCollection<GameItemVm> Items
  {
    get => GetValue(ItemsProperty);
    set => SetValue(ItemsProperty, value);
  }

  private async void Foo()
  {
    var games = await _gameService.GetGames();

    foreach (var game in games)
      Items.Add(game);
  }

  private async void OnPointerPressed(object? sender, PointerPressedEventArgs e)
  {
    var element = sender as Border;
    var gameId = element?.Tag?.ToString();

    await StartGame(gameId!);
  }

  private async Task StartGame(string gameId)
  {
    if (IsGameRunning)
      return;

    var game = Items.First(x => x.Identifier == gameId);

    RunningGameName = game.DisplayName;
    IsGameRunning = true;
    await _gameService.StartGame(game);
    IsGameRunning = false;
  }

  private async void OnKeyDown(object? sender, KeyEventArgs e)
  {
    if (e.Key != Key.Enter && e.Key != Key.Space)
      return;

    var element = sender as Border;
    var gameId = element?.Tag?.ToString();

    await StartGame(gameId!);
  }
}
