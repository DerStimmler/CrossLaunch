using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CrossLaunch.Utils;
using Serilog;

namespace CrossLaunch.Features.GitHub;

public class GitHubService
{
  private readonly HttpClient _http;

  public GitHubService()
  {
    _http = new HttpClient { BaseAddress = new Uri("https://api.github.com") };

    _http.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0");
  }

  public async Task<string?> GetLatestReleaseVersion(string owner, string repo)
  {
    try
    {
      var response = await _http.GetAsync($"repos/{owner}/{repo}/releases/latest");

      if (!response.IsSuccessStatusCode)
        return null;

      var release = await response.Content.ReadFromJsonAsync<GitHubRelease>(
        CustomJsonSerializerContext.Default.GitHubRelease
      );

      return release?.TagName.Replace("v", string.Empty);
    }
    catch (Exception e)
    {
      Log.Error(e, "Latest release version of {Owner}/{Repo} could not be fetched", owner, repo);
      return null;
    }
  }
}
