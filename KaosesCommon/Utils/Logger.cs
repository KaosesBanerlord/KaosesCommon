using System;
using System.IO;
using TaleWorlds.Engine;

namespace KaosesCommon.Utils
{
    /// <summary>
    /// Kaoses Logger class to handle the logging of info to file
    /// 
    /// <example>
    /// Set the Logger values for use.
    /// <code>
    /// using KaosesCommon.Utils;
    /// 
    /// string ModuleId = "KaosesTradeGoods";
    /// string modulePath = @"..\\..\\Modules\\" + ModuleId + "\\";
    /// 
    /// Logger.ModuleId = ModuleId;
    /// Logger._modulepath = modulePath;
    /// </code>
    /// </example>
    /// <example>
    /// Log message to file
    /// <code>
    /// using KaosesCommon.Utils;
    /// 
    /// Logger.Lm = "Test log message";
    /// </code>
    /// </example>
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// The module string Id eg. Bannerlord.Harmony
        /// </summary>
        public static string? ModuleId = null;

        /// <summary>
        /// Message prepend string fro pre pending to log lines. Can be left as null for no prepend
        /// </summary>
        public static string? PrePrend = null;

        /// <summary>
        /// Log file path override, if this is set to a full directory path then the logs 
        /// will be written to it instead of to the module folder.
        /// </summary>
        public static string? LogFilePath = null;

        /// <summary>
        /// Bool to set if date time is to be added to each log line
        /// </summary>
        public static bool addDateTimeToLog = false;

        /// <summary>
        /// Template string for logging to the log file inside the module folder
        /// </summary>
        public static string? _modulepath = null;

        /// <summary>
        /// Private variable to hold the log file to be used
        /// </summary>
        private static string? _logFile = null;

        /// <summary>
        /// Private variable to hold the log file to be used
        /// </summary>
        private static string? _exceptionLogFile = null;

        /// <summary>
        /// The file name for logs
        /// </summary>
        private static string _logFileName = "log.txt";

        /// <summary>
        /// The file name for exception logs
        /// </summary>
        private static string _exceptionLogFileName = "exceptions.txt";

        /// <summary>
        /// Log message string to the log file
        /// </summary>
        /// 
        /// <param name="message">string, the string message to log</param>
        public static void Lm(string message)
        {
            string lf = Logger.GetLogFilePath();
            Logger.WriteLogFile(lf, message);
        }

        /// <summary>
        /// Helper method to log exceptions to default exceptions log
        /// </summary>
        /// <param name="message">string, the string message to log</param>
        public static void LmException(string message)
        {
            string lf = Logger.GetLogFilePath(true);
            Logger.WriteLogFile(lf, message);
        }

        /// <summary>
        /// Quick method to log game and mod version to log file
        /// </summary>
        public static void ModInfoDebug()
        {
            Lm("Mod Id: " + Logger.ModuleId);
            Lm("Mod Version: " + IM.ModVersion);
            Lm("Game Version: " + EngineController.GetVersionStr());
            //Lm("Prepend: " + IM.PrePrend);
        }

        /// <summary>
        /// Quick method to log loaded mods and their version to the log file
        /// </summary>
        public static void ModDebugLoadedModsInfo()
        {
            Lm("Mods Info: ");
            Lm(EngineController.GetModulesVersionStr());
        }

        /// <summary>
        /// Returns the log file path
        /// </summary>
        /// <param name="ForExceptions">bool, set if its for exceptions log file</param>
        /// <returns>string, file path to log file</returns>
        public static string GetLogFilePath(bool ForExceptions = false)
        {
            if (ForExceptions)
            {
                if (_exceptionLogFile != null)
                {
                    return _exceptionLogFile;
                }
            }
            else
            {
                if (_logFile != null)
                {
                    return _logFile;
                }
            }
            if (!string.IsNullOrWhiteSpace(LogFilePath))
            {
                if (Logger.CheckOverRidePath())
                {
                    _logFile = LogFilePath;
                }
            }
            else if (Logger.CheckLogPath())
            {
                if (ForExceptions)
                {
                    _exceptionLogFile = _modulepath + _exceptionLogFileName;
                    return _exceptionLogFile;
                }
                else
                {
                    _logFile = _modulepath + _logFileName;
                }
            }
            return _logFile;
        }

        /// <summary>
        /// Private method to write info to the specified log file
        /// </summary>
        /// <param name="logFile"></param>
        /// <param name="message"></param>
        private static void WriteLogFile(string logFile, string message)
        {
            
            try
            {
                using StreamWriter sw = File.AppendText(logFile);
                if (!string.IsNullOrWhiteSpace(Logger.PrePrend))
                {
                    message = PrePrend + " : " + message;
                }
                if (addDateTimeToLog)
                {
                    message = DateTime.Now.ToString() + " : " + message;
                }
                sw.WriteLine(message);
            }
            catch
            {

            }
        }

        /// <summary>
        /// Private method to write info to the specified log file
        /// </summary>
        /// <param name="logFile"></param>
        /// <param name="message"></param>
        private static void WriteLogFile2(string logFile, string message)
        {
            try
            {
                string useLogFile = "U:\\BannerLord\\MyMods\\KaosesCommon\\logfile.text";
                using StreamWriter sw = File.AppendText(useLogFile);
                if (addDateTimeToLog)
                {
                    message = DateTime.Now.ToString() + " : " + message;
                }
                if (!string.IsNullOrWhiteSpace(Logger.PrePrend))
                {
                    message = PrePrend + " : " + message;
                }
                sw.WriteLine(message);
            }
            catch
            {

            }
        }

        /// <summary>
        /// Check if override path exists
        /// </summary>
        /// <returns>bool</returns>
        private static bool CheckOverRidePath()
        {
            return Directory.Exists(LogFilePath);
        }

        /// <summary>
        /// Private method to check if variables have been set correctly for the log path
        /// </summary>
        /// <returns>bool</returns>
        private static bool CheckLogPath()
        {
            //WriteLogFile2("", "GetLogFilePath: CheckLogPath called");
            //return true;
            if (Logger.CheckModuleFolderPath())
            {
                return true;
            }
            else
            {
                Logger.ShowModuleFolderErrorBox();
            }
            return false;
        }

        /// <summary>
        /// Private method to check if variables have been set correctly and the module folder exists
        /// </summary>
        /// <returns>bool</returns>
        private static bool CheckModuleFolderPath()
        {
            return Directory.Exists(_modulepath);
        }

        /// <summary>
        /// Private method to show a error message box if the logging is not setup correctly
        /// </summary>
        private static void ShowModuleFolderErrorBox()
        {
            IM.ShowMessageBox("Module Folder not set correctly", "LogFilePathTemplate cant be found" + _modulepath);
        }

    }
}
