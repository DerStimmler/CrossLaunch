using System.Collections.Generic;
using System.Text.Json.Serialization;
using CrossLaunch.Features.Epic;
using CrossLaunch.Features.GitHub;

namespace CrossLaunch.Utils;

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(EgDataItem))]
[JsonSerializable(typeof(GitHubRelease))]
[JsonSerializable(typeof(EpicManifest))]
[JsonSerializable(typeof(List<EgDataItem>))]
public partial class CustomJsonSerializerContext : JsonSerializerContext { }
