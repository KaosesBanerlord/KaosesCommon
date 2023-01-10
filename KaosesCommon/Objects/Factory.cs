using KaosesCommon.Settings;
using KaosesCommon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KaosesCommon.Objects
{

    public static class Factory
    {
        private static MCMSettings? _settings = null;
        //private static Logger _logger = null;
        //private static IM _im = null;


        public static bool MCMModuleLoaded { get; set; } = false;

        public static MCMSettings Settings
        {
            get
            {
                if (_settings == null)
                {
                    _settings = new MCMSettings();
                    if (_settings is null)
                    {
                        IM.ShowMessageBox("Failed to load any config provider", "MCM Error");
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
