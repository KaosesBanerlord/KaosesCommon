using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaosesCommon.Helpers
{
    /// <summary>
    /// Contains the static methods and list for working with partyTemplateId's
    /// </summary>
    public class KPartyStringIds
    {

        /// <summary>
        /// List of Nomad party Id's
        /// </summary>
        public static List<string> NomadList = new List<string>()
        {
            "jawwal",
            "karakhuzaits",
            "forest_people",
            "eleftheroi"
        };

        /// <summary>
        /// List of Kingdom Id's
        /// </summary>
        public static List<string> NativeKingdomsList = new List<string>()
        {
            "empire",
            "sturgia",
            "aserai",
            "vlandia",
            "battania",
            "khuzait"
        };

        /// <summary>
        /// List of Calandria Expanded Kingdoms kingdom Id's
        /// </summary>
        public static List<string> CKEKingdomsList = new List<string>()
        {
            "nordling",
            "vagir",
            "rhodok",
            "apolssalian",
            "lyrion",
            "paleician",
            "republic",
            "ariorum"
        };

        /// <summary>
        /// Helper method to check if Kingdom is a native Kingdom faction
        /// </summary>
        /// <param name="stringId">kingdom string id eg. empire</param>
        /// <returns>bool</returns>
        public static bool IsNativeKingdom(string stringId)
        {
            bool isKingdom = false;
            foreach (string kingdom in NativeKingdomsList)
            {
                if (stringId.ToLower().Contains(kingdom))
                {
                    isKingdom = true;
                }
            }
            return isKingdom;
        }

        /// <summary>
        /// Helper method to check if Kingdom is a Caladria Expanded Kingdom faction
        /// </summary>
        /// <param name="stringId">kingdom string id eg. nordling</param>
        /// <returns>bool</returns>
        public static bool IsCKEKingdom(string stringId)
        {
            bool isKingdom = false;
            foreach (string kingdom in CKEKingdomsList)
            {
                if (stringId.ToLower().Contains(kingdom))
                {
                    isKingdom = true;
                }
            }
            return isKingdom;
        }

        /// <summary>
        /// Check if party is a boss party eg. Bandit Boss parties
        /// </summary>
        /// <param name="StringId">string partyId</param>
        /// <returns>bool</returns>
        public static bool IsBossParty(string StringId)
        {
            bool isBoss = false;
            if (StringId.Contains("boss"))
            {
                isBoss = true;
            }
            return isBoss;
        }

        /// <summary>
        /// Check if party is an elite partt eg. Elite Caravans
        /// </summary>
        /// <param name="StringId">string partyId</param>
        /// <returns>bool</returns>
        public static bool IsElite(string stringId)
        {
            return stringId.ToLower().Contains("elite");
        }


    }
}
