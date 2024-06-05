using HarmonyLib;
using System.Reflection;

namespace MultiEx.Patches
{
    [HarmonyPatch(typeof(Player.PlayerData))]
    public static class InfinityStaminaPatch
    {
        static MethodBase TargetMethod()
        {
            // Попробуйте найти метод Update через рефлексию
            MethodBase method = AccessTools.Method(typeof(PlayerController), "Update");
            if (method == null)
            {
                // Если метод не найден, добавьте здесь дополнительную логику поиска
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
        public static void UpdateStamina(Flashlight __instance)
        {
            // Проверяем, существует ли поле maxOxygen в Player.PlayerData
            var maxOxygenField = AccessTools.Field(typeof(Player.PlayerData), "maxOxygen");
            if (maxOxygenField != null)
            {
                // Устанавливаем значение remainingOxygen на 0f
                AccessTools.Field(typeof(PlayerController), "maxStamina").SetValue(__instance, 10000f);
            }
        }
    }
}
