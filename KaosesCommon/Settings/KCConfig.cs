using System.Collections.Generic;
using TaleWorlds.Localization;

//using MCM.Abstractions.Settings.Base.PerSave;


namespace KaosesCommon.Settings
{
    //public class Settings : AttributePerSaveSettings<Settings>, ISettingsProviderInterface
    public class KCConfig //: AttributeGlobalSettings<Config>
    {
        /// <summary>
        /// Constructor
        /// </summary>


        #region ModSettingsStandard
        public string Id => SubModule.ModuleId;
        public string FolderName => SubModule.ModuleId;
        public string ModName => "Kaoses Common";
        public string FormatType => "json";
        #region Translatable DisplayName 
        // Build mod display name with name and version form the project properties version
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the null ability of reference types.
        TextObject versionTextObj = new TextObject(typeof(KCConfig).Assembly.GetName().Version?.ToString(3) ?? "");
        public string DisplayName => new TextObject("{=KaosesCommonDisplayName}" + ModName + " " + versionTextObj.ToString())!.ToString();
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the null ability of reference types.
        #endregion
        public string ModDisplayName { get { return DisplayName; } }
        #endregion

        #region Debug

        //[SettingPropertyBool("{=debug}Debug", RequireRestart = false, HintText = "{=debug_desc}Displays mod developer debug information and logs them to the file")]
        //[SettingPropertyGroup("Debug", GroupOrder = 1)]
#if DEBUG
        public bool Debug { get; set; } = true;
#else
        public bool Debug { get; set; } = false;
#endif
        //[SettingPropertyBool("{=debuglog}Log to file", RequireRestart = false, HintText = "{=debuglog_desc}Log information messages to the log file as well as errors and debug")]
        //[SettingPropertyGroup("Debug", GroupOrder = 2)]
#if DEBUG
        public bool LogToFile { get; set; } = true;
#else
        public bool LogToFile { get; set; } = false;
#endif


        //[SettingPropertyBool("{=debugharmony}Debug Harmony", RequireRestart = false, HintText = "{=debugharmony_desc}Enable/Disable harmony's debuging logs")]
        //[SettingPropertyGroup("Debug", GroupOrder = 2)]
#if DEBUG
        public bool IsHarmonyDebug { get; set; } = true;
#else
        public bool IsHarmonyDebug { get; set; } = false;
#endif


        #endregion //~Debug


        ///~ Mod Specific settings 
        #region Mod Specific settings
        //[SettingPropertyBool("{=Name_bool}Name_bool", Order = 0, RequireRestart = false, HintText = "{=Bool_explanation}Bool_explanation.")]
        //[SettingPropertyGroup("Main_Group/Nested_Group/Second_Nested")]
        public bool boolVariable { get; set; } = true;

        // Value is displayed as "X Denars"
        //[SettingPropertyInteger("Name_Int", 0, 100, "0 Denars", Order = 1, RequireRestart = false, HintText = "Int_explanation.")]
        //[SettingPropertyGroup("Main_Group/Nested_Group/Second_Nested")]
        public int IntVariable { get; set; } = 25;

        // Value is displayed as a percentage
        //[SettingPropertyFloatingInteger("Name_Float", 0.0f, 1.0f, "#0%", Order = 2, RequireRestart = false, HintText = "Float_explanation.")]
        //[SettingPropertyGroup("Main_Group/Nested_Group/Second_Nested")]
        public float FloatVariable { get; set; } = 0.75f;

        // Value is displayed as a string
        //[SettingPropertyText("Name_String", Order = 3, RequireRestart = false, HintText = "String_Explanation")]
        //[SettingPropertyGroup("Main_Group/Nested_Group/Second_Nested")]
        public string StringVariable { get; set; } = "The_textbox_data_here";

        #endregion

    }
}
