using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem;

namespace KaosesCommon.Helpers
{

    /// <summary>
    /// Kaoses helper methods for working with factions
    /// </summary>
    public class KFaction
    {

        // Token: 0x06003079 RID: 12409 RVA: 0x000D1266 File Offset: 0x000CF466
        /// <summary>
        /// Check if Faction is looter faction by checking if they can have settlements
        /// </summary>
        /// <param name="faction"><see cref="IFaction"/> Taleworlds Faction object</param>
        /// <returns>bool</returns>
        public static bool IsLooterFaction(IFaction faction)
        {
            return !faction.Culture.CanHaveSettlement;
        }

        /// <summary>
        /// Helper method to check if party or party leader is part of the player clan
        /// </summary>
        /// <param name="party"><see cref="PartyBase"/> object </param>
        /// <returns><see cref="bool"/> true is is player or part of players clan, else is false</returns>
        public static bool IsPlayerClan(PartyBase party)
        {
            bool isSame = false;
            Hero hero = party.LeaderHero;
            if (hero != null)
            {
                Clan clan = hero.Clan;
                Clan playerClan = Clan.PlayerClan;
                if (clan == playerClan)
                {
                    isSame = true;
                }
            }
            return isSame;
        }

        /// <summary>
        /// Helper method to check if hero is part of the player clan
        /// </summary>
        /// <param name="hero"><see cref="Hero"/> character object </param>
        /// <returns>bool</returns>
        public static bool IsPlayerClan(Hero hero)
        {
            bool isSame = false;
            if (hero != null)
            {
                Clan clan = hero.Clan;
                Clan playerClan = Clan.PlayerClan;
                if (clan == playerClan)
                {
                    isSame = true;
                }
            }
            return isSame;
        }

        /// <summary>
        /// Helper method to check if the party or party leader is part of the player clan
        /// </summary>
        /// <param name="mobileParty"><see cref="MobileParty"/> mobileParty</param>
        /// <returns>bool</returns>
        public static bool IsPlayerClan(MobileParty mobileParty)
        {
            bool isPlayerClan = false;
            Clan clan;
            Clan playerClan;
            if (mobileParty.IsCaravan)
            {
                Hero hero = mobileParty.LeaderHero;
                if (hero != null)
                {
                    clan = hero.Clan;
                    playerClan = Clan.PlayerClan;
                    if (clan == playerClan)
                    {
                        isPlayerClan = true;
                    }
                }
            }
            else if (mobileParty.IsGarrison)
            {
                if (mobileParty.CurrentSettlement != null)
                {
                    Settlement settlement = mobileParty.CurrentSettlement;
                    if (settlement.OwnerClan != null)
                    {
                        clan = settlement.OwnerClan;
                        playerClan = Clan.PlayerClan;
                        if (clan == playerClan)
                        {
                            isPlayerClan = true;
                        }
                    }
                }
            }
            return isPlayerClan;
        }


        /// <summary>
        /// Helper method to check if Clan is one of the minor factions
        /// </summary>
        /// <param name="clan">Clan clan</param>
        /// <returns>bool</returns>
        public static bool IsMinorFaction(Clan clan)
        {
            bool isMinor = false;
            if (clan.IsOutlaw)
            {
                isMinor = true;
            }
            if (clan.IsNomad)
            {
                isMinor = true;
            }
            if (clan.IsClanTypeMercenary)
            {
                isMinor = true;
            }
            return isMinor;
        }


        /// <summary>
        /// Helper Method to check if JKingdom is Player Kingdom
        /// </summary>
        /// <param name="kingdom">Kingdom kingdom</param>
        /// <returns>bool</returns>
        public static bool IsPlayerKingdom(Kingdom kingdom)
        {
            bool isKingdom = false;
            if (kingdom != null)
            {
                Clan playerClan = Hero.MainHero.Clan;
                Kingdom? playerKingdom = null;
                if (playerClan.Kingdom != null)
                {
                    if (playerClan.Kingdom.Leader == Hero.MainHero || playerClan.Kingdom.RulingClan == playerClan)
                    {
                        playerKingdom = playerClan.Kingdom;
                    }
                }
                if (playerKingdom != null)
                {
                    if (kingdom == playerKingdom)
                    {
                        isKingdom = true;
                    }
                }

            }
            return isKingdom;
        }


        /// <summary>
        /// Helper to Check if the Hero is part of the player Kingdom
        /// </summary>
        /// <param name="hero">Hero hero</param>
        /// <returns>bool</returns>
        public static bool IsPlayerKingdom(Hero hero)
        {
            bool isKingdom = false;
            if (hero.Clan.Kingdom != null)
            {
                Clan playerClan = Hero.MainHero.Clan;
                Kingdom? playerKingdom = null;
                if (playerClan.Kingdom != null)
                {

                    if (playerClan.Kingdom.Leader == Hero.MainHero || playerClan.Kingdom.RulingClan == playerClan)
                    {
                        playerKingdom = playerClan.Kingdom;
                    }
                }
                if (playerKingdom != null)
                {
                    if (hero.Clan.Kingdom == playerKingdom)
                    {
                        isKingdom = true;
                    }
                }

            }
            return isKingdom;
        }


    }
}
