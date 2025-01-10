using System;

namespace CrossLaunch;

public record GameItemVm
{
  public required string Identifier { get; set; }
  public required string DisplayName { get; init; }
  public required string Launcher { get; init; }
  public required Uri ImageUrl { get; init; }
}
