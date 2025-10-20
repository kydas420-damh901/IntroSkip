# Intro Skip for Valheim

A BepInEx plugin that skips Valheim's startup animations and logos for faster game loading.

## Features

- **Menu Animation Skip**: Bypasses the main menu startup animation
- **Logo Skip**: Removes Coffee Stain and Iron Gate studio logos
- **Fast Startup**: Significantly reduces game startup time
- **Lightweight**: Minimal performance impact
- **Version Info**: Detailed logging with version and compatibility information

## Requirements

- **Valheim**: Latest version
- **BepInEx**: 5.4.x or later

## Installation

1. Install [BepInEx](https://github.com/BepInEx/BepInEx) for Valheim
2. Download the latest `IntroSkip.dll` from releases
3. Copy `IntroSkip.dll` to `BepInEx/plugins/` folder
4. Launch Valheim

## How It Works

The mod uses Harmony patches to modify Valheim's startup behavior:

- **FejdStartup.Awake**: Sets `m_firstStartup` to `false` to skip menu animations
- **SceneLoader.Awake**: Sets `_showLogos` to `false` to disable startup logos

## Configuration

No configuration required - the mod works automatically upon installation.

## Compatibility

- **Protocol Version**: 1
- **Config Schema**: 1
- **Valheim Version**: Compatible with current stable release
- **Multiplayer**: Safe to use (client-side only)

## Logging

The mod provides detailed startup information in BepInEx logs:

```
[Info   :   IntroSkip] Intro Skip MOD v1.0.0 (build 20241220, proto=1, cfg=1) - Starting patch process
[Info   :   IntroSkip] Plugin GUID: Dyju420.IntroSkip
[Info   :   IntroSkip] BepInEx Assembly Version: 5.4.22.0
[Info   :   IntroSkip] Intro Skip MOD v1.0.0 (build 20241220, proto=1, cfg=1) - All patches applied successfully
[Info   :   IntroSkip] Features: Menu Animation Skip + Logo Skip
[Info   :   IntroSkip] Target: Valheim + BepInEx + HarmonyX
```



## Version History
### v1.0.0
- Initial release
- Menu animation skip functionality
- Logo skip functionality
- Version information system
- Comprehensive logging

## License

This project is licensed under the MIT License - see the LICENSE file for details.