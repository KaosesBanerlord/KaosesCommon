using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaleWorlds.Engine;
using TaleWorlds.Library;

/**
 * color codes https://cssgenerator.org/rgba-and-hex-color-generator.html
 * color codes https://quantdev.ssri.psu.edu/sites/qdev/files/Tutorial_ColorR.html
 * 
 * Ux.DisplayMessage("CustomSpawns " + version + " is now enabled. Enjoy! :)", Color.ConvertStringToColor("#001FFFFF"));
 */
namespace KaosesCommon.Utils
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
    /// IM.logToFile = true;
    /// IM.IsDebug = true;
    /// IM.ModVersion = ModVersion;
    /// IM.PrePrend = ModuleId;
    /// </code>
    /// Display Message
    /// <code>
    /// using KaosesCommon.Utils;
    /// 
    /// IM.MessageModLoaded();
    /// IM.MessageError("Test Error");
    /// IM.ShowMessageBox("test message for display", "Message Box Title");
    /// IM.ShowError(Exception ex);
    /// </code>
    /// </example>
    [Obsolete("Use KaosesCommon.Objects.InfoMgr")]
    public class IM
    {
        /// <summary>
        ///  Bool To specify if messages should be logged to file by default
        /// </summary>
        public static bool logToFile = false;

        /// <summary>
        /// Bool To specify if the system is in debug mode. Affects debug messages
        /// </summary>
        public static bool IsDebug = false;

        /// <summary>
        /// String to be pre pended to displayed messages,  by default the value is null and is only prepended to messages if it is not null
        /// </summary>
        public static string? PrePrend = null;

        /// <summary>
        /// String representation of the module version for use in logs and messages
        /// </summary>
        public static string ModVersion = "";

        /// <summary>
        /// Lazy Mod loaded message, color is set to green.
        /// </summary>
        public static void MessageModLoaded()
        {
            IM.MessageGreen("Loaded");
        }

        /// <summary>
        /// Lazy helper method for harmony isn't loaded, color is set to red
        /// </summary>
        public static void MessageHarmonyLoadError()
        {
            IM.MessageRed("Mod Will not function properly with out Harmony");
        }

        /// <summary>
        /// Lazy Helper to show Mod and game version info.
        /// </summary>
        public static void MessageModInfo()
        {
            //IM2.MessageYellow("Mod Id: " + Logger.ModuleId);
            //IM.MessageYellow("Prepend: " + IM.PrePrend);
            IM.MessageYellow("Mod Version: " + ModVersion);
            IM.MessageYellow("Game Version: " + EngineController.GetVersionStr());
            //Logger.ModInfoDebug();
        }

        /// <summary>
        /// Helper method for error messages, automatically sets the message color to red.
        /// Also calls log message directly
        /// </summary>
        /// <param name="message">string, message to display</param>
        public static void MessageError(string message)
        {
            IM.DisplayMessage(message, Color.ConvertStringToColor("#FF000000"), false);
            IM.logMessage(message);
        }

        /// <summary>
        /// Helper method to show information messages color is green.
        /// </summary>
        /// <param name="message">string, message to display</param>
        public static void MessageInfo(string message)
        {
            IM.MessageGreen(message);
        }

        /// <summary>
        /// Helper method to show messages in red.
        /// </summary>
        /// <param name="message">string, message to display</param>
        public static void MessageRed(string message)
        {
            IM.DisplayMessage(message, Color.ConvertStringToColor("#FF0042FF"), logToFile);
        }

        /// <summary>
        /// Helper method to show messages in green.
        /// </summary>
        /// <param name="message">string, message to display</param>
        public static void MessageGreen(string message)
        {
            IM.DisplayMessage(message, Color.ConvertStringToColor("#42FF00FF"), logToFile);
        }

        /// <summary>
        /// Helper method to show messages in blue.
        /// </summary>
        /// <param name="message">string, message to display</param>
        public static void MessageBlue(string message)
        {
            IM.DisplayMessage(message, Color.ConvertStringToColor("#0042FFFF"), logToFile);
        }

        /// <summary>
        /// Helper method to show messages in orange.
        /// </summary>
        /// <param name="message">string, message to display</param>
        public static void MessageOrange(string message)
        {
            IM.DisplayMessage(message, Color.ConvertStringToColor("#00F16D26"), logToFile);
        }

        /// <summary>
        /// Helper method to show messages in yellow.
        /// </summary>
        /// <param name="message">string, message to display</param>
        public static void MessageYellow(string message)
        {
            IM.DisplayMessage(message, Color.ConvertStringToColor("#E6FF00FF"), logToFile);
        }

        /// <summary>
        /// Helper method to show debug messages color is Yellow. Messages are only show when IsDebug is set to true
        /// </summary>
        /// <param name="message">string, message to display</param>
        public static void MessageDebug(string message)
        {
            if (IsDebug)
            {
                IM.MessageYellow(message);
            }
        }

        /// <summary>
        /// Shows a Bannerlord message box with the specified tittle and message
        /// </summary>
        /// <param name="message">string, message to display</param>
        /// <param name="title">string, title for the showm message box</param>
        public static void ShowMessageBox(string message, string title = "")
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                title = "";
            }
            if (logToFile)
            {
                IM.logMessage(title + "\n" + message);
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
        public static void ShowError(Exception? exception = null, string title = "", bool ShowVersionsInfo = true)
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
            //Logger.LmException(message);
            //logMessage(title + "\n" + message);
            ShowMessageBox(message, title);
        }

        /// <summary>
        /// Method to show messages in Bannerlord
        /// </summary>
        /// <param name="message">string, message to display</param>
        /// <param name="messageColor">string, color for message</param>
        /// <param name="logToFile">bool, set toi log message to file</param>
        private static void DisplayMessage(string message, Color messageColor, bool logToFile = false)
        {


            string fullMessage = message;
            if (!string.IsNullOrWhiteSpace(IM.PrePrend))
            {
                fullMessage = IM.PrePrend + " : " + message;
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
                logMessage(IM.GetString(ex));
            }

        }

        /// <summary>
        /// Wrapper method to send messages to the log if logging is true
        /// </summary>
        /// <param name="message">string, messagre to log to file</param>
        private static void logMessage(string message)
        {
            //Logger.Lm(message);
        }

        /// <summary>
        /// Private method to get the exception as string for showing and logging
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private static string GetString(Exception ex)
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
        private static void GetStringRecursive(Exception ex, StringBuilder sb)
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
        /// Helper method to get an exception as string
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        //private static string ToStringFull(Exception ex) => ex != null ? GetString(ex) : "";



    }
}
