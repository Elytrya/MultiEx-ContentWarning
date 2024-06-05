using HarmonyLib;
using System;
using System.Reflection;

namespace MultiEx.Patches
{
    [HarmonyPatch(typeof(BigNumbers))]
    public static class MoneyBoostPatch
    {
        static MethodBase TargetMethod()
        {
            // Define the parameters of the method
            Type[] parameterTypes = new Type[] { };

            // Find the method with the specified name and parameters
            MethodBase method = AccessTools.Method(typeof(BigNumbers), "Update", parameterTypes);

            // If the method is not found, return null
            if (method == null)
            {
                // Log a warning or perform additional actions if needed
            }

            return method;
        }


        [HarmonyPatch(MethodType.Normal)]
        [HarmonyPostfix]
        public static void UpdateBigNumbers(BigNumbers __instance)
        {
            // Устанавливаем значения полей в BigNumbers
            AccessTools.Field(typeof(BigNumbers), "StartMoney").SetValue(__instance, 9999999);
            AccessTools.Field(typeof(BigNumbers), "BarnacleBallScore").SetValue(__instance, 9999999f);
            AccessTools.Field(typeof(BigNumbers), "BigSlapAgro").SetValue(__instance, 9999999f);
            AccessTools.Field(typeof(BigNumbers), "BigSlapPeaceful").SetValue(__instance, 9999999f);
            AccessTools.Field(typeof(BigNumbers), "EarScore").SetValue(__instance, 9999999f);
            AccessTools.Field(typeof(BigNumbers), "FlickerScore").SetValue(__instance, 9999999f);
            AccessTools.Field(typeof(BigNumbers), "JelloScore").SetValue(__instance, 9999999f);
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
            AccessTools.Field(typeof(BigNumbers), "PlayerScore").SetValue(__instance, 9999999f);
            AccessTools.Field(typeof(BigNumbers), "playerRagdollScore").SetValue(__instance, 9999999f);
            AccessTools.Field(typeof(BigNumbers), "playerSmallFallScore").SetValue(__instance, 9999999f);
            AccessTools.Field(typeof(BigNumbers), "playerBigFallScore").SetValue(__instance, 9999999f);
            AccessTools.Field(typeof(BigNumbers), "playerDeadScore").SetValue(__instance, 9999999f);
            AccessTools.Field(typeof(BigNumbers), "PlayerFacingAwayFactor").SetValue(__instance, 9999999f);
            AccessTools.Field(typeof(BigNumbers), "PlayerFacingTowardsFactor").SetValue(__instance, 9999999f);
            AccessTools.Field(typeof(BigNumbers), "PlayerMicrophoneBounus").SetValue(__instance, 9999999f);
            AccessTools.Field(typeof(BigNumbers), "playerGoodCatchScore").SetValue(__instance, 9999999f);
            AccessTools.Field(typeof(BigNumbers), "playerTookDamageScore").SetValue(__instance, 9999999f);
            AccessTools.Field(typeof(BigNumbers), "day1ExtraMoBudget").SetValue(__instance, 9999999);
            AccessTools.Field(typeof(BigNumbers), "day2ExtraMoBudget").SetValue(__instance, 9999999);
            AccessTools.Field(typeof(BigNumbers), "day3ExtraMoBudget").SetValue(__instance, 9999999);
        }
    }
}
