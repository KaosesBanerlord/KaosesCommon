//using MCM.Abstractions.Settings.Base.PerSave;
using TaleWorlds.Localization;


namespace KaosesCommon.Settings
{
    //public class MCMSettings : AttributePerSaveSettings<MCMSettings>, ISettingsProviderInterface
    //public class MCMSettings : AttributeGlobalSettings<MCMSettings>, ISettingsProviderInterface 
    public class MCMSettings //: AttributeGlobalSettings<MCMSettings>
    {



        #region ModSettingsStandard
        public string Id => SubModule.ModuleId;
        #region Translatable DisplayName 
        // Build mod display name with name and version form the project properties version
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the null ability of reference types.
        TextObject versionTextObj = new TextObject(typeof(MCMSettings).Assembly.GetName().Version?.ToString(3) ?? "");
        public string DisplayName => new TextObject("{=KaosesCommonDisplayName}" + SubModule.DisplayName + " " + versionTextObj.ToString())!.ToString();
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the null ability of reference types.
        #endregion
        public string FolderName => SubModule.ModuleId;
        public string FormatType => "json";

        public string ModDisplayName { get { return DisplayName; } }
        #endregion

        //[SettingPropertyBool("{=debug}Debug", RequireRestart = false, HintText = "{=}{=debug_desc}Displays mod developer debug information and logs them to the file")]
        //[SettingPropertyGroup("Debug", GroupOrder = 100)]
        public bool Debug { get; set; } = false;

        //[SettingPropertyBool("{=debuglog}Log to file", RequireRestart = false, HintText = "{=}{=debuglog_desc}Log information messages to the log file as well as errors and debug")]
        //[SettingPropertyGroup("Debug", GroupOrder = 100)]
        public bool LogToFile { get; set; } = false;




    }
}
