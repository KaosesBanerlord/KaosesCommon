using KaosesCommon.Utils;
using System.Reflection;
using System.Runtime;
using System;
using TaleWorlds.MountAndBlade;
using KaosesCommon.Settings;
using KaosesCommon.Objects;

namespace KaosesCommon
{
    public class SubModule : MBSubModuleBase  // Must have a class inheriting MBSubModuleBase, the entry point of the mod
    {
        public const bool UsesHarmony = false;
        public const string ModuleId = "KaosesCommon";
        public const string DisplayName = "Kaoses Common";
        public const string HarmonyId = ModuleId + ".harmony";
        public const string modulePath = @"..\\..\\Modules\\" + ModuleId + "\\";

        public static MCMSettings? _settings;

        //private Harmony? _harmony;

        // Called just before the main menu first appears, helpful if your mod depends on other things being set up during the initial load
        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();
            new Init();
            //IM.MessageModInfo();
            //IM.MessageDebug(ModuleId + " : Mod Logging test");
            try
            {
                //KaosesCommon.Utils.ConfigLoader.LoadConfig();
                //IM.MessageModInfo();
                if (UsesHarmony)
                {
                    //if (KaosesCommon.Kaoses.IsHarmonyLoaded())
                    //{
                        //IM.MessageModLoaded();
                        //try
                        //{
                            //if (_harmony == null)
                            //{
                                //Harmony.DEBUG = true;
//#pragma warning disable CS8602 // Dereference of a possibly null reference.
                                //_harmony = new Harmony(HarmonyId);
                                //_harmony.PatchAll(Assembly.GetExecutingAssembly());
//#pragma warning restore CS8602 // Dereference of a possibly null reference.
                            //}

                        //}
                        //catch (Exception ex)
                        //{
                        //    IM.ShowError(ex, "KaosesTemp Harmony Error:");
                        //}

                    //}
                    //else { IM.MessageHarmonyLoadError(); }
                }
                else
                {
#pragma warning disable CS0162 // Unreachable code detected
                    //IM.MessageModLoaded();
#pragma warning restore CS0162 // Unreachable code detected
                }
            }
            catch (Exception ex)
            {
                IM.ShowError(ex, "initial Loading Error Kaoses Temp");
            }

        }
    }
}