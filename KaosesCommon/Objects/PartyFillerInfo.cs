using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace KaosesCommon.Objects
{

    /// <summary>
    /// Struct to hold information for filling party stacks
    /// </summary>
    public struct PartyFillerInfo
    {
        /// <summary>
        /// Minimum stack size
        /// </summary>
        public int minSatcks;

        /// <summary>
        /// maximum stack size
        /// </summary>
        public int MaxStacks;

        /// <summary>
        /// Troop limit
        /// </summary>
        public int TroopLimit;
    }

    /// <summary>
    /// Kaoses Party Stack Filler, allows for filling parties from the partyTemplate that have more than 3 types. 
    /// This really only applies directly for non kingdom lord parties such as bandits, mercenaries, villagers etc.
    /// </summary>
    public class KaosesPartyFiller
    {
        /// <summary>
        /// MobileParty
        /// </summary>
        protected MobileParty _mobileParty;
        /// <summary>
        /// PartyTemplateObject
        /// </summary>
        protected PartyTemplateObject? _pt;
        /// <summary>
        /// refill number limit
        /// </summary>
        protected int _troopNumberLimit;

        /// <summary>
        /// Refill the MobileParty from the PartyTemplateObject with a limit of troopNumberLimit
        /// </summary>
        /// <param name="mobileParty">ref MobileParty mobileParty, passed by reference</param>
        /// <param name="pt">PartyTemplateObject pt</param>
        /// <param name="troopNumberLimit">int troopNumberLimit, limit for the number of troops to be added</param>
        public KaosesPartyFiller(ref MobileParty mobileParty, PartyTemplateObject pt, int troopNumberLimit = -1)
        {
            _mobileParty = mobileParty;
            _pt = pt;
            _troopNumberLimit = troopNumberLimit;
            if (mobileParty.StringId.ToLower().Contains("deserters"))
            {
                return;
            }
            if (_troopNumberLimit < 0)
            {
                FillOtherStacks();
            }
            else
            {
                FillPartyStacks();
            }
        }

        /// <summary>
        /// Fills the party stacks 
        /// </summary>
        protected void FillPartyStacks()
        {
            int k = 0;
            while (k < _troopNumberLimit)
            {
                for (int l = 0; l < _pt.Stacks.Count; l++)
                {
                    float stackAddAmount = 1f * ((float)(_pt.Stacks[l].MaxValue + _pt.Stacks[l].MinValue) / 2f);
                    CharacterObject character3 = _pt.Stacks[l].Character;
                    if (stackAddAmount < 0)
                    {
                        stackAddAmount = 1f;
                    }
                    if ((k + stackAddAmount) > _troopNumberLimit)
                    {
                        stackAddAmount = _troopNumberLimit - k;
                        if (stackAddAmount < 0)
                        {
                            stackAddAmount = 0;
                        }
                        _mobileParty.AddElementToMemberRoster(character3, (int)stackAddAmount, false);
                        k = _troopNumberLimit;
                        break;
                    }
                    else
                    {
                        k += (int)stackAddAmount;
                        _mobileParty.AddElementToMemberRoster(character3, (int)stackAddAmount, false);
                    }
                }
            }
        }

        /// <summary>
        /// Older fill stacks code
        /// </summary>
        protected void FillOtherStacks()
        {
            if (_troopNumberLimit < 0 && _pt != null)
            {
                //float gameProcess2 = MiscHelper.GetGameProcess();
                float gameProcess2 = (float)Campaign.Current.PlayerProgress;
                for (int j = 0; j < _pt.Stacks.Count; j++)
                {
                    //float gameProcess = MiscHelper.GetGameProcess();
                    float gameProcess = (float)Campaign.Current.PlayerProgress;
                    int num2 = MBRandom.RandomInt(2);
                    float num3 = (num2 == 0) ? MBRandom.RandomFloat : (MBRandom.RandomFloat * MBRandom.RandomFloat * MBRandom.RandomFloat * 4f);
                    float num4 = (num2 == 0) ? (num3 * 0.8f + 0.2f) : (1f + num3);
                    float randomFloat = MBRandom.RandomFloat;
                    float randomFloat2 = MBRandom.RandomFloat;
                    float randomFloat3 = MBRandom.RandomFloat;
                    float num = randomFloat2 + 0.8f * gameProcess;
                    float f = (_pt.Stacks.Count > 0) ? ((float)_pt.Stacks[j].MinValue + num * num4 * randomFloat * (float)(_pt.Stacks[j].MaxValue - _pt.Stacks[j].MinValue)) : 0f;

                    float part1 = _pt.Stacks[j].MinValue + num * num4 * randomFloat;
                    float part2 = _pt.Stacks[j].MaxValue - _pt.Stacks[j].MinValue;


                    int min = _pt.Stacks[j].MinValue;
                    int max = _pt.Stacks[j].MaxValue;
                    int rnd = KaosesCommon.Kaoses.rand.Next(_pt.Stacks[j].MinValue, _pt.Stacks[j].MaxValue);
                    /*
                                        IM.MessageDebug($"FillOtherStacks\n" +
                                            $"StringId :{_pt.StringId}\n"+
                                            $"min :{min}\n"+
                                            $"max :{max}\n"+
                                            $"part1 :{part1}\n"+
                                            $"part2 :{part2}\n"+
                                            $"total :{part1 * part2}\n"+
                                            $"_pt.StringId :{rnd}\n"

                                            );*/

                    int numberToAdd = rnd;
                    //int numberToAdd = (int)(gameProcess2 * (float)(_pt.Stacks[j].MaxValue - _pt.Stacks[j].MinValue)) + _pt.Stacks[j].MinValue;
                    //int numberToAdd = KaosesCommon.Kaoses.rand.Next((int)(partyLimit / 3), (int)partyLimit);
                    //_troopNumberLimit = KaosesCommon.Kaoses.rand.Next((int)(partyLimit / 3), (int)partyLimit);
                    if (numberToAdd < 1)
                    {
                        numberToAdd = 1;
                    }
                    CharacterObject character2 = _pt.Stacks[j].Character;
                    _mobileParty.AddElementToMemberRoster(character2, MBRandom.RoundRandomized(f), false);
                    //_mobileParty.AddElementToMemberRoster(character2, numberToAdd, false);
                }
                return;
            }
        }

    }
}
