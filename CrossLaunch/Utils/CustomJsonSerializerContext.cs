using System.Collections.Generic;
using System.Text.Json.Serialization;
using CrossLaunch.Features.Epic;

namespace CrossLaunch.Utils;

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(EgDataItem))]
[JsonSerializable(typeof(EpicManifest))]
[JsonSerializable(typeof(List<EgDataItem>))]
public partial class CustomJsonSerializerContext : JsonSerializerContext { }
