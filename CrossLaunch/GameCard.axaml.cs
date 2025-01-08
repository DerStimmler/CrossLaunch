using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Input;

namespace CrossLaunch;

public class GameCard : TemplatedControl
{
  public static readonly StyledProperty<string> TitleProperty = AvaloniaProperty.Register<GameCard, string>(
    nameof(Title)
  );

  public static readonly StyledProperty<string> DescriptionProperty = AvaloniaProperty.Register<GameCard, string>(
    nameof(Description)
  );

  public static readonly StyledProperty<string> ImageUrlProperty = AvaloniaProperty.Register<GameCard, string>(
    nameof(ImageUrl),
    "https://placehold.co/400"
  );

  public static readonly StyledProperty<bool> IsSelectedProperty = AvaloniaProperty.Register<GameCard, bool>(
    nameof(IsSelected)
  );

  public GameCard()
  {
    InitializeIfNeeded();
  }

  public string Title
  {
    get => GetValue(TitleProperty);
    set => SetValue(TitleProperty, value);
  }

  public string Description
  {
    get => GetValue(DescriptionProperty);
    set => SetValue(DescriptionProperty, value);
  }

  public string ImageUrl
  {
    get => GetValue(ImageUrlProperty);
    set => SetValue(ImageUrlProperty, value);
  }

  public bool IsSelected
  {
    get => GetValue(IsSelectedProperty);
    set => SetValue(IsSelectedProperty, value);
  }

  protected override void OnPointerPressed(PointerPressedEventArgs e)
  {
    base.OnPointerPressed(e);
    IsSelected = true;
  }

  protected override void OnKeyDown(KeyEventArgs e)
  {
    base.OnKeyDown(e);
    if (e.Key == Key.Enter || e.Key == Key.Space)
      IsSelected = true;
  }
}
