using System.Collections.ObjectModel;
using System.Linq;
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

  private readonly GameService _gameService;

  public GameSelection()
  {
    InitializeComponent();

    DataContext = this;
    Items = [];

    _gameService = new GameService();

    Foo();
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

    var game = Items.First(x => x.Identifier == gameId);

    await _gameService.StartGame(game);
  }

  private async void OnKeyDown(object? sender, KeyEventArgs e)
  {
    if (e.Key != Key.Enter && e.Key != Key.Space)
      return;

    var element = sender as Border;
    var gameId = element?.Tag?.ToString();

    var game = Items.First(x => x.Identifier == gameId);

    await _gameService.StartGame(game);
  }
}
