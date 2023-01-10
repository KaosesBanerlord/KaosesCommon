using KaosesCommon.Helpers;
using KaosesCommon.Utils;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;

namespace KaosesCommon.Objects
{
    /// <summary>
    /// Kaoses PartyTemplateObject Parser
    /// </summary>
    public class PartyTemplateParsers
    {
        /// <summary>
        /// PartyTemplateObject holder variable
        /// </summary>
        PartyTemplateObject _pt;

        /// <summary>
        /// Bool set to Build Party Template List 
        /// </summary>
        public bool BuildPartyTemplateList = false;

        /// <summary>
        /// _banditPartyTemplateObjectsList
        /// </summary>
        public Dictionary<string, PartyTemplateObject> _banditPartyTemplateObjectsList;

        /// <summary>
        /// String Id for party
        /// </summary>
        public string partyStringId = "";

        /// <summary>
        /// Bool does the party have a valid partyTemplate
        /// </summary>
        public bool HasValidPartyTemplate = false;

        /// <summary>
        /// Is the party a caravan
        /// </summary>
        public bool IsPlayer = false;

        /// <summary>
        /// Is the party Bandit factions
        /// </summary>
        public bool IsBandit = false;

        /// <summary>
        /// Is the party a caravan
        /// </summary>
        public bool IsCaravan = false;

        /// <summary>
        /// Is the party a elite caravan
        /// </summary>
        public bool IsCaravanElite = false;

        /// <summary>
        /// Is the party a Kingdom 
        /// </summary>
        public bool IsKingdom = false;

        /// <summary>
        /// Is the party a Militia
        /// </summary>
        public bool IsMilitia = false;

        /// <summary>
        /// Is the party a Villager
        /// </summary>
        public bool IsVillager = false;

        /// <summary>
        /// Is the party a Mercenary
        /// </summary>
        public bool IsMercenary = false; //mercenary minor factions

        /// <summary>
        /// Is the party a OutLaw
        /// </summary>
        public bool IsOutLaw = false; //outlaw minor factions 

        /// <summary>
        /// Is the party a Nomad
        /// </summary>
        public bool IsNomad = false; //nomad minor factions

        /// <summary>
        /// Is the party a Rebels
        /// </summary>
        public bool IsRebels = false;

        /// <summary>
        /// Is the party a Looters
        /// </summary>
        public bool IsLooter = false;

        /// <summary>
        /// Is the party a Forest Bandits
        /// </summary>se;
        public bool IsForestBandit = false;

        /// <summary>
        /// Is the party a Forest Bandits Boss
        /// </summary>
        public bool IsForestBanditBoss = false;

        /// <summary>
        /// Is the party a Mountain Bandits
        /// </summary>
        public bool IsMountainBandit = false;

        /// <summary>
        /// Is the party a Mountain Bandits Boss
        /// </summary>
        public bool IsMountainBanditBoss = false;

        /// <summary>
        /// Is the party a Sea Raiders
        /// </summary>
        public bool IsSeaRaiders = false;

        /// <summary>
        /// Is the party a Sea Raiders Boss
        /// </summary>
        public bool IsSeaRaidersBoss = false;

        /// <summary>
        /// Is the party a Steppe Bandits
        /// </summary>
        public bool IsSteppeBandits = false;

        /// <summary>
        /// Is the party a Steppe Bandits Boss
        /// </summary>
        public bool IsSteppeBanditsBoss = false;

        /// <summary>
        /// Is the party a Desert Bandits
        /// </summary>
        public bool IsDesertBandits = false;

        /// <summary>
        /// Is the party a Desert Bandits Boss
        /// </summary>
        public bool IsDesertBanditsBoss = false;

        /// <summary>
        /// Is the party a Deserters
        /// </summary>
        public bool IsDeserters = false;


        /// <summary>
        /// Is the party a Kingdom Native 
        /// </summary>
        public bool IsKingdomNative = false;

        /// <summary>
        /// Is the party a caravan native
        /// </summary>
        public bool IsCaravanNative = false;

        /// <summary>
        /// Is the party a Militia Native
        /// </summary>
        public bool IsMilitiaNative = false;

        /// <summary>
        /// Is the party a Villager Native
        /// </summary>
        public bool IsVillagerNative = false;

        /// <summary>
        /// Is the party a caravan
        /// </summary>
        public bool IsRebelsNative = false;

        /// <summary>
        /// Is the party a Empire Faction
        /// </summary>
        public bool IsEmpire = false;

        /// <summary>
        /// Is the party a Sturgia Faction
        /// </summary>
        public bool IsSturgia = false;

        /// <summary>
        /// Is the party a Aserai Faction
        /// </summary>
        public bool IsAserai = false;

        /// <summary>
        /// Is the party a Vlandia Faction
        /// </summary>
        public bool IsVlandia = false;

        /// <summary>
        /// Is the party a Battania Faction
        /// </summary>
        public bool IsBattania = false;

        /// <summary>
        /// Is the party a Khuzait Faction
        /// </summary>
        public bool IsKhuzait = false;




        /// <summary>
        /// Is the party a caravan Calandria expanded
        /// </summary>
        public bool IsCaravanCKE = false;

        /// <summary>
        /// Is the party a Kingdom Calandria expanded
        /// </summary>
        public bool IsKingdomCKE = false;

        /// <summary>
        /// Is the party a Rebels Calandria expanded
        /// </summary>
        public bool IsRebelsCKE = false;

        /// <summary>
        /// Is the party a Manhunters
        /// </summary>
        public bool IsManhunters = false; //MANHUNTER

        /// <summary>
        /// Is the party a Villager Calandria expanded
        /// </summary>
        public bool IsVillagerCKE = false;

        /// <summary>
        /// Is the party a Militia Calandria expanded
        /// </summary>
        public bool IsMilitiaCKE = false;

        /// <summary>
        /// Is the party a Nordling Faction
        /// </summary>
        public bool IsNordling = false;

        /// <summary>
        /// Is the party a Vagir Faction
        /// </summary>
        public bool IsVagir = false;

        /// <summary>
        /// Is the party a Rhodok Faction
        /// </summary>
        public bool IsRhodok = false;

        /// <summary>
        /// Is the party a Rebkhu Faction
        /// </summary>
        public bool IsRebkhu = false;

        /// <summary>
        /// Is the party a Apolssalian Faction
        /// </summary>
        public bool IsApolssalian = false;

        /// <summary>
        /// Is the party a Lyrion Faction
        /// </summary>
        public bool IsLyrion = false;

        /// <summary>
        /// Is the party a Paleician Faction
        /// </summary>
        public bool IsPaleician = false;

        /// <summary>
        /// Is the party a Republic Faction
        /// </summary>
        public bool IsRepublic = false;

        /// <summary>
        /// Is the party a Ariorum Faction
        /// </summary>
        public bool IsAriorum = false;


        /// <summary>
        /// Is the party a Custom Spawns party
        /// </summary>
        public bool IsCS = false;


        /// <summary>
        /// PartyTemplateParsers
        /// </summary>
        /// <param name="pt">PartyTemplateObject pt</param>
        /// <param name="banditPartyTemplateObjectsList">ref Dictionary<string, PartyTemplateObject> banditPartyTemplateObjectsList</param>
        /// <param name="buildList">bool buildList, default is false</param>
        public PartyTemplateParsers(PartyTemplateObject pt, ref Dictionary<string, PartyTemplateObject> banditPartyTemplateObjectsList, bool buildList = false)
        {
            _pt = pt;
            partyStringId = pt.StringId;
            BuildPartyTemplateList = buildList;
            _banditPartyTemplateObjectsList = banditPartyTemplateObjectsList;
            ParseTemplate();
        }

        /// <summary>
        /// PartyTemplateParsers
        /// </summary>
        /// <param name="stringId">string partyId</param>
        /// <param name="banditPartyTemplateObjectsList">ref Dictionary<string, PartyTemplateObject> banditPartyTemplateObjectsList</param>
        /// <param name="buildList">bool buildList, default is false</param>
        public PartyTemplateParsers(string stringId, ref Dictionary<string, PartyTemplateObject> banditPartyTemplateObjectsList, bool buildList = false)
        {
            partyStringId = stringId;
            BuildPartyTemplateList = buildList;
            _banditPartyTemplateObjectsList = banditPartyTemplateObjectsList;
            ParseTemplate();
        }

        /// <summary>
        /// Check if party is of nomad faction
        /// </summary>
        /// <returns>bool</returns>
        public bool IsNativeNomad()
        {
            bool IsNomad = false;
            foreach (string nomad in KPartyStringIds.NomadList)
            {
                if (partyStringId.ToLower().Contains(nomad))
                {
                    IsNomad = true;
                }
            }
            return IsNomad;
        }

        /// <summary>
        /// Check if party is of native kingdom faction
        /// </summary>
        /// <returns>bool</returns>
        public bool IsNativeKingdom()
        {
            bool isKingdom = false;
            foreach (string kingdom in KPartyStringIds.NativeKingdomsList)
            {
                if (partyStringId.Contains(kingdom))
                {
                    isKingdom = true;
                }
            }
            return isKingdom;
        }

        /// <summary>
        /// Check if party is of Calandria expanded Kingdoms faction
        /// </summary>
        /// <returns>bool</returns>
        public bool IsCKEKingdom()
        {
            bool isKingdom = false;
            foreach (string kingdom in KPartyStringIds.CKEKingdomsList)
            {
                if (partyStringId.Contains(kingdom))
                {
                    isKingdom = true;
                }
            }
            return isKingdom;
        }

        /// <summary>
        /// Check if party is a boss party eg. Bandit Boss parties
        /// </summary>
        /// <returns>bool</returns>
        public bool IsBossParty()
        {
            bool isBoss = false;
            if (partyStringId.Contains("boss"))
            {
                isBoss = true;
            }
            return isBoss;
        }

        /// <summary>
        /// Check if the party is one of the invalid parties listed below
        /// quest
        /// crazyman_party_template
        /// mixture_template
        /// siege_party
        /// routed_template
        /// _ambushers
        /// main_hero_
        /// crazyman
        /// mixture
        /// </summary>
        /// <returns>bool</returns>
        public bool IsInvlaid()
        {
            //partyStringId.ToLower().Contains("militia")  partyStringId.ToLower().Contains("rebels")
            bool isIsInvlaid = false;
            if (partyStringId.ToLower().Contains("quest") || partyStringId.ToLower().Contains("crazyman_party_template") ||
                partyStringId.ToLower().Contains("mixture_template") || partyStringId.ToLower().Contains("siege_party") ||
                partyStringId.ToLower().Contains("routed_template") || partyStringId.ToLower().Contains("_ambushers") ||
                partyStringId.ToLower().Contains("main_hero_") || partyStringId.ToLower().Contains("crazyman") ||
                partyStringId.ToLower().Contains("mixture")
                    )
            {
                isIsInvlaid = true;
            }
            return isIsInvlaid;
        }

        /// <summary>
        /// Get the bandit party template string name
        /// </summary>
        /// <param name="stringId">string partyId</param>
        /// <returns>string partyTemplateStringId</returns>
        public static string GetBanditPartyString(string stringId)
        {
            bool isBossParty = KPartyStringIds.IsBossParty(stringId);
            string banditPartyString = "";
            if (stringId.ToLower().Contains("looter"))
            {
                banditPartyString = "looters";
            }
            else if (stringId.ToLower().Contains("sea"))
            {
                if (isBossParty)
                {
                    banditPartyString = "sea_raiders_boss";
                }
                else
                {
                    banditPartyString = "sea_raiders";
                }

            }
            else if (stringId.ToLower().Contains("forest"))
            {
                if (isBossParty)
                {
                    banditPartyString = "forest_bandits_boss";
                }
                else
                {
                    banditPartyString = "forest_bandits";
                }
            }
            else if (stringId.ToLower().Contains("mountain"))
            {
                if (isBossParty)
                {
                    banditPartyString = "mountain_bandits_boss";
                }
                else
                {
                    banditPartyString = "mountain_bandits";
                }
            }
            else if (stringId.ToLower().Contains("desert"))
            {
                if (isBossParty)
                {
                    banditPartyString = "desert_bandits_boss";
                }
                else
                {
                    banditPartyString = "desert_bandits";
                }
            }
            else if (stringId.ToLower().Contains("steppe"))
            {
                if (isBossParty)
                {
                    banditPartyString = "steppe_bandits_boss";
                }
                else
                {
                    banditPartyString = "steppe_bandits";
                }
            }
            else if (stringId.ToLower().Contains("deserters"))
            {
                banditPartyString = "deserters";
            }
            return banditPartyString;
        }

        /// <summary>
        /// Parse the partyTemplate
        /// </summary>
        protected void ParseTemplate()
        {
            if (!IsInvlaid())
            {
                HasValidPartyTemplate = true;
                if (partyStringId.ToLower().Contains("looter") || partyStringId.ToLower().Contains("bandit") || partyStringId.ToLower().Contains("bandits")
                    || partyStringId.ToLower().Contains("raider") || partyStringId.ToLower().Contains("deserters"))
                {
                    //Logger.Lm($"PartyTemplateParsers: bandit  {partyStringId} -------------------------------");
                    IsBandit = true;
                    ParseBanditPartyTemplate();
                }
                else if (partyStringId.ToLower().Contains("mercenary"))
                {
                    //Logger.Lm($"PartyTemplateParsers: mercenary  {partyStringId} -------------------------------");
                    IsMercenary = true;
                }
                else if (partyStringId.ToLower().Contains("outlaw"))
                {
                    //Logger.Lm($"PartyTemplateParsers: outlaw  {partyStringId} -------------------------------");
                    IsOutLaw = true;
                }
                else if (partyStringId.ToLower().Contains("villager"))
                {
                    //Logger.Lm($"PartyTemplateParsers: villager  {partyStringId} -------------------------------");
                    IsVillager = true;
                    if (IsNativeKingdom())
                    {
                        IsVillagerNative = true;
                    }
                    if (IsCKEKingdom())
                    {
                        IsVillagerCKE = true;
                    }
                }
                else if (partyStringId.ToLower().Contains("militia") || partyStringId.ToLower().Contains("militias"))
                {
                    //Logger.Lm($"PartyTemplateParsers: militia  {partyStringId} -------------------------------");
                    IsMilitia = true;
                    if (IsNativeKingdom())
                    {
                        IsMilitiaNative = true;
                    }
                    if (IsCKEKingdom())
                    {
                        IsMilitiaCKE = true;
                    }
                }
                else if (partyStringId.ToLower().Contains("caravan") && !partyStringId.ToLower().Contains("char_"))
                {
                    //Logger.Lm($"PartyTemplateParsers: caravan  {partyStringId} -------------------------------");
                    IsCaravan = true;
                    if (partyStringId.ToLower().Contains("elite"))
                    {
                        ////Logger.Lm($"PartyTemplateParsers: elite -------------------------------");
                        IsCaravanElite = true;
                    }
                    if (IsNativeKingdom())
                    {
                        IsCaravanNative = true;
                    }
                    if (IsCKEKingdom())
                    {
                        IsCaravanCKE = true;
                    }
                }
                else if (partyStringId.ToLower().Contains("char_") || partyStringId.ToLower().Contains("gamescom_player") && !partyStringId.ToLower().Contains("caravan")) //
                {
                    //Logger.Lm($"PartyTemplateParsers: player  {partyStringId} -------------------------------");
                    IsPlayer = true;
                }
                else if (partyStringId.ToLower().Contains("kingdom_hero") && IsNativeNomad())
                {
                    //Logger.Lm($"PartyTemplateParsers: kingdom_hero IsNativeNomad {partyStringId} -------------------------------");
                    IsNomad = true;
                }
                else if (partyStringId.ToLower().Contains("kingdom_hero") && (IsNativeKingdom() || IsCKEKingdom()))
                {
                    //Logger.Lm($"PartyTemplateParsers: kingdom_hero  {partyStringId} -------------------------------");
                    ParseKingdomPartyTemplates();
                }
                else if (partyStringId.ToLower().Contains("rebels"))
                {
                    //Logger.Lm($"PartyTemplateParsers: manhunters  {partyStringId} -------------------------------");
                    IsRebels = true;
                    if (IsNativeKingdom())
                    {
                        IsRebelsNative = true;
                    }
                    if (IsCKEKingdom())
                    {
                        IsRebelsCKE = true;
                    }
                }
                else if (partyStringId.ToLower().Contains("manhunters"))
                {
                    //Logger.Lm($"PartyTemplateParsers: manhunters  {partyStringId} -------------------------------");
                    IsManhunters = true;
                }
                else if (partyStringId.ToLower().Contains("cs_"))
                {
                    //Logger.Lm($"PartyTemplateParsers: cs_   {partyStringId}  -------------------------------");
                    IsCS = true;
                }
            }
            else
            {
                //Logger.Lm($"PartyTemplateParsers: INVALID   {partyStringId}  -------------------------------");
            }

        }

        /// <summary>
        /// Parse the Bandit party Template
        /// </summary>
        protected void ParseBanditPartyTemplate()
        {
            if (partyStringId.ToLower().Contains("looter"))
            {
                //Logger.Lm($"PartyTemplateParsers: bandit looter-------------------------------");
                IsLooter = true;
                if (BuildPartyTemplateList)
                {
                    if (!_banditPartyTemplateObjectsList.ContainsKey("looters"))
                    {
                        _banditPartyTemplateObjectsList.Add("looters", _pt);
                    }
                }
            }
            else if (partyStringId.ToLower().Contains("deserters"))
            {
                //Logger.Lm($"PartyTemplateParsers: deserters -------------------------------");
                IsDeserters = true;
                //IM.MessageDebug($"ParseBanditPartyTemplate partyStringId: {partyStringId}\n");
                if (BuildPartyTemplateList)
                {
                    if (!_banditPartyTemplateObjectsList.ContainsKey("deserters"))
                    {
                        _banditPartyTemplateObjectsList.Add("deserters", _pt);
                    }

                }
            }
            else if (partyStringId.ToLower().Contains("sea"))
            {
                //Logger.Lm($"PartyTemplateParsers: bandit sea-------------------------------");
                IsSeaRaiders = true;
                IsSeaRaidersBoss = IsBossParty();
                if (BuildPartyTemplateList)
                {
                    if (IsSeaRaidersBoss)
                    {
                        if (!_banditPartyTemplateObjectsList.ContainsKey("sea_raiders_boss"))
                        {
                            _banditPartyTemplateObjectsList.Add("sea_raiders_boss", _pt);
                        }
                    }
                    else
                    {
                        if (!_banditPartyTemplateObjectsList.ContainsKey("sea_raiders"))
                        {
                            _banditPartyTemplateObjectsList.Add("sea_raiders", _pt);
                        }
                    }
                }
            }
            else if (partyStringId.ToLower().Contains("forest"))
            {
                //Logger.Lm($"PartyTemplateParsers: bandit forest-------------------------------");
                IsForestBandit = true;
                IsForestBanditBoss = IsBossParty();
                if (BuildPartyTemplateList)
                {
                    if (IsForestBanditBoss)
                    {
                        if (!_banditPartyTemplateObjectsList.ContainsKey("forest_bandits_boss"))
                        {
                            _banditPartyTemplateObjectsList.Add("forest_bandits_boss", _pt);
                        }
                    }
                    else
                    {
                        if (!_banditPartyTemplateObjectsList.ContainsKey("forest_bandits"))
                        {
                            _banditPartyTemplateObjectsList.Add("forest_bandits", _pt);
                        }
                    }
                }

            }
            else if (partyStringId.ToLower().Contains("mountain"))
            {
                //Logger.Lm($"PartyTemplateParsers: bandit mountain-------------------------------");
                IsMountainBandit = true;
                IsMountainBanditBoss = IsBossParty();
                if (BuildPartyTemplateList)
                {
                    if (IsMountainBanditBoss)
                    {
                        if (!_banditPartyTemplateObjectsList.ContainsKey("mountain_bandits_boss"))
                        {
                            _banditPartyTemplateObjectsList.Add("mountain_bandits_boss", _pt);
                        }
                    }
                    else
                    {
                        if (!_banditPartyTemplateObjectsList.ContainsKey("mountain_bandits"))
                        {
                            _banditPartyTemplateObjectsList.Add("mountain_bandits", _pt);
                        }
                    }
                }

            }
            else if (partyStringId.ToLower().Contains("desert"))
            {
                //Logger.Lm($"PartyTemplateParsers: bandit desert-------------------------------");
                IsDesertBandits = true;
                IsDesertBanditsBoss = IsBossParty();
                if (BuildPartyTemplateList)
                {
                    if (IsDesertBanditsBoss)
                    {
                        if (!_banditPartyTemplateObjectsList.ContainsKey("desert_bandits_boss"))
                        {
                            _banditPartyTemplateObjectsList.Add("desert_bandits_boss", _pt);
                        }
                    }
                    else
                    {
                        if (!_banditPartyTemplateObjectsList.ContainsKey("desert_bandits"))
                        {
                            _banditPartyTemplateObjectsList.Add("desert_bandits", _pt);
                        }
                    }
                }

            }
            else if (partyStringId.ToLower().Contains("steppe"))
            {
                //Logger.Lm($"PartyTemplateParsers: bandit steppe-------------------------------");
                IsSteppeBandits = true;
                IsSteppeBanditsBoss = IsBossParty();
                if (BuildPartyTemplateList)
                {
                    if (IsSteppeBanditsBoss)
                    {
                        if (!_banditPartyTemplateObjectsList.ContainsKey("steppe_bandits_boss"))
                        {
                            _banditPartyTemplateObjectsList.Add("steppe_bandits_boss", _pt);
                        }
                    }
                    else
                    {
                        if (!_banditPartyTemplateObjectsList.ContainsKey("steppe_bandits"))
                        {
                            _banditPartyTemplateObjectsList.Add("steppe_bandits", _pt);
                        }
                    }
                }

            }
        }

        /// <summary>
        /// Parse the Kingdom party template
        /// </summary>
        protected void ParseKingdomPartyTemplates()
        {
            if (!IsNomad)
            {
                if (IsNativeKingdom())
                {
                    ////Logger.Lm($"PartyTemplateParsers: IsKingdom -------------------------------");
                    IsKingdom = true;
                    IsKingdomNative = true;

                    if (partyStringId.ToLower().Contains("empire"))
                    {
                        IsEmpire = true;
                    }
                    else if (partyStringId.ToLower().Contains("sturgia"))
                    {
                        IsSturgia = true;
                    }
                    else if (partyStringId.ToLower().Contains("aserai"))
                    {
                        IsAserai = true;
                    }
                    else if (partyStringId.ToLower().Contains("vlandia"))
                    {
                        IsVlandia = true;
                    }
                    else if (partyStringId.ToLower().Contains("battania"))
                    {
                        IsBattania = true;
                    }
                    else if (partyStringId.ToLower().Contains("khuzait"))
                    {
                        IsKhuzait = true;
                    }
                }

                if (IsCKEKingdom())
                {
                    ////Logger.Lm($"PartyTemplateParsers: IsCKEKingdom -------------------------------");
                    IsKingdom = true;
                    IsKingdomCKE = true;

                    if (partyStringId.ToLower().Contains("nordling"))
                    {
                        IsNordling = true;
                    }
                    else if (partyStringId.ToLower().Contains("vagir"))
                    {
                        IsVagir = true;
                    }
                    else if (partyStringId.ToLower().Contains("rhodok"))
                    {
                        IsRhodok = true;
                    }
                    else if (partyStringId.ToLower().Contains("apolssalian"))
                    {
                        IsApolssalian = true;
                    }
                    else if (partyStringId.ToLower().Contains("lyrion"))
                    {
                        IsLyrion = true;
                    }
                    else if (partyStringId.ToLower().Contains("paleician"))
                    {
                        IsPaleician = true;
                    }
                    else if (partyStringId.ToLower().Contains("republic"))
                    {
                        IsRepublic = true;
                    }
                    else if (partyStringId.ToLower().Contains("ariorum"))
                    {
                        IsAriorum = true;
                    }
                }
            }
        }

    }
}
