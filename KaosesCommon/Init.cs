using KaosesCommon.Objects;
using KaosesCommon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaosesCommon
{
    internal class Init
    {
        public Init()
        {
            /// Load the Settings Object
            Settings.MCMSettings settings = Factory.Settings;

            ///
            /// Set IM variable values
            ///
            IM.logToFile = settings.LogToFile;
            IM.IsDebug = settings.Debug;
            IM.ModVersion = Factory.ModVersion;

            //Uncomment to have a this prepended to all messages
            //IM.PrePrend = SubModule.ModuleId;

            ///
            /// Set Logger variable values
            ///
            Logger.ModuleId = SubModule.ModuleId;
            Logger._modulepath = SubModule.modulePath;

            ///Uncomment to have a this prepended to log lines
            //Logger.PrePrend = SubModule.ModuleFolder;

            /// Uncomment to have date time added to log lines
            //Logger.addDateTimeToLog = true;

            /// Uncomment to override the log file path
            //Logger.LogFilePath = "U:\\BannerLord\\MyMods\\KaosesCommon\\logfile.text";
        }
    }
}
