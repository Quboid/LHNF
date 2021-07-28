using ColossalFramework;
using ColossalFramework.UI;
using ICities;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LHNF
{
    public class ModInfo : LoadingExtensionBase, IUserMod
    {
        public string Name => "LHNF";
        public string Description => "Left Hand Network Fix";

        public ModInfo()
        {
        }

        public override void OnLevelLoaded(LoadMode mode)
        {
            if (!(mode == LoadMode.LoadGame || mode == LoadMode.NewGame || mode == LoadMode.NewGameFromScenario || mode == LoadMode.LoadScenario || mode == LoadMode.NewMap || mode == LoadMode.LoadMap))
            {
                Debug.Log($"LHNF: Aborting because mode={mode}");
                return;
            }

            Lifecycle.InstallMod();
        }

        public override void OnLevelUnloading()
        {
            Lifecycle.UninstallMod();
        }

        //public void OnSettingsUI(UIHelperBase helper)
        //{
        //    UIHelperBase group = helper.AddGroup(Name);

        //    group.AddSpace(10);

        //    ((UIPanel)((UIHelper)group).self).gameObject.AddComponent<OptionsKeymappingMain>();
        //    UIPanel panel = ((UIHelper)group).self as UIPanel;

        //    group.AddSpace(10);
        //}

        internal static bool InGame() => SceneManager.GetActiveScene().name == "Game";

        public void OnEnabled()
        {
            if (InGame())
            {
                Lifecycle.InstallMod();
            }
        }

        public void OnDisabled()
        {
            if (InGame())
            {
                Lifecycle.UninstallMod();
            }
        }
    }
}
