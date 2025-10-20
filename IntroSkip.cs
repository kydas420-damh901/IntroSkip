using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Reflection;

namespace IntroSkip
{
    [BepInPlugin("Dyju420.IntroSkip", "Intro Skip", VersionInfo.Version)]
    public class IntroSkipPlugin : BaseUnityPlugin
    {
        private static ManualLogSource _logger = null!;

        private void Awake()
        {
            _logger = Logger;
            _logger.LogInfo($"Intro Skip MOD {VersionInfo.VersionString} - Starting patch process");
            _logger.LogInfo($"Plugin GUID: Dyju420.IntroSkip");
            _logger.LogInfo($"BepInEx Assembly Version: {typeof(BepInEx.BaseUnityPlugin).Assembly.GetName().Version}");
            
            var harmony = new Harmony("Dyju420.IntroSkip");
            
            try
            {
                // Patch FejdStartup.Awake for menu animation skip
                harmony.Patch(
                    AccessTools.Method(typeof(FejdStartup), "Awake"),
                    prefix: new HarmonyMethod(typeof(IntroSkipPlugin), nameof(FejdStartup_Awake_Prefix))
                );

                // Patch SceneLoader.Awake for logo skip
                harmony.Patch(
                    AccessTools.Method(typeof(SceneLoader), "Awake"),
                    postfix: new HarmonyMethod(typeof(IntroSkipPlugin), nameof(SceneLoader_Awake_Postfix))
                );

                _logger.LogInfo("Intro Skip MOD - All patches applied successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to apply patches: {ex}");
            }
        }

        // Disable menu animation by setting m_firstStartup to false
        public static void FejdStartup_Awake_Prefix()
        {
            try
            {
                AccessTools.Field(typeof(FejdStartup), "m_firstStartup")?.SetValue(null, false);
            }
            catch (Exception ex)
            {
                _logger?.LogError($"Error disabling menu animation: {ex}");
            }
        }

        // Disable startup logos by setting _showLogos to false
        public static void SceneLoader_Awake_Postfix(SceneLoader __instance)
        {
            try
            {
                AccessTools.Field(typeof(SceneLoader), "_showLogos")?.SetValue(__instance, false);
            }
            catch (Exception ex)
            {
                _logger?.LogError($"Error disabling startup logos: {ex}");
            }
        }
    }
}