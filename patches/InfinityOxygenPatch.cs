using HarmonyLib;
using System.Reflection;

namespace MultiEx.Patches
{
    [HarmonyPatch(typeof(Player.PlayerData))]
    public static class MaxOxygenPatch
    {
        static MethodBase TargetMethod()
        {
            // Попробуйте найти метод Update через рефлексию
            MethodBase method = AccessTools.Method(typeof(Player.PlayerData), "Update");
            if (method == null)
            {
                // Если метод не найден, добавьте здесь дополнительную логику поиска
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
            // Проверяем, существует ли поле maxOxygen в Player.PlayerData
            var maxOxygenField = AccessTools.Field(typeof(Player.PlayerData), "maxOxygen");
            if (maxOxygenField != null)
            {
                // Устанавливаем значение maxOxygen на 1f
                maxOxygenField.SetValue(__instance, 1000f);
                // Устанавливаем значение remainingOxygen на 0f
                AccessTools.Field(typeof(Player.PlayerData), "remainingOxygen").SetValue(__instance, 1000f);
                // Устанавливаем значение usingOxygen на false
                AccessTools.Field(typeof(Player.PlayerData), "usingOxygen").SetValue(__instance, false);
            }
        }
    }
}
