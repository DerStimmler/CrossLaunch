using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CrossLaunch.Features.Epic;

public class EpicService
{
  private readonly EgDataService _egDataService;

  public EpicService()
  {
    _egDataService = new EgDataService();
  }

  public async Task<List<EpicGame>> GetGames()
  {
    var epicManifests = await GetManifests(CancellationToken.None);

    var games = new List<EpicGame>();

    foreach (var manifest in epicManifests)
    {
      var gameInfo = await _egDataService.FindGame(manifest.CatalogNamespace, manifest.CatalogItemId);

      if (gameInfo is null)
        continue;

      var imageUri = gameInfo.KeyImages.FirstOrDefault()?.Url ?? "https://placehold.co/600x400";

      var game = new EpicGame(manifest, new Uri(imageUri));

      games.Add(game);
    }

    return games;
  }

  private static async Task<List<EpicManifest>> GetManifests(CancellationToken ct)
  {
    var programDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
    var epicManifestsFolder = Path.Combine(programDataFolder, "Epic", "EpicGamesLauncher", "Data", "Manifests");

    var manifestFiles = Directory.GetFiles(epicManifestsFolder, "*.item");

    var manifests = new List<EpicManifest>();

    foreach (var manifestFile in manifestFiles)
    {
      var manifestContent = await File.ReadAllTextAsync(manifestFile, ct);
      var manifest = JsonSerializer.Deserialize<EpicManifest>(
        manifestContent,
        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
      );

      if (manifest is null)
        continue;

      manifests.Add(manifest);
    }

    return manifests;
  }

  public async Task StartGame(EpicManifest manifest, CancellationToken ct)
  {
    var launchUrl =
      $"com.epicgames.launcher://apps/{manifest.CatalogNamespace}%3A{manifest.CatalogItemId}%3A{manifest.AppName}?action=launch&silent=true";

    var startInfo = new ProcessStartInfo(launchUrl)
    {
      UseShellExecute = true,
      Verb = "open",
      CreateNoWindow = true,
    };

    var launchProcess = Process.Start(startInfo);

    if (launchProcess is null)
      throw new InvalidOperationException("Failed to start the game.");

    // Poll for 30 seconds to check if the game has started
    Process? gameProcess = null;
    var startTime = DateTime.Now;

    while (gameProcess is null && (DateTime.Now - startTime).TotalSeconds < 30 && !ct.IsCancellationRequested)
    {
      var process = Process
        .GetProcessesByName(Path.GetFileNameWithoutExtension(manifest.LaunchExecutable))
        .FirstOrDefault();

      if (process != null)
        gameProcess = process;

      await Task.Delay(1000, ct);
    }

    if (gameProcess is null)
      throw new TimeoutException("The game did not start within 30 seconds.");

    await gameProcess.WaitForExitAsync(ct);

    var launcher = Process.GetProcessesByName("EpicGamesLauncher").FirstOrDefault();

    if (launcher is { HasExited: false })
      launcher.Kill();
  }
}
