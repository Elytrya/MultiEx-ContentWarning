using HarmonyLib;
using System.Reflection;

namespace MultiEx.Patches
{
    [HarmonyPatch(typeof(Flashlight))]
    public static class InfinityFlashLightPatch
    {
        static MethodBase TargetMethod()
        {
            return AccessTools.Method(typeof(Flashlight), "Update");
        }

        [HarmonyPatch(MethodType.Normal)]
        [HarmonyPostfix]
        public static void UpdateFlashlight(Flashlight __instance)
        {
            AccessTools.Field(typeof(Flashlight), "maxCharge").SetValue(__instance, 10000f);
        }
    }

    [HarmonyPatch(typeof(Defib))]
    public static class InfinityDefibPatch
    {
        static MethodBase TargetMethod()
        {
            return AccessTools.Method(typeof(Defib), "Update");
        }

        [HarmonyPatch(MethodType.Normal)]
        [HarmonyPostfix]
        public static void UpdateDefib(Defib __instance)
        {
            AccessTools.Field(typeof(Defib), "maxCharge").SetValue(__instance, 10000f);
        }
    }

    [HarmonyPatch(typeof(RescueHook))]
    public static class InfinityRescueHookPatch
    {
        static MethodBase TargetMethod()
        {
            return AccessTools.Method(typeof(RescueHook), "Update");
        }

        [HarmonyPatch(MethodType.Normal)]
        [HarmonyPostfix]
        public static void UpdateRescueHook(RescueHook __instance)
        {
            AccessTools.Field(typeof(RescueHook), "maxCharge").SetValue(__instance, 10000f);
            AccessTools.Field(typeof(RescueHook), "maxCharges").SetValue(__instance, 100);
        }
    }

    [HarmonyPatch(typeof(NorgGun))]
    public static class InfinityNorgGunPatch
    {
        static MethodBase TargetMethod()
        {
            return AccessTools.Method(typeof(NorgGun), "Update");
        }

        [HarmonyPatch(MethodType.Normal)]
        [HarmonyPostfix]
        public static void UpdateNorgGun(NorgGun __instance)
        {
            AccessTools.Field(typeof(NorgGun), "maxCharge").SetValue(__instance, 10000f);
            AccessTools.Field(typeof(NorgGun), "maxCharges").SetValue(__instance, 100);
        }
    }

    [HarmonyPatch(typeof(PersistantRadio))]
    public static class InfinityPersistantRadioPatch
    {
        static MethodBase TargetMethod()
        {
            return AccessTools.Method(typeof(PersistantRadio), "Update");
        }

        [HarmonyPatch(MethodType.Normal)]
        [HarmonyPostfix]
        public static void UpdatePersistantRadio(PersistantRadio __instance)
        {
            AccessTools.Field(typeof(PersistantRadio), "maxBatteryCharge").SetValue(__instance, 10000f);
        }
    }

    [HarmonyPatch(typeof(ArtifactRadio))]
    public static class InfinityArtifactRadioPatch
    {
        static MethodBase TargetMethod()
        {
            return AccessTools.Method(typeof(ArtifactRadio), "Update");
        }

        [HarmonyPatch(MethodType.Normal)]
        [HarmonyPostfix]
        public static void UpdateArtifactRadio(ArtifactRadio __instance)
        {
            AccessTools.Field(typeof(ArtifactRadio), "maxBatteryCharge").SetValue(__instance, 10000f);
        }
    }
}
