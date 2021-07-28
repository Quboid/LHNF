using CitiesHarmony.API;
using System;
using System.Reflection;
using UnityEngine;

namespace LHNF
{
    class Lifecycle
    {
        public static void InstallMod()
        {
            Debug.Log($"LHNF Mod InstallMod");

            HarmonyHelper.DoOnHarmonyReady(() => Patcher.PatchAll());

            string msg = $"Assemblies:";
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                msg += $"\n{assembly.GetName().Name.ToLower()}";
            }
            Debug.Log(msg);
        }

        public static void UninstallMod()
        {
            Debug.Log($"LHNF Mod UninstallMod");

            if (HarmonyHelper.IsHarmonyInstalled) Patcher.UnpatchAll();
        }
    }
}
