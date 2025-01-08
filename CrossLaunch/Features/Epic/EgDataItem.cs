using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CrossLaunch.Features.Epic;

public record EgDataItem
{
  [JsonPropertyName("id")]
  public required string Id { get; init; }

  [JsonPropertyName("namespace")]
  public required string Namespace { get; init; }

  [JsonPropertyName("title")]
  public required string Title { get; init; }

  [JsonPropertyName("description")]
  public required string Description { get; init; }

  [JsonPropertyName("keyImages")]
  public required List<KeyImage> KeyImages { get; init; }

  // [JsonPropertyName("categories")]
  // public required List<Category> Categories { get; init; }

  // [JsonPropertyName("status")]
  // public required string Status { get; init; }
  //
  // [JsonPropertyName("creationDate")]
  // public required DateTime CreationDate { get; init; }
  //
  // [JsonPropertyName("lastModifiedDate")]
  // public required DateTime LastModifiedDate { get; init; }
  //
  // [JsonPropertyName("customAttributes")]
  // public required List<CustomAttribute> CustomAttributes { get; init; }
  //
  // [JsonPropertyName("entitlementName")]
  // public required string EntitlementName { get; init; }
  //
  // [JsonPropertyName("entitlementType")]
  // public required string EntitlementType { get; init; }
  //
  // [JsonPropertyName("itemType")]
  // public required string ItemType { get; init; }
  //
  // [JsonPropertyName("releaseInfo")]
  // public required List<ReleaseInfo> ReleaseInfo { get; init; }
  //
  // [JsonPropertyName("developer")]
  // public required string Developer { get; init; }
  //
  // [JsonPropertyName("developerId")]
  // public required string DeveloperId { get; init; }
  //
  // [JsonPropertyName("eulaIds")]
  // public required List<string> EulaIds { get; init; }
  //
  // [JsonPropertyName("installModes")]
  // public required List<string> InstallModes { get; init; }
  //
  // [JsonPropertyName("endOfSupport")]
  // public required bool EndOfSupport { get; init; }
  //
  // [JsonPropertyName("applicationId")]
  // public required string ApplicationId { get; init; }
  //
  // [JsonPropertyName("unsearchable")]
  // public required bool Unsearchable { get; init; }
  //
  // [JsonPropertyName("requiresSecureAccount")]
  // public required bool RequiresSecureAccount { get; init; }
  //
  // [JsonPropertyName("__v")]
  // public required int Version { get; init; }
  //
  // [JsonPropertyName("linkedOffers")]
  // public required List<string> LinkedOffers { get; init; }
}

public record KeyImage
{
  [JsonPropertyName("type")]
  public required string Type { get; init; }

  [JsonPropertyName("url")]
  public required string Url { get; init; }

  [JsonPropertyName("md5")]
  public required string Md5 { get; init; }
}

// public record Category
// {
//   [JsonPropertyName("path")]
//   public required string Path { get; init; }
//
//   [JsonPropertyName("_id")]
//   public required string InternalId { get; init; }
// }
//
// public record CustomAttribute
// {
//   [JsonPropertyName("key")]
//   public required string Key { get; init; }
//
//   [JsonPropertyName("type")]
//   public required string Type { get; init; }
//
//   [JsonPropertyName("value")]
//   public required string Value { get; init; }
// }
//
// public record ReleaseInfo
// {
//   [JsonPropertyName("id")]
//   public required string InternalId { get; init; }
//
//   [JsonPropertyName("appId")]
//   public required string AppId { get; init; }
//
//   [JsonPropertyName("platform")]
//   public required List<string> Platform { get; init; }
//
//   [JsonPropertyName("_id")]
//   public required string ReleaseId { get; init; }
// }
