using HarmonyLib;
using System.Reflection;

namespace MultiEx.Patches
{
    [HarmonyPatch(typeof(Player.PlayerData))]
    public static class InfinityStaminaPatch
    {
        static MethodBase TargetMethod()
        {
            MethodBase method = AccessTools.Method(typeof(PlayerController), "Update");
            if (method == null)
            {
                foreach (var m in typeof(PlayerController).GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
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
        public static void UpdateStamina(PlayerController __instance)
        {
            AccessTools.Field(typeof(PlayerController), "maxStamina").SetValue(__instance, 999999999999999f);
            AccessTools.Field(typeof(PlayerController), "jumpImpulse").SetValue(__instance, 0f);
            AccessTools.Field(typeof(PlayerController), "sprintMultiplier").SetValue(__instance, 4f);
            AccessTools.Field(typeof(PlayerController), "staminaRegRate").SetValue(__instance, 999999999999999f);
            AccessTools.Field(typeof(PlayerController), "jumpForceDuration").SetValue(__instance, 1f);
            AccessTools.Field(typeof(PlayerController), "staminaReActivationThreshold").SetValue(__instance, 0f);
        }
    }
}
