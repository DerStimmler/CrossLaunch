using System.Text.Json.Serialization;

namespace CrossLaunch.Features.GitHub;

public record GitHubRelease
{
  [JsonPropertyName("tag_name")]
  public required string TagName { get; init; }
}
