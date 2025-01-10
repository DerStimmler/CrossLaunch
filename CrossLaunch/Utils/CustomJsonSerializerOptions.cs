using System.Text.Json;

namespace CrossLaunch.Utils;

public class CustomJsonSerializerOptions
{
  public static JsonSerializerOptions Default =>
    new() { PropertyNameCaseInsensitive = true, TypeInfoResolver = CustomJsonSerializerContext.Default };
}
