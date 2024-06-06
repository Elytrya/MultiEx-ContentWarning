using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;
using HarmonyLib;
using System.Reflection;

namespace MultiEx
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class MultiEx : BaseUnityPlugin
    {
        private const string modGUID = "MultiEx";
        private const string modName = "MultiEx";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        internal ManualLogSource mls;

        private ConfigEntry<bool> enableInfinityFlashLightPatch;
        private ConfigEntry<bool> enableInfinityHealthPatch;
        private ConfigEntry<bool> enableInfinityOxygenPatch;
        private ConfigEntry<bool> enableInfinityStaminaPatch;
        private ConfigEntry<bool> enableMoneyBoostPatch;

        void Awake()
        {
            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            mls.LogInfo("MultiEx успешно загружен и запущен.");

            // Initialize configuration
            InitConfig();

            // Apply patches based on configuration
            ApplyPatches();

        }

        private void InitConfig()
        {
            enableInfinityFlashLightPatch = Config.Bind("Patches", "EnableInfinityFlashLightPatch", true, "Enable or disable the Infinity FlashLight Patch.");
            enableInfinityHealthPatch = Config.Bind("Patches", "EnableInfinityHealthPatch", true, "Enable or disable the Infinity Health Patch.");
            enableInfinityOxygenPatch = Config.Bind("Patches", "EnableInfinityOxygenPatch", true, "Enable or disable the Infinity Oxygen Patch.");
            enableInfinityStaminaPatch = Config.Bind("Patches", "EnableInfinityStaminaPatch", true, "Enable or disable the Infinity Stamina Patch.");
            enableMoneyBoostPatch = Config.Bind("Patches", "EnableMoneyBoostPatch", false, "Enable or disable the Money Boost Patch.");
        }

        private void ApplyPatches()
        {
            var assembly = Assembly.GetExecutingAssembly();

            if (enableInfinityFlashLightPatch.Value)
            {
                mls.LogInfo("Applying InfinityFlashLightPatch");
                harmony.PatchAll(assembly.GetType("MultiEx.Patches.InfinityFlashLightPatch"));
            }

            if (enableInfinityHealthPatch.Value)
            {
                mls.LogInfo("Applying InfinityHealthPatch");
                harmony.PatchAll(assembly.GetType("MultiEx.Patches.InfinityHeathPatch"));
            }

            if (enableInfinityOxygenPatch.Value)
            {
                mls.LogInfo("Applying MaxOxygenPatch");
                harmony.PatchAll(assembly.GetType("MultiEx.Patches.MaxOxygenPatch"));
            }

            if (enableInfinityStaminaPatch.Value)
            {
                mls.LogInfo("Applying InfinityStaminaPatch");
                harmony.PatchAll(assembly.GetType("MultiEx.Patches.InfinityStaminaPatch"));
            }

            if (enableMoneyBoostPatch.Value)
            {
                mls.LogInfo("Applying MoneyBoostPatch");
                harmony.PatchAll(assembly.GetType("MultiEx.Patches.MoneyBoostPatch"));
            }
        }
    }
}
