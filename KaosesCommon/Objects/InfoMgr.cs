using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaleWorlds.Engine;
using TaleWorlds.Library;

/**
 * color codes https://cssgenerator.org/rgba-and-hex-color-generator.html
 * color codes https://quantdev.ssri.psu.edu/sites/qdev/files/Tutorial_ColorR.html
 */
namespace KaosesCommon.Objects
{

    /// <summary>
    /// Kaoses Message Class to handle the showing of messages and message boxes
    /// </summary>
    /// <example>
    /// Set the Message values for use.
    /// <code>
    /// using KaosesCommon.Utils;
    /// 
    /// string ModuleId = "KaosesTradeGoods";
    /// string modulePath = @"..\\..\\Modules\\" + ModuleId + "\\";
    /// string ModVersion = "1.0.0"
    /// 
    /// logToFile = true;
    /// IsDebug = true;
    /// ModVersion = ModVersion;
    /// PrePrend = ModuleId;
    /// </code>
    /// Display Message
    /// <code>
    /// using KaosesCommon.Utils;
    /// 
    /// MessageModLoaded();
    /// MessageError("Test Error");
    /// ShowMessageBox("test message for display", "Message Box Title");
    /// ShowError(Exception ex);
    /// </code>
    /// </example>
    public class InfoMgr
    {
        /// <summary>
        ///  Bool To specify if messages should be logged to file by default
        /// </summary>
        private bool _logToFile = false;
        /// <summary>
        /// Bool To specify if the system is in debug mode. Affects debug messages
        /// </summary>
        private bool _IsDebug = false;
        /// <summary>
        /// The module string Id eg. Bannerlord.Harmony
        /// </summary>
        private string? _ModuleId = null;
        /// <summary>
        /// Template string for logging to the log file inside the module folder
        /// </summary>
        private string? _modulepath = null;

        /// <summary>
        /// Private variable to hold the log file to be used
        /// </summary>
        protected string? _logFile = null;
        /// <summary>
        /// Private variable to hold the log file to be used
        /// </summary>
        protected string? _exceptionLogFile = null;
        /// <summary>
        /// The file name for logs
        /// </summary>
        protected string _logFileName = "log.txt";
        /// <summary>
        /// The file name for exception logs
        /// </summary>
        protected string _exceptionLogFileName = "exceptions.txt";

        /// <summary>
        /// String to be pre pended to displayed messages,  by default the value is null and is only prepended to messages if it is not null
        /// </summary>
        public string? PrePrend = null;
        /// <summary>
        /// String representation of the module version for use in logs and messages
        /// </summary>
        public string ModVersion = "";
        /// <summary>
        /// Log file path override, if this is set to a full directory path then the logs 
        /// will be written to it instead of to the module folder.
        /// </summary>
        public string? LogFilePath = null;
        /// <summary>
        /// Bool to set if date time is to be added to each log line
        /// </summary>
        public bool AddDateTimeToLog = false;



        public InfoMgr(bool isDebug, bool logToFile, string ModId, string modulePath)
        {
            _logToFile = logToFile;
            _IsDebug = isDebug;
            _ModuleId = ModId;
            _modulepath = modulePath;

            BuildLogFilePaths();

            WriteLogFile2("InfoMgr Constructor:");
            WriteLogFile2("logToFile: " + _logToFile);
            WriteLogFile2("isDebug: " + _IsDebug);
            WriteLogFile2("ModId: " + _ModuleId);
            WriteLogFile2("modulePath: " + _modulepath);
            WriteLogFile2("_logFile: " + _logFile);
            WriteLogFile2("_exceptionLogFile: " + _exceptionLogFile);

        }


        /// <summary>
        /// Lazy Mod loaded message, color is set to green.
        /// </summary>
        public void MessageModLoaded()
        {
            MessageGreen("Loaded");
        }

        /// <summary>
        /// Lazy helper method for harmony isn't loaded, color is set to red
        /// </summary>
        public void MessageHarmonyLoadError()
        {
            MessageRed("Mod Will not function properly with out Harmony");
        }

        /// <summary>
        /// Lazy Helper to show Mod and game version info.
        /// </summary>
        public void MessageModInfo()
        {
            MessageYellow("Mod Id: " + _ModuleId);
            //MessageYellow("Prepend: " + PrePrend);
            MessageYellow("Mod Version: " + ModVersion);
            MessageYellow("Game Version: " + EngineController.GetVersionStr());
            ModInfoDebug();
        }

        /// <summary>
        /// Helper method for error messages, automatically sets the message color to red.
        /// Also calls log message directly
        /// </summary>
        /// <param name="message">string, message to display</param>
        public void MessageError(string message)
        {
            DisplayMessage(message, Color.ConvertStringToColor("#FF000000"), false);
            logMessage(message);
        }

        /// <summary>
        /// Helper method to show information messages color is green.
        /// </summary>
        /// <param name="message">string, message to display</param>
        public void MessageInfo(string message)
        {
            MessageGreen(message);
        }

        /// <summary>
        /// Helper method to show messages in red.
        /// </summary>
        /// <param name="message">string, message to display</param>
        public void MessageRed(string message)
        {
            DisplayMessage(message, Color.ConvertStringToColor("#FF0042FF"), _logToFile);
        }

        /// <summary>
        /// Helper method to show messages in green.
        /// </summary>
        /// <param name="message">string, message to display</param>
        public void MessageGreen(string message)
        {
            DisplayMessage(message, Color.ConvertStringToColor("#42FF00FF"), _logToFile);
        }

        /// <summary>
        /// Helper method to show messages in blue.
        /// </summary>
        /// <param name="message">string, message to display</param>
        public void MessageBlue(string message)
        {
            DisplayMessage(message, Color.ConvertStringToColor("#0042FFFF"), _logToFile);
        }

        /// <summary>
        /// Helper method to show messages in orange.
        /// </summary>
        /// <param name="message">string, message to display</param>
        public void MessageOrange(string message)
        {
            DisplayMessage(message, Color.ConvertStringToColor("#00F16D26"), _logToFile);
        }

        /// <summary>
        /// Helper method to show messages in yellow.
        /// </summary>
        /// <param name="message">string, message to display</param>
        public void MessageYellow(string message)
        {
            DisplayMessage(message, Color.ConvertStringToColor("#E6FF00FF"), _logToFile);
        }

        /// <summary>
        /// Helper method to show debug messages color is Yellow. Messages are only show when IsDebug is set to true
        /// </summary>
        /// <param name="message">string, message to display</param>
        public void MessageDebug(string message)
        {
            if (_IsDebug)
            {
                MessageYellow(message);
            }
        }

        /// <summary>
        /// Shows a Bannerlord message box with the specified tittle and message
        /// </summary>
        /// <param name="message">string, message to display</param>
        /// <param name="title">string, title for the showm message box</param>
        public void ShowMessageBox(string message, string title = "")
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                title = "";
            }
            if (_logToFile)
            {
                logMessage(title + "\n" + message);
            }
            MessageBox.Show(message, title);
        }

        /// <summary>
        /// Shows a Bannerlord message box for errors. 
        /// If title is null or empty the title is set to 'Exception'
        /// By default will show version info 
        /// </summary>
        /// <param name="exception">Exception object</param>
        /// <param name="title">string, title for the showm message box</param>
        /// <param name="ShowVersionsInfo">bool, set to show the module and game version, default is true</param>
        public void ShowError(Exception? exception = null, string title = "", bool ShowVersionsInfo = true)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                title = "Exception:";
            }

            string message = "\n\n" + GetString(exception);
            if (ShowVersionsInfo)
            {
                message += "\n\nGameVersion: " + EngineController.GetVersionStr() + "\nModVersion: " + ModVersion;
            }
            LmException(message);
            //logMessage(title + "\n" + message);
            ShowMessageBox(message, title);
        }

        /// <summary>
        /// Method to show messages in Bannerlord
        /// </summary>
        /// <param name="message">string, message to display</param>
        /// <param name="messageColor">string, color for message</param>
        /// <param name="logToFile">bool, set toi log message to file</param>
        private void DisplayMessage(string message, Color messageColor, bool logToFile = false)
        {


            string fullMessage = message;
            if (!string.IsNullOrWhiteSpace(PrePrend))
            {
                fullMessage = PrePrend + " : " + message;
            }

            try
            {

                if (logToFile)
                {
                    logMessage(fullMessage);
                }
                InformationManager.DisplayMessage(new InformationMessage(fullMessage, messageColor));
            }
            catch (Exception ex)
            {
                logMessage("messageStrLength: " + fullMessage.Length);
                logMessage("messageStr: " + fullMessage);
                logMessage(GetString(ex));
            }

        }

        /// <summary>
        /// Wrapper method to send messages to the log if logging is true
        /// </summary>
        /// <param name="message">string, messagre to log to file</param>
        private void logMessage(string message)
        {
            Lm(message);
        }

        /// <summary>
        /// Private method to get the exception as string for showing and logging
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private string GetString(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            GetStringRecursive(ex, sb);
            sb.AppendLine();
            sb.AppendLine("Stack trace:");
            sb.AppendLine(ex.StackTrace);
            return sb.ToString();
        }

        /// <summary>
        /// Private method used by GetString to handle getting the exception info as string
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="sb"></param>
        private void GetStringRecursive(Exception ex, StringBuilder sb)
        {
            while (true)
            {
                sb.AppendLine(ex.GetType().Name + ":");
                sb.AppendLine(ex.Message);
                if (ex.InnerException == null)
                {
                    return;
                }

                sb.AppendLine();
                ex = ex.InnerException;
            }
        }

        /// <summary>
        /// Log message string to the log file
        /// </summary>
        /// 
        /// <param name="message">string, the string message to log</param>
        public void Lm(string message)
        {
            WriteLogFile(_logFile, message);
        }

        /// <summary>
        /// Helper method to log exceptions to default exceptions log
        /// </summary>
        /// <param name="message">string, the string message to log</param>
        public void LmException(string message)
        {
            //string lf = GetLogFilePath(true);
            WriteLogFile(_exceptionLogFile, message);
        }

        /// <summary>
        /// Quick method to log game and mod version to log file
        /// </summary>
        public void ModInfoDebug()
        {
            Lm("Mod Id: " + _ModuleId);
            Lm("Mod Version: " + ModVersion);
            Lm("Game Version: " + EngineController.GetVersionStr());
            //Lm("Prepend: " + PrePrend);
        }

        /// <summary>
        /// Quick method to log loaded mods and their version to the log file
        /// </summary>
        public void ModDebugLoadedModsInfo()
        {
            Lm("Mods Info: ");
            Lm(EngineController.GetModulesVersionStr());
        }

        /// <summary>
        /// Returns the log file path
        /// </summary>
        /// <param name="ForExceptions">bool, set if its for exceptions log file</param>
        /// <returns>string, file path to log file</returns>
        public void BuildLogFilePaths(bool ForExceptions = false)
        {
            if (!string.IsNullOrWhiteSpace(LogFilePath))
            {
                if (CheckOverRidePath())
                {
                    _logFile = LogFilePath;
                    _exceptionLogFile = LogFilePath;
                }
            }
            else if (CheckLogPath())
            {
                _exceptionLogFile = _modulepath + _exceptionLogFileName;
                _logFile = _modulepath + _logFileName;
            }
        }

        /// <summary>
        /// Private method to write info to the specified log file
        /// </summary>
        /// <param name="logFile"></param>
        /// <param name="message"></param>
        private void WriteLogFile(string logFile, string message)
        {

            try
            {
                using StreamWriter sw = File.AppendText(logFile);
                if (!string.IsNullOrWhiteSpace(PrePrend))
                {
                    message = PrePrend + " : " + message;
                }
                if (AddDateTimeToLog)
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
        private void WriteLogFile2(string message)
        {
            try
            {
                string useLogFile = "U:\\BannerLord\\MyMods\\KaosesCommon\\logfile.text";
                using StreamWriter sw = File.AppendText(useLogFile);
                if (AddDateTimeToLog)
                {
                    message = DateTime.Now.ToString() + " : " + message;
                }
                if (!string.IsNullOrWhiteSpace(PrePrend))
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
        private bool CheckOverRidePath()
        {
            return Directory.Exists(LogFilePath);
        }

        /// <summary>
        /// Private method to check if variables have been set correctly for the log path
        /// </summary>
        /// <returns>bool</returns>
        private bool CheckLogPath()
        {
            //WriteLogFile2("", "GetLogFilePath: CheckLogPath called");
            //return true;
            if (CheckModuleFolderPath())
            {
                return true;
            }
            else
            {
                ShowModuleFolderErrorBox();
            }
            return false;
        }

        /// <summary>
        /// Private method to check if variables have been set correctly and the module folder exists
        /// </summary>
        /// <returns>bool</returns>
        private bool CheckModuleFolderPath()
        {
            return Directory.Exists(_modulepath);
        }

        /// <summary>
        /// Private method to show a error message box if the logging is not setup correctly
        /// </summary>
        private void ShowModuleFolderErrorBox()
        {
            WriteLogFile2("Module Folder not set correctly" + _modulepath);
            //ShowMessageBox("Module Folder not set correctly" + _modulepath, "LogFilePathTemplate cant be found");
        }


    }
}
