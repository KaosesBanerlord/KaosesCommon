using KaosesCommon.Objects;
using KaosesCommon.Settings;
//using KaosesCommon.Utils;

namespace KaosesCommon
{
    /// <summary>
    /// Internal class to initialize the mod settings class from MCM and to set the IM and Logger variables 
    /// </summary>
    internal class Init
    {
        public Init()
        {
            /// Load the Settings Object
            KCConfig settings = KCFactory.Settings;
        }
    }
}
