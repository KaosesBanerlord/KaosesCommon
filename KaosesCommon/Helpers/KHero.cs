using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;

namespace KaosesCommon.Helpers
{
    public class KHero
    {
        /// <summary>
        /// Helper method checks if hero is the player
        /// </summary>
        /// <param name="hero"></param>
        /// <returns>bool</returns>
        public static bool isPlayer(Hero hero)
        {
            bool isPlayer = false;

            if (hero != null)
            {
                if (Hero.MainHero == hero)
                {
                    isPlayer = true;
                }
                /*
                if (Clan.PlayerClan.Leader == hero)
                {
                    isPlayer = true;
                }*/
            }
            return isPlayer;
        }

        /// <summary>
        /// Helper method to check if the Hero is a player Kingdom lord
        /// </summary>
        /// <param name="hero"></param>
        /// <returns>bool</returns>
        public static bool IsPlayerLord(Hero hero)
        {
            bool isPlayerLord = false;
            if (hero.Clan.Kingdom != null && hero != Hero.MainHero)
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
                    if ((hero.Clan.Kingdom == playerKingdom || KFaction.IsPlayerClan(hero)) && IsLord(hero))
                    {
                        isPlayerLord = true;
                    }
                }
            }
            else
            {
                if (IsLord(hero) && KFaction.IsPlayerClan(hero))
                {
                    isPlayerLord = true;
                }
            }
            return isPlayerLord;
        }

        /// <summary>
        /// Method to check if hero is a lord or wander. Use to check for lady as well but that flag has been removed
        /// </summary>
        /// <param name="hero"></param>
        /// <returns>bool</returns>
        public static bool IsLord(Hero hero)
        {
            return hero.CharacterObject.Occupation is Occupation.Lord or Occupation.Wanderer;// or Occupation.Lady
        }

    }
}
