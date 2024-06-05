using BepInEx;
using BepInEx.Logging;
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

        void Awake()
        {
            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            mls.LogInfo("MultiEx успешно загружен и запущен.");
            harmony.PatchAll(Assembly.GetExecutingAssembly());

        }
    }
}