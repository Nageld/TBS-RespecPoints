using BepInEx;
using HarmonyLib;
using Wizards.Perks;

namespace RespecPoints;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    private readonly Harmony harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);

    private void Awake()
    {
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        harmony.PatchAll();
    }

    [HarmonyPatch(typeof(PerkManager))]
    public static class RespecPointsPatch
    {
        [HarmonyPatch("respecPoints", MethodType.Getter)]
        [HarmonyPostfix]
        public static void GetRespecPointsPostfix(ref int __result)
        {
            __result = 10; 
        }
    }
}