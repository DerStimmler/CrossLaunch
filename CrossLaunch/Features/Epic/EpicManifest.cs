using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CrossLaunch.Features.Epic;

public record EpicManifest
{
  [JsonPropertyName("FormatVersion")]
  public required int FormatVersion { get; init; }

  [JsonPropertyName("bIsIncompleteInstall")]
  public required bool IsIncompleteInstall { get; init; }

  [JsonPropertyName("LaunchCommand")]
  public required string LaunchCommand { get; init; }

  [JsonPropertyName("LaunchExecutable")]
  public required string LaunchExecutable { get; init; }

  [JsonPropertyName("ManifestLocation")]
  public required string ManifestLocation { get; init; }

  [JsonPropertyName("ManifestHash")]
  public required string ManifestHash { get; init; }

  [JsonPropertyName("bIsApplication")]
  public required bool IsApplication { get; init; }

  [JsonPropertyName("bIsExecutable")]
  public required bool IsExecutable { get; init; }

  [JsonPropertyName("bIsManaged")]
  public required bool IsManaged { get; init; }

  [JsonPropertyName("bNeedsValidation")]
  public required bool NeedsValidation { get; init; }

  [JsonPropertyName("bRequiresAuth")]
  public required bool RequiresAuth { get; init; }

  [JsonPropertyName("bAllowMultipleInstances")]
  public required bool AllowMultipleInstances { get; init; }

  [JsonPropertyName("bCanRunOffline")]
  public required bool CanRunOffline { get; init; }

  [JsonPropertyName("bAllowUriCmdArgs")]
  public required bool AllowUriCmdArgs { get; init; }

  [JsonPropertyName("bLaunchElevated")]
  public required bool LaunchElevated { get; init; }

  [JsonPropertyName("BaseURLs")]
  public required List<string> BaseUrls { get; init; }

  [JsonPropertyName("BuildLabel")]
  public required string BuildLabel { get; init; }

  [JsonPropertyName("AppCategories")]
  public required List<string> AppCategories { get; init; }

  [JsonPropertyName("ChunkDbs")]
  public required List<string> ChunkDbs { get; init; }

  [JsonPropertyName("CompatibleApps")]
  public required List<string> CompatibleApps { get; init; }

  [JsonPropertyName("DisplayName")]
  public required string DisplayName { get; init; }

  [JsonPropertyName("InstallationGuid")]
  public required string InstallationGuid { get; init; }

  [JsonPropertyName("InstallLocation")]
  public required string InstallLocation { get; init; }

  [JsonPropertyName("InstallSessionId")]
  public required string InstallSessionId { get; init; }

  [JsonPropertyName("InstallTags")]
  public required List<string> InstallTags { get; init; }

  [JsonPropertyName("InstallComponents")]
  public required List<string> InstallComponents { get; init; }

  [JsonPropertyName("HostInstallationGuid")]
  public required string HostInstallationGuid { get; init; }

  [JsonPropertyName("PrereqIds")]
  public required List<string> PrereqIds { get; init; }

  [JsonPropertyName("PrereqSHA1Hash")]
  public required string PrereqSha1Hash { get; init; }

  [JsonPropertyName("LastPrereqSucceededSHA1Hash")]
  public required string LastPrereqSucceededSha1Hash { get; init; }

  [JsonPropertyName("StagingLocation")]
  public required string StagingLocation { get; init; }

  [JsonPropertyName("TechnicalType")]
  public required string TechnicalType { get; init; }

  [JsonPropertyName("VaultThumbnailUrl")]
  public required string VaultThumbnailUrl { get; init; }

  [JsonPropertyName("VaultTitleText")]
  public required string VaultTitleText { get; init; }

  [JsonPropertyName("InstallSize")]
  public required long InstallSize { get; init; }

  [JsonPropertyName("MainWindowProcessName")]
  public required string MainWindowProcessName { get; init; }

  [JsonPropertyName("ProcessNames")]
  public required List<string> ProcessNames { get; init; }

  [JsonPropertyName("BackgroundProcessNames")]
  public required List<string> BackgroundProcessNames { get; init; }

  [JsonPropertyName("IgnoredProcessNames")]
  public required List<string> IgnoredProcessNames { get; init; }

  [JsonPropertyName("DlcProcessNames")]
  public required List<string> DlcProcessNames { get; init; }

  [JsonPropertyName("MandatoryAppFolderName")]
  public required string MandatoryAppFolderName { get; init; }

  [JsonPropertyName("OwnershipToken")]
  public required string OwnershipToken { get; init; }

  [JsonPropertyName("SidecarConfigRevision")]
  public required int SidecarConfigRevision { get; init; }

  [JsonPropertyName("CatalogNamespace")]
  public required string CatalogNamespace { get; init; }

  [JsonPropertyName("CatalogItemId")]
  public required string CatalogItemId { get; init; }

  [JsonPropertyName("AppName")]
  public required string AppName { get; init; }

  [JsonPropertyName("AppVersionString")]
  public required string AppVersionString { get; init; }

  [JsonPropertyName("MainGameCatalogNamespace")]
  public required string MainGameCatalogNamespace { get; init; }

  [JsonPropertyName("MainGameCatalogItemId")]
  public required string MainGameCatalogItemId { get; init; }

  [JsonPropertyName("MainGameAppName")]
  public required string MainGameAppName { get; init; }

  [JsonPropertyName("AllowedUriEnvVars")]
  public required List<string> AllowedUriEnvVars { get; init; }
}
