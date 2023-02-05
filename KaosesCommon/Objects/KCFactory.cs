using KaosesCommon.Settings;
using System.Reflection;
using System.Runtime;
using TaleWorlds.Library;

namespace KaosesCommon.Objects
{

    public static class KCFactory
    {
        private static KCConfig? _settings = null;

        public static bool MCMModuleLoaded { get; set; } = false;

        public static KCConfig Settings
        {
            get
            {
                if (_settings == null)
                {
                    _settings = new KCConfig();
                    if (_settings is null)
                    {
                        InformationManager.DisplayMessage(new InformationMessage("Failed to load any config provider"));
                    }
                }
                return _settings;
            }
            set
            {
                _settings = value;
            }
        }

        private static string ConfigFilePath
        {

            get
            {
                return @"..\\..\\Modules\\" + SubModule.ModuleId + "\\config.json";
            }
            //set {  = value; }

        }
        public static string ModVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        #region MCMConfigValues
        //public static string? MCMConfigFolder { get; set; }
        //public static string? MCMConfigFile { get; set; }
        //public static bool MCMConfigFileExists { get; set; } = false;
        //public static bool MCMModuleLoaded { get; set; } = false;
        //public static bool ModConfigFileExists { get; set; } = false;
        #endregion

    }
}
