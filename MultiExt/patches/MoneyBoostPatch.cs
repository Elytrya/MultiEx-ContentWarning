using HarmonyLib;
using System;
using System.Reflection;
using UnityEngine;

namespace MultiEx.Patches
{
    [HarmonyPatch(typeof(BigNumbers))]
    public static class MoneyBoostPatch
    {
        public static MethodBase TargetMethod()
        {
            MethodInfo[] methods = typeof(BigNumbers).GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var method in methods)
            {
                Debug.Log($"Found method: {method.Name}");
            }

            MethodBase methodToPatch = null;

            foreach (var method in methods)
            {
                if (method.Name.Contains("Update") || method.Name.Contains("OnLoaded"))
                {
                    methodToPatch = method;
                    break;
                }
            }

            if (methodToPatch == null)
            {
                Debug.LogError("No suitable method found to patch in class 'BigNumbers'.");
            }

            return methodToPatch;
        }

        [HarmonyPatch(MethodType.Normal)]
        [HarmonyPostfix]
        public static void UpdateMoney(BigNumbers __instance)
        {
            try
            {
                AccessTools.Field(typeof(BigNumbers), "BigSlapAgro").SetValue(__instance, 9999999f);
                AccessTools.Field(typeof(BigNumbers), "BigSlapPeaceful").SetValue(__instance, 9999999f);
                AccessTools.Field(typeof(BigNumbers), "EarScore").SetValue(__instance, 9999999f);
                AccessTools.Field(typeof(BigNumbers), "FlickerScore").SetValue(__instance, 9999999f);
                AccessTools.Field(typeof(BigNumbers), "KnifoScore").SetValue(__instance, 9999999f);
                AccessTools.Field(typeof(BigNumbers), "bombsScore").SetValue(__instance, 9999999f);
                AccessTools.Field(typeof(BigNumbers), "spiderScore").SetValue(__instance, 9999999f);
                AccessTools.Field(typeof(BigNumbers), "larvaScore").SetValue(__instance, 9999999f);
                AccessTools.Field(typeof(BigNumbers), "walloScore").SetValue(__instance, 9999999f);
                AccessTools.Field(typeof(BigNumbers), "mimeScore").SetValue(__instance, 9999999f);
                AccessTools.Field(typeof(BigNumbers), "wormScore").SetValue(__instance, 9999999f);
                AccessTools.Field(typeof(BigNumbers), "fireMonsterScore").SetValue(__instance, 9999999f);
                AccessTools.Field(typeof(BigNumbers), "blackHoleBotScore").SetValue(__instance, 9999999f);
                AccessTools.Field(typeof(BigNumbers), "snailSpawnerScore").SetValue(__instance, 9999999f);
                AccessTools.Field(typeof(BigNumbers), "streamerScore").SetValue(__instance, 9999999f);
                AccessTools.Field(typeof(BigNumbers), "harpoonerScore").SetValue(__instance, 9999999f);
                AccessTools.Field(typeof(BigNumbers), "robotButton").SetValue(__instance, 9999999f);
                AccessTools.Field(typeof(BigNumbers), "dogScore").SetValue(__instance, 9999999f);
                AccessTools.Field(typeof(BigNumbers), "camCreepScore").SetValue(__instance, 9999999f);
                AccessTools.Field(typeof(BigNumbers), "eyeGuyScore").SetValue(__instance, 9999999f);
                AccessTools.Field(typeof(BigNumbers), "MouthScore").SetValue(__instance, 9999999f);
                AccessTools.Field(typeof(BigNumbers), "SlurperScore").SetValue(__instance, 9999999f);
                AccessTools.Field(typeof(BigNumbers), "SnatchoScore").SetValue(__instance, 9999999f);
                AccessTools.Field(typeof(BigNumbers), "ToolkitWhiskScore").SetValue(__instance, 9999999f);
                AccessTools.Field(typeof(BigNumbers), "WeepingScoreIdle").SetValue(__instance, 9999999f);
                AccessTools.Field(typeof(BigNumbers), "WeepingScoreSuccuess").SetValue(__instance, 9999999f);
                AccessTools.Field(typeof(BigNumbers), "WeepingScoreFail").SetValue(__instance, 9999999f);
                AccessTools.Field(typeof(BigNumbers), "WeepingScoreCaptured").SetValue(__instance, 9999999f);
                AccessTools.Field(typeof(BigNumbers), "ZombieScore").SetValue(__instance, 9999999f);
                AccessTools.Field(typeof(BigNumbers), "puffoScore").SetValue(__instance, 9999999f);
            }
            catch (Exception ex)
            {
                Debug.LogError($"Ошибка в применении патча MoneyBoostPatch: {ex}");
                Debug.LogWarning("Патч MoneyBoostPatch не применен.");
            }
        }
    }
}
