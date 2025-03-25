using HarmonyLib;
using System.Reflection;

namespace MultiEx.Patches
{
    [HarmonyPatch(typeof(Player.PlayerData))]
    public static class InfinityHeathPatch
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
        public static void UpdateInfinityHeath(Player.PlayerData __instance)
        {
            var health = AccessTools.Field(typeof(Player.PlayerData), "health");
            if (health != null)
            {
                AccessTools.Field(typeof(Player.PlayerData), "health").SetValue(__instance, 1000f);
            }
        }
    }
}
