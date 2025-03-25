using HarmonyLib;
using System.Reflection;

namespace MultiEx.Patches
{
    [HarmonyPatch(typeof(Player.PlayerData))]
    public static class MaxOxygenPatch
    {
        static MethodBase TargetMethod()
        {
            MethodBase method = AccessTools.Method(typeof(Player.PlayerData), "Update");
            if (method == null)
            {
                foreach (var m in typeof(Player.PlayerData).GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
                {
                    if (m.Name.Contains("Update"))
                    {
                        method = m;
                        break;
                    }
                }
            }
            return method;
        }

        [HarmonyPatch(MethodType.Normal)]
        [HarmonyPostfix]
        public static void UpdateMaxOxygen(Player.PlayerData __instance)
        {
            var maxOxygenField = AccessTools.Field(typeof(Player.PlayerData), "maxOxygen");
            if (maxOxygenField != null)
            {
                maxOxygenField.SetValue(__instance, 1000f);
                AccessTools.Field(typeof(Player.PlayerData), "remainingOxygen").SetValue(__instance, 1000f);
                AccessTools.Field(typeof(Player.PlayerData), "usingOxygen").SetValue(__instance, false);
            }
        }
    }
}
