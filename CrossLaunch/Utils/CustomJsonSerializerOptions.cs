namespace CrossLaunch.Utils;

public class CustomJsonSerializerOptions
{
  public static System.Text.Json.JsonSerializerOptions Default =>
    new() { PropertyNameCaseInsensitive = true, TypeInfoResolver = CustomJsonSerializerContext.Default };
}
