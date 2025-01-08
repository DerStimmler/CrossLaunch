<div align="center" width="100%">
  <picture>
    <source media="(prefers-color-scheme: dark)" srcset="assets/img/CrossLaunch-Logo7.png" />
    <source media="(prefers-color-scheme: light)" srcset="assets/img/CrossLaunch-Logo4.png" />
    <img alt="CrossLaunch Logo" src="assets/img/CrossLaunch-Logo7.png" height="128" />
  </picture>
</div>

# CrossLaunch

[![GitHub license](https://img.shields.io/github/license/co-IT/CSharpFunctionalExtensions.HttpResults)](https://github.com/co-IT/CSharpFunctionalExtensions.HttpResults/blob/main/LICENSE.md)

Launch games of various launchers from Steam

CrossLaunch lets you start all your games from Steam, bringing Steam's powerful features like controller support and Steam Overlay to games from other launchers. It simplifies your gaming experience by unifying your library and enhancing compatibility, so you can enjoy every game with the convenience of Steam.

## Usage

1. Download the newest version archive from [GitHub Releases](https://github.com/DerStimmler/CrossLaunch/releases)
2. Extract the archive
3. In your Steam library, add the executable as a Non-Steam Game

   | Add Non-Steam Game                                                               | Browse for executable                                                                       |
   |----------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------|
   | <img src="assets/docs/non-steam-game.png" alt="add non steam game" height="80"/> | <img src="assets/docs/non-steam-game-browse.png" alt="browse for executable" height="170"/> |
4. Start CrossLaunch through Steam by clicking _Play_
5. Select a game in the CrossLaunch launcher
   
    <img src="assets/docs/cross-launch-game-selection.png" alt="select game in CrossLaunch launcher" height="200"/>

## Supported Launchers

- Epic Games Store

## Development

1. Restore dotnet dependencies `dotnet restore`
2. Restore dotnet tools `dotnet tool restore`
3. Run app `dotnet run --project CrossLaunch`

- Format files `dotnet csharpier .`

## Shout-Out

Shout-Out to [EGDATA](https://egdata.app/), whose API is used to fetch the game images.
