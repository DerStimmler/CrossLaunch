using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CrossLaunch.Features.Epic;

namespace CrossLaunch.Features;

public class GameService
{
  private readonly EpicService _epicService;
  private List<EpicGame> _epicGames = [];

  public GameService()
  {
    _epicService = new EpicService();
  }

  public async Task<List<GameItemVm>> GetGames()
  {
    _epicGames = await _epicService.GetGames();

    return _epicGames
      .Select(game => new GameItemVm
      {
        Identifier = game.Manifest.CatalogItemId,
        DisplayName = game.Manifest.DisplayName,
        Launcher = "Epic Games Launcher",
        ImageUrl = game.ImageUri,
      })
      .ToList();
  }

  public async Task StartGame(GameItemVm gameItem)
  {
    var game = _epicGames.First(game => game.Manifest.CatalogItemId == gameItem.Identifier);

    await _epicService.StartGame(game.Manifest, CancellationToken.None);
  }
}
