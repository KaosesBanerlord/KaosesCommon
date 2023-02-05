using KaosesCommon.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Engine;

namespace KaosesCommon
{

    /// <summary>
    /// Kaoses Helper methods
    /// </summary>
    public class Kaoses
    {
        /// <summary>
        /// New instance of Class Random.Random
        /// </summary>
        public static Random rand = new Random();

        /// <summary>
        /// Helper method to check if MCM is a loaded mod
        /// </summary>
        /// <returns>bool</returns>
        public static bool IsMCMLoaded()
        {
            bool loaded = false;
            var modnames = Utilities.GetModulesNames().ToList();
            if (modnames.Contains("Bannerlord.MBOptionScreen"))// && !overrideSettings
            {
                //Statics.MCMModuleLoaded = true;
                loaded = true;
                IM.MessageDebug("MCM Module is loaded");
            }
            return loaded;
        }

        /// <summary>
        /// Helper methods to check if Kaoses Party Sizes is loaded
        /// </summary>
        /// <returns>bool</returns>
        public static bool IsKaosesPartySizesLoaded()
        {
            bool loaded = false;
            var modnames = Utilities.GetModulesNames().ToList();
            if (modnames.Contains("KaosesPartySizes"))// && !overrideSettings
            {
                //Statics.MCMModuleLoaded = true;
                loaded = true;
                IM.MessageDebug("Check: KaosesPartySizes Module is loaded");
            }
            return loaded;
        }

        /// <summary>
        /// Helper methods to check if Kaoses Party Speeds is loaded
        /// </summary>
        /// <returns>bool</returns>
        public static bool IsKaosesPartySpeedsLoaded()
        {
            bool loaded = false;
            var modnames = Utilities.GetModulesNames().ToList();
            if (modnames.Contains("KaosesPartySpeeds"))// && !overrideSettings
            {
                //Statics.MCMModuleLoaded = true;
                loaded = true;
                IM.MessageDebug("Check: KaosesPartySpeeds Module is loaded");
            }
            return loaded;
        }
        /// <summary>
        /// Helper methods to check if Kaoses Projectiles is loaded
        /// </summary>
        /// <returns>bool</returns>
        public static bool IsKaosesProjectilesLoaded()
        {
            bool loaded = false;
            var modnames = Utilities.GetModulesNames().ToList();
            if (modnames.Contains("KaosesProjectiles"))// && !overrideSettings
            {
                //Statics.MCMModuleLoaded = true;
                loaded = true;
                IM.MessageDebug("Check: KaosesProjectiles Module is loaded");
            }
            return loaded;
        }
        /// <summary>
        /// Helper methods to check if Kaoses Trade Goods is loaded
        /// </summary>
        /// <returns>bool</returns>
        public static bool IsKaosesTradeGoodsLoaded()
        {
            bool loaded = false;
            var modnames = Utilities.GetModulesNames().ToList();
            if (modnames.Contains("KaosesTradeGoods"))// && !overrideSettings
            {
                //Statics.MCMModuleLoaded = true;
                loaded = true;
                IM.MessageDebug("Check: KaosesTradeGoods Module is loaded");
            }
            return loaded;
        }

        /// <summary>
        /// Helper methods to check if Kaoses Tweaks is loaded
        /// </summary>
        /// <returns>bool</returns>
        public static bool IsKaosesTweaksLoaded()
        {
            bool loaded = false;
            var modnames = Utilities.GetModulesNames().ToList();
            if (modnames.Contains("KaosesTweaks"))// && !overrideSettings
            {
                //Statics.MCMModuleLoaded = true;
                loaded = true;
                IM.MessageDebug("Check: KaosesTweaks Module is loaded");
            }
            return loaded;
        }

        /// <summary>
        /// Helper methods to check if Kaoses Wages is loaded
        /// </summary>
        /// <returns>bool</returns>
        public static bool IsKaosesWagesLoaded()
        {
            bool loaded = false;
            var modnames = Utilities.GetModulesNames().ToList();
            if (modnames.Contains("KaosesWages"))// && !overrideSettings
            {
                //Statics.MCMModuleLoaded = true;
                loaded = true;
                IM.MessageDebug("Check: KaosesWages Module is loaded");
            }
            return loaded;
        }

        /// <summary>
        /// Helper method to check if a specific module is loaded by ModuleId
        /// </summary>
        /// <param name="moduleId">string module ID eg. Bannerlord.Harmony</param>
        /// <param name="showDebugMessage">bool set if debug messages are to be shown</param>
        /// <returns>bool</returns>
        public static bool IsModuleLoaded(string moduleId, bool showDebugMessage = false)
        {
            bool loaded = false;
            var modnames = Utilities.GetModulesNames().ToList();
            if (modnames.Contains(moduleId))// && !overrideSettings
            {
                //Statics.MCMModuleLoaded = true;
                loaded = true;
                if (showDebugMessage)
                {
                    IM.MessageDebug($"{moduleId} Module is loaded");
                }

            }
            return loaded;
        }

        /// <summary>
        /// Helper method to check if Harmony Module is loaded
        /// </summary>
        /// <returns>bool</returns>
        public static bool IsHarmonyLoaded()
        {
            bool loaded = false;
            var modnames = Utilities.GetModulesNames().ToList();
            //if (modnames.Contains("ModLib") && !overrideSettings)
            if (modnames.Contains("Bannerlord.Harmony"))// && !overrideSettings
            {
                loaded = true;
                //IM.MessageDebug("Harmony Module is loaded");
            }
            else
            {
                IM.MessageError("Requires Harmony please install the Harmony mod");
            }
            return loaded;
        }

        private static void CheckMcmConfig()
        {
            /*
                        string RootFolder = System.IO.Path.Combine(FSIOHelper.GetConfigPath(), "ModSettings/Global/" + Statics.ModuleFolder);
                        if (System.IO.Directory.Exists(RootFolder))
                        {
                            //Statics.MCMConfigFolder = RootFolder;
                            string fileLoc = System.IO.Path.Combine(RootFolder, Statics.ModuleFolder + ".json");
                            if (System.IO.File.Exists(fileLoc))
                            {
                                //Statics.MCMConfigFileExists = true;
                                //Statics.MCMConfigFile = fileLoc;
                                //IM.MessageDebug(logPreppend + "MCM Module Config file found");
                            }
                        }*/
        }
        private static void CheckModConfig(string ConfigFilePath)
        {
            if (File.Exists(ConfigFilePath))
            {
                //Statics.ModConfigFileExists = true;
                IM.MessageDebug("Config File FOUND");
            }
        }
        private static void LoadModConfigFile()
        {
            /*
                        Settings.Instance = new Settings();
                        if (Settings.Instance is not null)
                        {
                            IM.MessageDebug(logPreppend + "Settings.Instance is not null");
                            if (File.Exists(Statics.ConfigFilePath))
                            {
                                IM.MessageDebug(logPreppend + "Config file exists " + Statics.ConfigFilePath.ToString());
                                Settings config = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(Statics.ConfigFilePath));
                                Settings.Instance = config;
                            }

                            if (Settings.Instance.LoadMCMConfigFile && Statics.MCMConfigFileExists)
                            {
                                Settings config = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(Statics.MCMConfigFile));
                                Settings.Instance = config;
                            }
                        }
                        Statics._settings = Settings.Instance;*/

        }
    }
}
