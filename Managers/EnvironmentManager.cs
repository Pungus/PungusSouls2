using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace PungusSouls
    
{
    public class EnvironmentManager
    {
        public static EnvSetup newEnv = new EnvSetup(); //Assembly_Valheim
        public static GameObject clearCloudsCopy;
        [HarmonyPatch(typeof(EnvMan), nameof(EnvMan.Awake))]
        private static class EnvMan_Awake_Patches
        {
            public static void Postfix(EnvMan __instance)
            {
                __instance.m_environments.Add(newEnv);
                if (clearCloudsCopy == null)
                    foreach (var env in __instance.m_environments)
                    {
                        if (env.m_name == "clear")
                            {
                                clearCloudsCopy = Object.Instantiate(env.m_psystems[0]);
                                newEnv.m_psystems = new GameObject[] { clearCloudsCopy };
                                break;
                            }
                    }
                __instance.InitializeEnvironment(newEnv);
                InitEnvSetup();
            }
        }
        public static void InitEnvSetup()
        {
            newEnv.m_name = "FirelinkShrine";
            newEnv.m_ambColorDay = new Color(0f, 1f, .3f, 1f);
            newEnv.m_ambColorNight = new Color(0f, 1f, .3f, 1f);
            newEnv.m_sunColorDay = new Color(0f, 1f, 0f, 1f);
            newEnv.m_sunColorEvening = new Color(0f, .5f, 0f, 1f);
            newEnv.m_sunColorMorning = new Color(0f, .5f, 0f, 1f);
            newEnv.m_sunColorNight = new Color(0f, .1f, 0f, 1f);
        }
    }
}
