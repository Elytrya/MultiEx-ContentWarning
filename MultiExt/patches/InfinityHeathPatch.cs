using HarmonyLib;
using System.Reflection;

namespace MultiEx.Patches
{
    [HarmonyPatch(typeof(Player.PlayerData))]
    public static class InfinityHeathPatch
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
        public static void UpdateInfinityHeath(Player.PlayerData __instance)
        {
            // Проверяем, существует ли поле maxOxygen в Player.PlayerData
            var health = AccessTools.Field(typeof(Player.PlayerData), "health");
            if (health != null)
            {
                //                // Устанавливаем значение health на 1000f
                AccessTools.Field(typeof(Player.PlayerData), "health").SetValue(__instance, 1000f);
            }
        }
    }
}
