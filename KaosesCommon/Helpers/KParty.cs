using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace KaosesCommon.Helpers
{

    /// <summary>
    /// Kaoses Helper methods For Parties
    /// </summary>
    public class KParty
    {

        /// <summary>
        /// Method to get the nearest Settlement to a MobileParty
        /// </summary>
        /// <param name="mobileParty">MobileParty mobileParty</param>
        /// <returns>Settlement nearestSettlement</returns>
        public static Settlement GetNearestSettlement(MobileParty mobileParty)
        {
            Settlement nearestSettlement = null;
            float smallestDistance = 1000000f;
            foreach (Settlement settlement in Campaign.Current.Settlements)
            {
                float tmp = settlement.Position2D.DistanceSquared(mobileParty.Position2D);
                if (tmp < smallestDistance)
                {
                    smallestDistance = tmp;
                    nearestSettlement = settlement;
                }
            }
            return nearestSettlement;
        }

        /// <summary>
        /// Get the closest Desert Party to MobileParty.
        /// Currently Broken as taleworlds removed isDesert flag
        /// </summary>
        /// <param name="party">MobileParty party</param>
        /// <param name="minimumNearestDistanceDeserters">float minimum nearest distance</param>
        /// <returns>MobileParty closestParty</returns>
        public static MobileParty GetClosestDesertParty(MobileParty party, float minimumNearestDistanceDeserters)
        {
            // from killing bandits gets settlements within specified range of battle 
            //float closestDistancce = 10000f;
            //MobileParty closestParty = null;
            //foreach (MobileParty mobileParty in MobileParty.All)
            //{
            //    if (mobileParty.IsDeserterParty)
            //    {
            //        float tmp = mobileParty.Position2D.DistanceSquared(party.Position2D);
            //        if (tmp < closestDistancce)
            //        {
            //            closestDistancce = tmp;
            //            closestParty = mobileParty;
            //        }
            //    }
            //}
            //if (closestDistancce != 10000f)
            //{
            //    if (closestDistancce > minimumNearestDistanceDeserters)
            //    {
            //        closestParty = null;
            //    }
            //}
            //else
            //{
            //    closestParty = null;
            //}
            return party;
        }

        /// <summary>
        /// Get the closest Bandit party to MobileParty
        /// </summary>
        /// <param name="party">MobileParty party</param>
        /// <returns></returns>
        public static MobileParty GetClosestBanditParty(MobileParty party)
        {
            // from killing bandits gets settlements within specified range of battle 
            float closestDistancce = 10000f;
            MobileParty closestParty = null;
            foreach (MobileParty mobileParty in MobileParty.All)
            {
                if (mobileParty.IsBandit)
                {
                    float tmp = mobileParty.Position2D.DistanceSquared(party.Position2D);
                    if (tmp < closestDistancce)
                    {
                        closestDistancce = tmp;
                        closestParty = mobileParty;
                    }
                }
            }
            return closestParty;
        }

        /// <summary>
        /// Get the nearest Hideout to the MobileParty
        /// </summary>
        /// <param name="party">MobileParty party</param>
        /// <returns></returns>
        public static Hideout GetNearestHideout(MobileParty party)
        {
            Hideout nearestHideout = null;
            float closetDistance = 10000f;
            foreach (Settlement settlement in Campaign.Current.Settlements)
            {
                if (settlement.IsHideout)
                {
                    float tmp = settlement.Position2D.DistanceSquared(party.Position2D);
                    if (tmp < closetDistance)
                    {
                        closetDistance = tmp;
                        nearestHideout = settlement.Hideout;
                    }
                }
            }
            return nearestHideout;
        }

        //Token: 0x0600307C RID: 12412 RVA: 0x000D145C File Offset: 0x000CF65C
        /// <summary>
        /// Create MobileParty Trade for Bandit party
        /// </summary>
        /// <param name="banditParty">MobileParty banditParty</param>
        public static void CreatePartyTrade(MobileParty banditParty)
        {
            float totalStrength = banditParty.Party.TotalStrength;
            int initialGold = (int)(10f * (float)banditParty.Party.MemberRoster.TotalManCount * (0.5f + 1f * MBRandom.RandomFloat));
            banditParty.InitializePartyTrade(initialGold);
        }

        /// <summary>
        /// Get a list of All hideouts
        /// </summary>
        /// <returns>List<Hideout> hideoutsList</returns>
        public static List<Hideout> GetAllHideoutsList()
        {
            List<Hideout> hideoutsList = new List<Hideout>();
            foreach (Settlement settlement in Campaign.Current.Settlements)
            {
                if (settlement.IsHideout && !hideoutsList.Contains(settlement.Hideout))
                {
                    hideoutsList.Add(settlement.Hideout);
                }
            }
            return hideoutsList;
        }



        /// <summary>
        /// Object to string
        /// </summary>
        /// <returns>string</returns>
        //private override string ToString()
        //{
        //    return base.ToString();
        //}

        /// <summary>
        /// Does Object equal Object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>bool</returns>
        //private override bool Equals(object obj)
        //{
        //    return base.Equals(obj);
        //}

        /// <summary>
        /// Get Hash Code
        /// </summary>
        /// <returns></returns>
        //private override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}
    }
}


/*
  SkillObject Skills
Name: One Handed  StringId: OneHanded
Name: Two Handed  StringId: TwoHanded
Name: Polearm  StringId: Polearm
Name: Bow  StringId: Bow
Name: Crossbow  StringId: Crossbow
Name: Throwing  StringId: Throwing
Name: Riding  StringId: Riding
Name: Athletics  StringId: Athletics
Name: Smithing  StringId: Crafting
Name: Tactics  StringId: Tactics
Name: Scouting  StringId: Scouting
Name: Roguery  StringId: Roguery
Name: Charm  StringId: Charm
Name: Trade  StringId: Trade
Name: Steward  StringId: Steward
Name: Leadership  StringId: Leadership
Name: Medicine  StringId: Medicine
Name: Engineering  StringId: Engineering






PerkObject Perks



Name: Deflect
StringId: OneHandedDeflect
Skill.Name: One Handed

Skill.Name: One Handed

AlternativePerk.Name: Basher
AlternativePerk.StringId OneHandedBasher

Name: Basher
StringId: OneHandedBasher
Skill.Name: One Handed

Skill.Name: One Handed

AlternativePerk.Name: Deflect
AlternativePerk.StringId OneHandedDeflect

Name: To Be Blunt
StringId: OneHandedToBeBlunt
Skill.Name: One Handed

Skill.Name: One Handed

AlternativePerk.Name: Swift Strike
AlternativePerk.StringId OneHandedSwiftStrike

Name: Swift Strike
StringId: OneHandedSwiftStrike
Skill.Name: One Handed

Skill.Name: One Handed

AlternativePerk.Name: To Be Blunt
AlternativePerk.StringId OneHandedToBeBlunt

Name: Cavalry
StringId: OneHandedCavalry
Skill.Name: One Handed

Skill.Name: One Handed

AlternativePerk.Name: Shield Bearer
AlternativePerk.StringId OneHandedShieldBearer

Name: Shield Bearer
StringId: OneHandedShieldBearer
Skill.Name: One Handed

Skill.Name: One Handed

AlternativePerk.Name: Cavalry
AlternativePerk.StringId OneHandedCavalry

Name: Trainer
StringId: OneHandedTrainer
Skill.Name: One Handed

Skill.Name: One Handed

AlternativePerk.Name: Duelist
AlternativePerk.StringId OneHandedDuelist

Name: Duelist
StringId: OneHandedDuelist
Skill.Name: One Handed

Skill.Name: One Handed

AlternativePerk.Name: Trainer
AlternativePerk.StringId OneHandedTrainer

Name: Shieldwall
StringId: OneHandedShieldWall
Skill.Name: One Handed

Skill.Name: One Handed

AlternativePerk.Name: Arrow Catcher
AlternativePerk.StringId OneHandedArrowCatcher

Name: Arrow Catcher
StringId: OneHandedArrowCatcher
Skill.Name: One Handed

Skill.Name: One Handed

AlternativePerk.Name: Shieldwall
AlternativePerk.StringId OneHandedShieldWall

Name: Military Tradition
StringId: OneHandedMilitaryTradition
Skill.Name: One Handed

Skill.Name: One Handed

AlternativePerk.Name: Corps-a-corps
AlternativePerk.StringId OneHandedCorpsACorps

Name: Corps-a-corps
StringId: OneHandedCorpsACorps
Skill.Name: One Handed

Skill.Name: One Handed

AlternativePerk.Name: Military Tradition
AlternativePerk.StringId OneHandedMilitaryTradition

Name: Stand United
StringId: OneHandedStandUnited
Skill.Name: One Handed

Skill.Name: One Handed

AlternativePerk.Name: Lead by example
AlternativePerk.StringId OneHandedLeadByExample

Name: Lead by example
StringId: OneHandedLeadByExample
Skill.Name: One Handed

Skill.Name: One Handed

AlternativePerk.Name: Stand United
AlternativePerk.StringId OneHandedStandUnited

Name: Steel Core Shields
StringId: OneHandedSteelCoreShields
Skill.Name: One Handed

Skill.Name: One Handed

AlternativePerk.Name: Fleet of Foot
AlternativePerk.StringId OneHandedFleetOfFoot

Name: Fleet of Foot
StringId: OneHandedFleetOfFoot
Skill.Name: One Handed

Skill.Name: One Handed

AlternativePerk.Name: Steel Core Shields
AlternativePerk.StringId OneHandedSteelCoreShields

Name: Deadly Purpose
StringId: OneHandedDeadlyPurpose
Skill.Name: One Handed

Skill.Name: One Handed

AlternativePerk.Name: Unwavering Defense
AlternativePerk.StringId OneHandedUnwaveringDefense

Name: Unwavering Defense
StringId: OneHandedUnwaveringDefense
Skill.Name: One Handed

Skill.Name: One Handed

AlternativePerk.Name: Deadly Purpose
AlternativePerk.StringId OneHandedDeadlyPurpose

Name: Prestige
StringId: OneHandedPrestige
Skill.Name: One Handed

Skill.Name: One Handed

AlternativePerk.Name: Chink in the Armor
AlternativePerk.StringId OneHandedChinkInTheArmor

Name: Chink in the Armor
StringId: OneHandedChinkInTheArmor
Skill.Name: One Handed

Skill.Name: One Handed

AlternativePerk.Name: Prestige
AlternativePerk.StringId OneHandedPrestige

Name: Way of the Sword
StringId: OneHandedWayOfTheSword
Skill.Name: One Handed

Skill.Name: One Handed

Name: Strong Grip
StringId: TwoHandedStrongGrip
Skill.Name: Two Handed

Skill.Name: Two Handed

AlternativePerk.Name: Wood Chopper
AlternativePerk.StringId TwoHandedWoodChopper

Name: Wood Chopper
StringId: TwoHandedWoodChopper
Skill.Name: Two Handed

Skill.Name: Two Handed

AlternativePerk.Name: Strong Grip
AlternativePerk.StringId TwoHandedStrongGrip

Name: On the Edge
StringId: TwoHandedOnTheEdge
Skill.Name: Two Handed

Skill.Name: Two Handed

AlternativePerk.Name: Head Basher
AlternativePerk.StringId TwoHandedHeadBasher

Name: Head Basher
StringId: TwoHandedHeadBasher
Skill.Name: Two Handed

Skill.Name: Two Handed

AlternativePerk.Name: On the Edge
AlternativePerk.StringId TwoHandedOnTheEdge

Name: Show of Strength
StringId: TwoHandedShowOfStrength
Skill.Name: Two Handed

Skill.Name: Two Handed

AlternativePerk.Name: Baptised in Blood
AlternativePerk.StringId TwoHandedBaptisedInBlood

Name: Baptised in Blood
StringId: TwoHandedBaptisedInBlood
Skill.Name: Two Handed

Skill.Name: Two Handed

AlternativePerk.Name: Show of Strength
AlternativePerk.StringId TwoHandedShowOfStrength

Name: Beast Slayer
StringId: TwoHandedBeastSlayer
Skill.Name: Two Handed

Skill.Name: Two Handed

AlternativePerk.Name: Shield breaker
AlternativePerk.StringId TwoHandedShieldBreaker

Name: Shield breaker
StringId: TwoHandedShieldBreaker
Skill.Name: Two Handed

Skill.Name: Two Handed

AlternativePerk.Name: Beast Slayer
AlternativePerk.StringId TwoHandedBeastSlayer

Name: Berserker
StringId: TwoHandedBerserker
Skill.Name: Two Handed

Skill.Name: Two Handed

AlternativePerk.Name: Confidence
AlternativePerk.StringId TwoHandedConfidence

Name: Confidence
StringId: TwoHandedConfidence
Skill.Name: Two Handed

Skill.Name: Two Handed

AlternativePerk.Name: Berserker
AlternativePerk.StringId TwoHandedBerserker

Name: Arrow Deflection
StringId: TwoHandedArrowDeflection
Skill.Name: Two Handed

Skill.Name: Two Handed

Name: Terror
StringId: TwoHandedTerror
Skill.Name: Two Handed

Skill.Name: Two Handed

AlternativePerk.Name: Hope
AlternativePerk.StringId TwoHandedHope

Name: Hope
StringId: TwoHandedHope
Skill.Name: Two Handed

Skill.Name: Two Handed

AlternativePerk.Name: Terror
AlternativePerk.StringId TwoHandedTerror

Name: Reckless Charge
StringId: TwoHandedRecklessCharge
Skill.Name: Two Handed

Skill.Name: Two Handed

AlternativePerk.Name: Thick Hides
AlternativePerk.StringId TwoHandedThickHides

Name: Thick Hides
StringId: TwoHandedThickHides
Skill.Name: Two Handed

Skill.Name: Two Handed

AlternativePerk.Name: Reckless Charge
AlternativePerk.StringId TwoHandedRecklessCharge

Name: Blade Master
StringId: TwoHandedBladeMaster
Skill.Name: Two Handed

Skill.Name: Two Handed

AlternativePerk.Name: Vandal
AlternativePerk.StringId TwoHandedVandal

Name: Vandal
StringId: TwoHandedVandal
Skill.Name: Two Handed

Skill.Name: Two Handed

AlternativePerk.Name: Blade Master
AlternativePerk.StringId TwoHandedBladeMaster

Name: Way Of The Great Axe
StringId: TwoHandedWayOfTheGreatAxe
Skill.Name: Two Handed

Skill.Name: Two Handed

Name: Pikeman
StringId: PolearmPikeman
Skill.Name: Polearm

Skill.Name: Polearm

AlternativePerk.Name: Cavalry
AlternativePerk.StringId PolearmCavalry

Name: Cavalry
StringId: PolearmCavalry
Skill.Name: Polearm

Skill.Name: Polearm

AlternativePerk.Name: Pikeman
AlternativePerk.StringId PolearmPikeman

Name: Braced
StringId: PolearmBraced
Skill.Name: Polearm

Skill.Name: Polearm

AlternativePerk.Name: Keep at Bay
AlternativePerk.StringId PolearmKeepAtBay

Name: Keep at Bay
StringId: PolearmKeepAtBay
Skill.Name: Polearm

Skill.Name: Polearm

AlternativePerk.Name: Braced
AlternativePerk.StringId PolearmBraced

Name: Swift Swing
StringId: PolearmSwiftSwing
Skill.Name: Polearm

Skill.Name: Polearm

AlternativePerk.Name: Clean Thrust
AlternativePerk.StringId PolearmCleanThrust

Name: Clean Thrust
StringId: PolearmCleanThrust
Skill.Name: Polearm

Skill.Name: Polearm

AlternativePerk.Name: Swift Swing
AlternativePerk.StringId PolearmSwiftSwing

Name: Footwork
StringId: PolearmFootwork
Skill.Name: Polearm

Skill.Name: Polearm

AlternativePerk.Name: Hard Knock
AlternativePerk.StringId PolearmHardKnock

Name: Hard Knock
StringId: PolearmHardKnock
Skill.Name: Polearm

Skill.Name: Polearm

AlternativePerk.Name: Footwork
AlternativePerk.StringId PolearmFootwork

Name: Steed Killer
StringId: PolearmSteadKiller
Skill.Name: Polearm

Skill.Name: Polearm

AlternativePerk.Name: Lancer
AlternativePerk.StringId PolearmLancer

Name: Lancer
StringId: PolearmLancer
Skill.Name: Polearm

Skill.Name: Polearm

AlternativePerk.Name: Steed Killer
AlternativePerk.StringId PolearmSteadKiller

Name: Skewer
StringId: PolearmSkewer
Skill.Name: Polearm

Skill.Name: Polearm

AlternativePerk.Name: Guards
AlternativePerk.StringId PolearmGuards

Name: Guards
StringId: PolearmGuards
Skill.Name: Polearm

Skill.Name: Polearm

AlternativePerk.Name: Skewer
AlternativePerk.StringId PolearmSkewer

Name: Standard Bearer
StringId: PolearmStandardBearer
Skill.Name: Polearm

Skill.Name: Polearm

AlternativePerk.Name: Phalanx
AlternativePerk.StringId PolearmPhalanx

Name: Phalanx
StringId: PolearmPhalanx
Skill.Name: Polearm

Skill.Name: Polearm

AlternativePerk.Name: Standard Bearer
AlternativePerk.StringId PolearmStandardBearer

Name: Generous Rations
StringId: PolearmGenerousRations
Skill.Name: Polearm

Skill.Name: Polearm

AlternativePerk.Name: Drills
AlternativePerk.StringId PolearmDrills

Name: Drills
StringId: PolearmDrills
Skill.Name: Polearm

Skill.Name: Polearm

AlternativePerk.Name: Generous Rations
AlternativePerk.StringId PolearmGenerousRations

Name: Sure Footed
StringId: PolearmSureFooted
Skill.Name: Polearm

Skill.Name: Polearm

AlternativePerk.Name: Unstoppable Force
AlternativePerk.StringId PolearmUnstoppableForce

Name: Unstoppable Force
StringId: PolearmUnstoppableForce
Skill.Name: Polearm

Skill.Name: Polearm

AlternativePerk.Name: Sure Footed
AlternativePerk.StringId PolearmSureFooted

Name: Counterweight
StringId: PolearmCounterweight
Skill.Name: Polearm

Skill.Name: Polearm

AlternativePerk.Name: Sharpen the Tip
AlternativePerk.StringId PolearmSharpenTheTip

Name: Sharpen the Tip
StringId: PolearmSharpenTheTip
Skill.Name: Polearm

Skill.Name: Polearm

AlternativePerk.Name: Counterweight
AlternativePerk.StringId PolearmCounterweight

Name: Way of the Spear
StringId: PolearmWayOfTheSpear
Skill.Name: Polearm

Skill.Name: Polearm

Name: Bow Control
StringId: BowBowControl
Skill.Name: Bow

Skill.Name: Bow

AlternativePerk.Name: Dead Aim
AlternativePerk.StringId BowDeadAim

Name: Dead Aim
StringId: BowDeadAim
Skill.Name: Bow

Skill.Name: Bow

AlternativePerk.Name: Bow Control
AlternativePerk.StringId BowBowControl

Name: Bodkin
StringId: BowBodkin
Skill.Name: Bow

Skill.Name: Bow

AlternativePerk.Name: Ranger's Swiftness
AlternativePerk.StringId BowRangersSwiftness

Name: Ranger's Swiftness
StringId: BowRangersSwiftness
Skill.Name: Bow

Skill.Name: Bow

AlternativePerk.Name: Bodkin
AlternativePerk.StringId BowBodkin

Name: Rapid Fire
StringId: BowRapidFire
Skill.Name: Bow

Skill.Name: Bow

AlternativePerk.Name: Quick Adjustments
AlternativePerk.StringId BowQuickAdjustments

Name: Quick Adjustments
StringId: BowQuickAdjustments
Skill.Name: Bow

Skill.Name: Bow

AlternativePerk.Name: Rapid Fire
AlternativePerk.StringId BowRapidFire

Name: Merry Men
StringId: BowMerryMen
Skill.Name: Bow

Skill.Name: Bow

AlternativePerk.Name: Mounted Archery
AlternativePerk.StringId BowMountedArchery

Name: Mounted Archery
StringId: BowMountedArchery
Skill.Name: Bow

Skill.Name: Bow

AlternativePerk.Name: Merry Men
AlternativePerk.StringId BowMerryMen

Name: Trainer
StringId: BowTrainer
Skill.Name: Bow

Skill.Name: Bow

AlternativePerk.Name: Strong bows
AlternativePerk.StringId BowStrongBows

Name: Strong bows
StringId: BowStrongBows
Skill.Name: Bow

Skill.Name: Bow

AlternativePerk.Name: Trainer
AlternativePerk.StringId BowTrainer

Name: Discipline
StringId: BowDiscipline
Skill.Name: Bow

Skill.Name: Bow

AlternativePerk.Name: Hunter Clan
AlternativePerk.StringId BowHunterClan

Name: Hunter Clan
StringId: BowHunterClan
Skill.Name: Bow

Skill.Name: Bow

AlternativePerk.Name: Discipline
AlternativePerk.StringId BowDiscipline

Name: Skirmish Phase Master
StringId: BowSkirmishPhaseMaster
Skill.Name: Bow

Skill.Name: Bow

AlternativePerk.Name: Eagle Eye
AlternativePerk.StringId BowEagleEye

Name: Eagle Eye
StringId: BowEagleEye
Skill.Name: Bow

Skill.Name: Bow

AlternativePerk.Name: Skirmish Phase Master
AlternativePerk.StringId BowSkirmishPhaseMaster

Name: Bulls Eye
StringId: BowBullsEye
Skill.Name: Bow

Skill.Name: Bow

AlternativePerk.Name: Renowned Archer
AlternativePerk.StringId BowRenownedArcher

Name: Renowned Archer
StringId: BowRenownedArcher
Skill.Name: Bow

Skill.Name: Bow

AlternativePerk.Name: Bulls Eye
AlternativePerk.StringId BowBullsEye

Name: Horse Master
StringId: BowHorseMaster
Skill.Name: Bow

Skill.Name: Bow

AlternativePerk.Name: Deep Quivers
AlternativePerk.StringId BowDeepQuivers

Name: Deep Quivers
StringId: BowDeepQuivers
Skill.Name: Bow

Skill.Name: Bow

AlternativePerk.Name: Horse Master
AlternativePerk.StringId BowHorseMaster

Name: Quick Draw
StringId: BowQuickDraw
Skill.Name: Bow

Skill.Name: Bow

AlternativePerk.Name: Salvo
AlternativePerk.StringId BowSalvo

Name: Salvo
StringId: BowSalvo
Skill.Name: Bow

Skill.Name: Bow

AlternativePerk.Name: Quick Draw
AlternativePerk.StringId BowQuickDraw

Name: Deadshot
StringId: BowDeadshot
Skill.Name: Bow

Skill.Name: Bow

Name: Piercer
StringId: CrossbowPiercer
Skill.Name: Crossbow

Skill.Name: Crossbow

AlternativePerk.Name: Marksmen
AlternativePerk.StringId CrossbowMarksmen

Name: Marksmen
StringId: CrossbowMarksmen
Skill.Name: Crossbow

Skill.Name: Crossbow

AlternativePerk.Name: Piercer
AlternativePerk.StringId CrossbowPiercer

Name: Unhorser
StringId: CrossbowUnhorser
Skill.Name: Crossbow

Skill.Name: Crossbow

AlternativePerk.Name: Wind Winder
AlternativePerk.StringId CrossbowWindWinder

Name: Wind Winder
StringId: CrossbowWindWinder
Skill.Name: Crossbow

Skill.Name: Crossbow

AlternativePerk.Name: Unhorser
AlternativePerk.StringId CrossbowUnhorser

Name: Donkeys Swiftness
StringId: CrossbowDonkeysSwiftness
Skill.Name: Crossbow

Skill.Name: Crossbow

AlternativePerk.Name: Sheriff
AlternativePerk.StringId CrossbowSheriff

Name: Sheriff
StringId: CrossbowSheriff
Skill.Name: Crossbow

Skill.Name: Crossbow

AlternativePerk.Name: Donkeys Swiftness
AlternativePerk.StringId CrossbowDonkeysSwiftness

Name: Peasant Leader
StringId: CrossbowPeasantLeader
Skill.Name: Crossbow

Skill.Name: Crossbow

AlternativePerk.Name: Renown Marksmen
AlternativePerk.StringId CrossbowRenownMarksmen

Name: Renown Marksmen
StringId: CrossbowRenownMarksmen
Skill.Name: Crossbow

Skill.Name: Crossbow

AlternativePerk.Name: Peasant Leader
AlternativePerk.StringId CrossbowPeasantLeader

Name: Fletcher
StringId: CrossbowFletcher
Skill.Name: Crossbow

Skill.Name: Crossbow

AlternativePerk.Name: Puncture
AlternativePerk.StringId CrossbowPuncture

Name: Puncture
StringId: CrossbowPuncture
Skill.Name: Crossbow

Skill.Name: Crossbow

AlternativePerk.Name: Fletcher
AlternativePerk.StringId CrossbowFletcher

Name: Loose and Move
StringId: CrossbowLooseAndMove
Skill.Name: Crossbow

Skill.Name: Crossbow

AlternativePerk.Name: Deft Hands
AlternativePerk.StringId CrossbowDeftHands

Name: Deft Hands
StringId: CrossbowDeftHands
Skill.Name: Crossbow

Skill.Name: Crossbow

AlternativePerk.Name: Loose and Move
AlternativePerk.StringId CrossbowLooseAndMove

Name: Counter Fire
StringId: CrossbowCounterFire
Skill.Name: Crossbow

Skill.Name: Crossbow

AlternativePerk.Name: Mounted Crossbowman
AlternativePerk.StringId CrossbowMountedCrossbowman

Name: Mounted Crossbowman
StringId: CrossbowMountedCrossbowman
Skill.Name: Crossbow

Skill.Name: Crossbow

AlternativePerk.Name: Counter Fire
AlternativePerk.StringId CrossbowCounterFire

Name: Steady
StringId: CrossbowSteady
Skill.Name: Crossbow

Skill.Name: Crossbow

AlternativePerk.Name: Sniper
AlternativePerk.StringId CrossbowSniper

Name: Sniper
StringId: CrossbowSniper
Skill.Name: Crossbow

Skill.Name: Crossbow

AlternativePerk.Name: Steady
AlternativePerk.StringId CrossbowSteady

Name: Hammer Bolts
StringId: CrossbowHammerBolts
Skill.Name: Crossbow

Skill.Name: Crossbow

AlternativePerk.Name: Pavise
AlternativePerk.StringId CrossbowPavise

Name: Pavise
StringId: CrossbowPavise
Skill.Name: Crossbow

Skill.Name: Crossbow

AlternativePerk.Name: Hammer Bolts
AlternativePerk.StringId CrossbowHammerBolts

Name: Terror
StringId: CrossbowTerror
Skill.Name: Crossbow

Skill.Name: Crossbow

AlternativePerk.Name: Picked Shots
AlternativePerk.StringId CrossbowBoltenGuard

Name: Picked Shots
StringId: CrossbowBoltenGuard
Skill.Name: Crossbow

Skill.Name: Crossbow

AlternativePerk.Name: Terror
AlternativePerk.StringId CrossbowTerror

Name: Mighty Pull
StringId: CrossbowMightyPull
Skill.Name: Crossbow

Skill.Name: Crossbow

Name: Quick Draw
StringId: ThrowingQuickDraw
Skill.Name: Throwing

Skill.Name: Throwing

AlternativePerk.Name: Shield Breaker
AlternativePerk.StringId ThrowingShieldBreaker

Name: Shield Breaker
StringId: ThrowingShieldBreaker
Skill.Name: Throwing

Skill.Name: Throwing

AlternativePerk.Name: Quick Draw
AlternativePerk.StringId ThrowingQuickDraw

Name: Hunter
StringId: ThrowingHunter
Skill.Name: Throwing

Skill.Name: Throwing

AlternativePerk.Name: Flexible Fighter
AlternativePerk.StringId ThrowingFlexibleFighter

Name: Flexible Fighter
StringId: ThrowingFlexibleFighter
Skill.Name: Throwing

Skill.Name: Throwing

AlternativePerk.Name: Hunter
AlternativePerk.StringId ThrowingHunter

Name: Mounted Skirmisher
StringId: ThrowingMountedSkirmisher
Skill.Name: Throwing

Skill.Name: Throwing

AlternativePerk.Name: Perfect Technique
AlternativePerk.StringId ThrowingPerfectTechnique

Name: Perfect Technique
StringId: ThrowingPerfectTechnique
Skill.Name: Throwing

Skill.Name: Throwing

AlternativePerk.Name: Mounted Skirmisher
AlternativePerk.StringId ThrowingMountedSkirmisher

Name: Running Throw
StringId: ThrowingRunningThrow
Skill.Name: Throwing

Skill.Name: Throwing

AlternativePerk.Name: Knock Off
AlternativePerk.StringId ThrowingKnockOff

Name: Knock Off
StringId: ThrowingKnockOff
Skill.Name: Throwing

Skill.Name: Throwing

AlternativePerk.Name: Running Throw
AlternativePerk.StringId ThrowingRunningThrow

Name: Skirmisher
StringId: ThrowingSkirmisher
Skill.Name: Throwing

Skill.Name: Throwing

AlternativePerk.Name: Well Prepared
AlternativePerk.StringId ThrowingWellPrepared

Name: Well Prepared
StringId: ThrowingWellPrepared
Skill.Name: Throwing

Skill.Name: Throwing

AlternativePerk.Name: Skirmisher
AlternativePerk.StringId ThrowingSkirmisher

Name: Focus
StringId: ThrowingFocus
Skill.Name: Throwing

Skill.Name: Throwing

AlternativePerk.Name: Last Hit
AlternativePerk.StringId ThrowingLastHit

Name: Last Hit
StringId: ThrowingLastHit
Skill.Name: Throwing

Skill.Name: Throwing

AlternativePerk.Name: Focus
AlternativePerk.StringId ThrowingFocus

Name: Head Hunter
StringId: ThrowingHeadHunter
Skill.Name: Throwing

Skill.Name: Throwing

AlternativePerk.Name: Throwing Competitions
AlternativePerk.StringId ThrowingThrowingCompetitions

Name: Throwing Competitions
StringId: ThrowingThrowingCompetitions
Skill.Name: Throwing

Skill.Name: Throwing

AlternativePerk.Name: Head Hunter
AlternativePerk.StringId ThrowingHeadHunter

Name: Saddlebags
StringId: ThrowingSaddlebags
Skill.Name: Throwing

Skill.Name: Throwing

AlternativePerk.Name: Splinters
AlternativePerk.StringId ThrowingSplinters

Name: Splinters
StringId: ThrowingSplinters
Skill.Name: Throwing

Skill.Name: Throwing

AlternativePerk.Name: Saddlebags
AlternativePerk.StringId ThrowingSaddlebags

Name: Resourceful
StringId: ThrowingResourceful
Skill.Name: Throwing

Skill.Name: Throwing

AlternativePerk.Name: Long Reach
AlternativePerk.StringId ThrowingLongReach

Name: Long Reach
StringId: ThrowingLongReach
Skill.Name: Throwing

Skill.Name: Throwing

AlternativePerk.Name: Resourceful
AlternativePerk.StringId ThrowingResourceful

Name: Weak Spot
StringId: ThrowingWeakSpot
Skill.Name: Throwing

Skill.Name: Throwing

AlternativePerk.Name: Impale
AlternativePerk.StringId ThrowingImpale

Name: Impale
StringId: ThrowingImpale
Skill.Name: Throwing

Skill.Name: Throwing

AlternativePerk.Name: Weak Spot
AlternativePerk.StringId ThrowingWeakSpot

Name: Unstoppable Force
StringId: ThrowingUnstoppableForce
Skill.Name: Throwing

Skill.Name: Throwing

Name: Full Speed
StringId: RidingFullSpeed
Skill.Name: Riding

Skill.Name: Riding

AlternativePerk.Name: Nimble Steed
AlternativePerk.StringId RidingNimbleStead

Name: Nimble Steed
StringId: RidingNimbleStead
Skill.Name: Riding

Skill.Name: Riding

AlternativePerk.Name: Full Speed
AlternativePerk.StringId RidingFullSpeed

Name: Well Strapped
StringId: RidingWellStraped
Skill.Name: Riding

Skill.Name: Riding

AlternativePerk.Name: Veterinary
AlternativePerk.StringId RidingVeterinary

Name: Veterinary
StringId: RidingVeterinary
Skill.Name: Riding

Skill.Name: Riding

AlternativePerk.Name: Well Strapped
AlternativePerk.StringId RidingWellStraped

Name: Nomadic Traditions
StringId: RidingNomadicTraditions
Skill.Name: Riding

Skill.Name: Riding

AlternativePerk.Name: Filled To Brim
AlternativePerk.StringId RidingFilledToBrim

Name: Filled To Brim
StringId: RidingFilledToBrim
Skill.Name: Riding

Skill.Name: Riding

AlternativePerk.Name: Nomadic Traditions
AlternativePerk.StringId RidingNomadicTraditions

Name: Sagittarius
StringId: RidingSagittarius
Skill.Name: Riding

Skill.Name: Riding

AlternativePerk.Name: Sweeping Wind
AlternativePerk.StringId RidingSweepingWind

Name: Sweeping Wind
StringId: RidingSweepingWind
Skill.Name: Riding

Skill.Name: Riding

AlternativePerk.Name: Sagittarius
AlternativePerk.StringId RidingSagittarius

Name: Relief Force
StringId: RidingReliefForce
Skill.Name: Riding

Skill.Name: Riding

Name: Mounted Warrior
StringId: RidingMountedWarrior
Skill.Name: Riding

Skill.Name: Riding

AlternativePerk.Name: Horse Archer
AlternativePerk.StringId RidingHorseArcher

Name: Horse Archer
StringId: RidingHorseArcher
Skill.Name: Riding

Skill.Name: Riding

AlternativePerk.Name: Mounted Warrior
AlternativePerk.StringId RidingMountedWarrior

Name: Riding Horde
StringId: RidingHorde
Skill.Name: Riding

Skill.Name: Riding

AlternativePerk.Name: Breeder
AlternativePerk.StringId RidingBreeder

Name: Breeder
StringId: RidingBreeder
Skill.Name: Riding

Skill.Name: Riding

AlternativePerk.Name: Riding Horde
AlternativePerk.StringId RidingHorde

Name: Thunderous Charge
StringId: RidingThunderousCharge
Skill.Name: Riding

Skill.Name: Riding

AlternativePerk.Name: Annoying Buzz
AlternativePerk.StringId RidingAnnoyingBuzz

Name: Annoying Buzz
StringId: RidingAnnoyingBuzz
Skill.Name: Riding

Skill.Name: Riding

AlternativePerk.Name: Thunderous Charge
AlternativePerk.StringId RidingThunderousCharge

Name: Mounted Patrols
StringId: RidingMountedPatrols
Skill.Name: Riding

Skill.Name: Riding

AlternativePerk.Name: Cavalry Tactics
AlternativePerk.StringId RidingCavalryTactics

Name: Cavalry Tactics
StringId: RidingCavalryTactics
Skill.Name: Riding

Skill.Name: Riding

AlternativePerk.Name: Mounted Patrols
AlternativePerk.StringId RidingMountedPatrols

Name: Dauntless Steed
StringId: RidingDauntlessSteed
Skill.Name: Riding

Skill.Name: Riding

AlternativePerk.Name: Tough Steed
AlternativePerk.StringId RidingToughSteed

Name: Tough Steed
StringId: RidingToughSteed
Skill.Name: Riding

Skill.Name: Riding

AlternativePerk.Name: Dauntless Steed
AlternativePerk.StringId RidingDauntlessSteed

Name: The Way Of The Saddle
StringId: RidingTheWayOfTheSaddle
Skill.Name: Riding

Skill.Name: Riding

Name: Morning Exercise
StringId: AthleticsMorningExercise
Skill.Name: Athletics

Skill.Name: Athletics

AlternativePerk.Name: Well Built
AlternativePerk.StringId AthleticsWellBuilt

Name: Well Built
StringId: AthleticsWellBuilt
Skill.Name: Athletics

Skill.Name: Athletics

AlternativePerk.Name: Morning Exercise
AlternativePerk.StringId AthleticsMorningExercise

Name: Fury
StringId: AthleticsFury
Skill.Name: Athletics

Skill.Name: Athletics

AlternativePerk.Name: Form Fitting Armor
AlternativePerk.StringId AthleticsFormFittingArmor

Name: Form Fitting Armor
StringId: AthleticsFormFittingArmor
Skill.Name: Athletics

Skill.Name: Athletics

AlternativePerk.Name: Fury
AlternativePerk.StringId AthleticsFury

Name: Having Going
StringId: AthleticsHavingGoing
Skill.Name: Athletics

Skill.Name: Athletics

AlternativePerk.Name: Stamina
AlternativePerk.StringId AthleticsStamina

Name: Stamina
StringId: AthleticsStamina
Skill.Name: Athletics

Skill.Name: Athletics

AlternativePerk.Name: Having Going
AlternativePerk.StringId AthleticsHavingGoing

Name: Sprint
StringId: AthleticsSprint
Skill.Name: Athletics

Skill.Name: Athletics

AlternativePerk.Name: Powerful
AlternativePerk.StringId AthleticsPowerful

Name: Powerful
StringId: AthleticsPowerful
Skill.Name: Athletics

Skill.Name: Athletics

AlternativePerk.Name: Sprint
AlternativePerk.StringId AthleticsSprint

Name: Surging Blow
StringId: AthleticsSurgingBlow
Skill.Name: Athletics

Skill.Name: Athletics

AlternativePerk.Name: Braced
AlternativePerk.StringId AthleticsBraced

Name: Braced
StringId: AthleticsBraced
Skill.Name: Athletics

Skill.Name: Athletics

AlternativePerk.Name: Surging Blow
AlternativePerk.StringId AthleticsSurgingBlow

Name: Walk It Off
StringId: AthleticsWalkItOff
Skill.Name: Athletics

Skill.Name: Athletics

AlternativePerk.Name: A Good Days Rest
AlternativePerk.StringId AthleticsAGoodDaysRest

Name: A Good Days Rest
StringId: AthleticsAGoodDaysRest
Skill.Name: Athletics

Skill.Name: Athletics

AlternativePerk.Name: Walk It Off
AlternativePerk.StringId AthleticsWalkItOff

Name: Healthy Citizens
StringId: AthleticsHealthyCitizens
Skill.Name: Athletics

Skill.Name: Athletics

AlternativePerk.Name: Energetic
AlternativePerk.StringId AthleticsEnergetic

Name: Energetic
StringId: AthleticsEnergetic
Skill.Name: Athletics

Skill.Name: Athletics

AlternativePerk.Name: Healthy Citizens
AlternativePerk.StringId AthleticsHealthyCitizens

Name: Steady
StringId: AthleticsSteady
Skill.Name: Athletics

Skill.Name: Athletics

AlternativePerk.Name: Strong
AlternativePerk.StringId AthleticsStrong

Name: Strong
StringId: AthleticsStrong
Skill.Name: Athletics

Skill.Name: Athletics

AlternativePerk.Name: Steady
AlternativePerk.StringId AthleticsSteady

Name: Strong Legs
StringId: AthleticsStrongLegs
Skill.Name: Athletics

Skill.Name: Athletics

AlternativePerk.Name: Strong Arms
AlternativePerk.StringId AthleticsStrongArms

Name: Strong Arms
StringId: AthleticsStrongArms
Skill.Name: Athletics

Skill.Name: Athletics

AlternativePerk.Name: Strong Legs
AlternativePerk.StringId AthleticsStrongLegs

Name: Spartan
StringId: AthleticsSpartan
Skill.Name: Athletics

Skill.Name: Athletics

AlternativePerk.Name: Ignore Pain
AlternativePerk.StringId AthleticsIgnorePain

Name: Ignore Pain
StringId: AthleticsIgnorePain
Skill.Name: Athletics

Skill.Name: Athletics

AlternativePerk.Name: Spartan
AlternativePerk.StringId AthleticsSpartan

Name: Mighty Blow 
StringId: AthleticsMightyBlow
Skill.Name: Athletics

Skill.Name: Athletics

Name: Sharpened Edge
StringId: CraftingSharpenedEdge
Skill.Name: Smithing

Skill.Name: Smithing

AlternativePerk.Name: Sharpened Tip
AlternativePerk.StringId CraftingSharpenedTip

Name: Sharpened Tip
StringId: CraftingSharpenedTip
Skill.Name: Smithing

Skill.Name: Smithing

AlternativePerk.Name: Sharpened Edge
AlternativePerk.StringId CraftingSharpenedEdge

Name: Efficient Iron Maker
StringId: IronYield
Skill.Name: Smithing

Skill.Name: Smithing

AlternativePerk.Name: Efficient Charcoal Maker
AlternativePerk.StringId CharcoalYield

Name: Efficient Charcoal Maker
StringId: CharcoalYield
Skill.Name: Smithing

Skill.Name: Smithing

AlternativePerk.Name: Efficient Iron Maker
AlternativePerk.StringId IronYield

Name: Steel Maker
StringId: SteelMaker
Skill.Name: Smithing

Skill.Name: Smithing

AlternativePerk.Name: Curious Smelter
AlternativePerk.StringId CuriousSmelter

Name: Steel Maker 2
StringId: SteelMaker2
Skill.Name: Smithing

Skill.Name: Smithing

AlternativePerk.Name: Curious Smith
AlternativePerk.StringId CuriousSmith

Name: Steel Maker 3
StringId: SteelMaker3
Skill.Name: Smithing

Skill.Name: Smithing

AlternativePerk.Name: Experienced Smith
AlternativePerk.StringId ExperiencedSmith

Name: Curious Smelter
StringId: CuriousSmelter
Skill.Name: Smithing

Skill.Name: Smithing

AlternativePerk.Name: Steel Maker
AlternativePerk.StringId SteelMaker

Name: Curious Smith
StringId: CuriousSmith
Skill.Name: Smithing

Skill.Name: Smithing

AlternativePerk.Name: Steel Maker 2
AlternativePerk.StringId SteelMaker2

Name: Practical Refiner
StringId: PracticalRefiner
Skill.Name: Smithing

Skill.Name: Smithing

AlternativePerk.Name: Practical Smelter
AlternativePerk.StringId PracticalSmelter

Name: Practical Smelter
StringId: PracticalSmelter
Skill.Name: Smithing

Skill.Name: Smithing

AlternativePerk.Name: Practical Refiner
AlternativePerk.StringId PracticalRefiner

Name: Practical Smith
StringId: PracticalSmith
Skill.Name: Smithing

Skill.Name: Smithing

AlternativePerk.Name: Artisan Smith
AlternativePerk.StringId ArtisanSmith

Name: Artisan Smith
StringId: ArtisanSmith
Skill.Name: Smithing

Skill.Name: Smithing

AlternativePerk.Name: Practical Smith
AlternativePerk.StringId PracticalSmith

Name: Experienced Smith
StringId: ExperiencedSmith
Skill.Name: Smithing

Skill.Name: Smithing

AlternativePerk.Name: Steel Maker 3
AlternativePerk.StringId SteelMaker3

Name: Master Smith
StringId: MasterSmith
Skill.Name: Smithing

Skill.Name: Smithing

Name: Legendary Smith
StringId: LegendarySmith
Skill.Name: Smithing

Skill.Name: Smithing

Name: Vigorous Smith
StringId: VigorousSmith
Skill.Name: Smithing

Skill.Name: Smithing

AlternativePerk.Name: Controlled Smith
AlternativePerk.StringId StrongSmith

Name: Controlled Smith
StringId: StrongSmith
Skill.Name: Smithing

Skill.Name: Smithing

AlternativePerk.Name: Vigorous Smith
AlternativePerk.StringId VigorousSmith

Name: Enduring Smith
StringId: EnduringSmith
Skill.Name: Smithing

Skill.Name: Smithing

AlternativePerk.Name: Fencer Smith
AlternativePerk.StringId WeaponMasterSmith

Name: Fencer Smith
StringId: WeaponMasterSmith
Skill.Name: Smithing

Skill.Name: Smithing

AlternativePerk.Name: Enduring Smith
AlternativePerk.StringId EnduringSmith

Name: Tight Formations
StringId: TacticsTightFormations
Skill.Name: Tactics

Skill.Name: Tactics

AlternativePerk.Name: Loose Formations
AlternativePerk.StringId TacticsLooseFormations

Name: Loose Formations
StringId: TacticsLooseFormations
Skill.Name: Tactics

Skill.Name: Tactics

AlternativePerk.Name: Tight Formations
AlternativePerk.StringId TacticsTightFormations

Name: Asymmetrical Warfare
StringId: TacticsAsymmetricalWarfare
Skill.Name: Tactics

Skill.Name: Tactics

AlternativePerk.Name: Proper Engagement
AlternativePerk.StringId TacticsProperEngagement

Name: Proper Engagement
StringId: TacticsProperEngagement
Skill.Name: Tactics

Skill.Name: Tactics

AlternativePerk.Name: Asymmetrical Warfare
AlternativePerk.StringId TacticsAsymmetricalWarfare

Name: Small Unit Tactics
StringId: TacticsSmallUnitTactics
Skill.Name: Tactics

Skill.Name: Tactics

AlternativePerk.Name: Horde Leader
AlternativePerk.StringId TacticsHordeLeader

Name: Horde Leader
StringId: TacticsHordeLeader
Skill.Name: Tactics

Skill.Name: Tactics

AlternativePerk.Name: Small Unit Tactics
AlternativePerk.StringId TacticsSmallUnitTactics

Name: Law Keeper
StringId: TacticsLawkeeper
Skill.Name: Tactics

Skill.Name: Tactics

AlternativePerk.Name: Coaching
AlternativePerk.StringId TacticsCoaching

Name: Coaching
StringId: TacticsCoaching
Skill.Name: Tactics

Skill.Name: Tactics

AlternativePerk.Name: Law Keeper
AlternativePerk.StringId TacticsLawkeeper

Name: Swift Regroup
StringId: TacticsSwiftRegroup
Skill.Name: Tactics

Skill.Name: Tactics

AlternativePerk.Name: Improviser
AlternativePerk.StringId TacticsImproviser

Name: Improviser
StringId: TacticsImproviser
Skill.Name: Tactics

Skill.Name: Tactics

AlternativePerk.Name: Swift Regroup
AlternativePerk.StringId TacticsSwiftRegroup

Name: On The March
StringId: TacticsOnTheMarch
Skill.Name: Tactics

Skill.Name: Tactics

AlternativePerk.Name: Call To Arms
AlternativePerk.StringId TacticsCallToArms

Name: Call To Arms
StringId: TacticsCallToArms
Skill.Name: Tactics

Skill.Name: Tactics

AlternativePerk.Name: On The March
AlternativePerk.StringId TacticsOnTheMarch

Name: Pick Them Of The Walls
StringId: TacticsPickThemOfTheWalls
Skill.Name: Tactics

Skill.Name: Tactics

AlternativePerk.Name: Make Them Pay
AlternativePerk.StringId TacticsMakeThemPay

Name: Make Them Pay
StringId: TacticsMakeThemPay
Skill.Name: Tactics

Skill.Name: Tactics

AlternativePerk.Name: Pick Them Of The Walls
AlternativePerk.StringId TacticsPickThemOfTheWalls

Name: Elite Reserves
StringId: TacticsEliteReserves
Skill.Name: Tactics

Skill.Name: Tactics

AlternativePerk.Name: Encirclement
AlternativePerk.StringId TacticsEncirclement

Name: Encirclement
StringId: TacticsEncirclement
Skill.Name: Tactics

Skill.Name: Tactics

AlternativePerk.Name: Elite Reserves
AlternativePerk.StringId TacticsEliteReserves

Name: Pre Battle Maneuvers
StringId: TacticsPreBattleManeuvers
Skill.Name: Tactics

Skill.Name: Tactics

AlternativePerk.Name: Besieged
AlternativePerk.StringId TacticsBesieged

Name: Besieged
StringId: TacticsBesieged
Skill.Name: Tactics

Skill.Name: Tactics

AlternativePerk.Name: Pre Battle Maneuvers
AlternativePerk.StringId TacticsPreBattleManeuvers

Name: Counter Offensive
StringId: TacticsCounteroffensive
Skill.Name: Tactics

Skill.Name: Tactics

AlternativePerk.Name: Gens d'armes
AlternativePerk.StringId TacticsGensdarmes

Name: Gens d'armes
StringId: TacticsGensdarmes
Skill.Name: Tactics

Skill.Name: Tactics

AlternativePerk.Name: Counter Offensive
AlternativePerk.StringId TacticsCounteroffensive

Name: Tactical Mastery
StringId: TacticsTacticalMastery
Skill.Name: Tactics

Skill.Name: Tactics

Name: Day Traveler
StringId: ScoutingDayTraveler
Skill.Name: Scouting

Skill.Name: Scouting

AlternativePerk.Name: Night Runner
AlternativePerk.StringId ScoutingNightRunner

Name: Night Runner
StringId: ScoutingNightRunner
Skill.Name: Scouting

Skill.Name: Scouting

AlternativePerk.Name: Day Traveler
AlternativePerk.StringId ScoutingDayTraveler

Name: Pathfinder
StringId: ScoutingPathfinder
Skill.Name: Scouting

Skill.Name: Scouting

AlternativePerk.Name: Water Diviner
AlternativePerk.StringId ScoutingWaterDiviner

Name: Water Diviner
StringId: ScoutingWaterDiviner
Skill.Name: Scouting

Skill.Name: Scouting

AlternativePerk.Name: Pathfinder
AlternativePerk.StringId ScoutingPathfinder

Name: Forest Kin
StringId: ScoutingForestKin
Skill.Name: Scouting

Skill.Name: Scouting

AlternativePerk.Name: Desert Born
AlternativePerk.StringId ScoutingDesertBorn

Name: Desert Born
StringId: ScoutingDesertBorn
Skill.Name: Scouting

Skill.Name: Scouting

AlternativePerk.Name: Forest Kin
AlternativePerk.StringId ScoutingForestKin

Name: Forced March
StringId: ScoutingForcedMarch
Skill.Name: Scouting

Skill.Name: Scouting

AlternativePerk.Name: Unburdened
AlternativePerk.StringId ScoutingUnburdened

Name: Unburdened
StringId: ScoutingUnburdened
Skill.Name: Scouting

Skill.Name: Scouting

AlternativePerk.Name: Forced March
AlternativePerk.StringId ScoutingForcedMarch

Name: Tracker
StringId: ScoutingTracker
Skill.Name: Scouting

Skill.Name: Scouting

AlternativePerk.Name: Ranger
AlternativePerk.StringId ScoutingRanger

Name: Ranger
StringId: ScoutingRanger
Skill.Name: Scouting

Skill.Name: Scouting

AlternativePerk.Name: Tracker
AlternativePerk.StringId ScoutingTracker

Name: Mounted Scouts
StringId: ScoutingMountedScouts
Skill.Name: Scouting

Skill.Name: Scouting

AlternativePerk.Name: Patrols
AlternativePerk.StringId ScoutingPatrols

Name: Patrols
StringId: ScoutingPatrols
Skill.Name: Scouting

Skill.Name: Scouting

AlternativePerk.Name: Mounted Scouts
AlternativePerk.StringId ScoutingMountedScouts

Name: Foragers
StringId: ScoutingForagers
Skill.Name: Scouting

Skill.Name: Scouting

AlternativePerk.Name: Beast Whisperer
AlternativePerk.StringId ScoutingBeastWhisperer

Name: Beast Whisperer
StringId: ScoutingBeastWhisperer
Skill.Name: Scouting

Skill.Name: Scouting

AlternativePerk.Name: Foragers
AlternativePerk.StringId ScoutingForagers

Name: Village Network
StringId: ScoutingVillageNetwork
Skill.Name: Scouting

Skill.Name: Scouting

AlternativePerk.Name: Rumour Network
AlternativePerk.StringId ScoutingRumourNetwork

Name: Rumour Network
StringId: ScoutingRumourNetwork
Skill.Name: Scouting

Skill.Name: Scouting

AlternativePerk.Name: Village Network
AlternativePerk.StringId ScoutingVillageNetwork

Name: Vantage Point
StringId: ScoutingVantagePoint
Skill.Name: Scouting

Skill.Name: Scouting

AlternativePerk.Name: Keen Sight
AlternativePerk.StringId ScoutingKeenSight

Name: Keen Sight
StringId: ScoutingKeenSight
Skill.Name: Scouting

Skill.Name: Scouting

AlternativePerk.Name: Vantage Point
AlternativePerk.StringId ScoutingVantagePoint

Name: Vanguard
StringId: ScoutingVanguard
Skill.Name: Scouting

Skill.Name: Scouting

AlternativePerk.Name: Rearguard
AlternativePerk.StringId ScoutingRearguard

Name: Rearguard
StringId: ScoutingRearguard
Skill.Name: Scouting

Skill.Name: Scouting

AlternativePerk.Name: Vanguard
AlternativePerk.StringId ScoutingVanguard

Name: Uncanny Insight
StringId: ScoutingUncannyInsight
Skill.Name: Scouting

Skill.Name: Scouting

Name: No Rest for the Wicked
StringId: RogueryNoRestForTheWicked
Skill.Name: Roguery

Skill.Name: Roguery

AlternativePerk.Name: Sweet Talker
AlternativePerk.StringId RoguerySweetTalker

Name: Sweet Talker
StringId: RoguerySweetTalker
Skill.Name: Roguery

Skill.Name: Roguery

AlternativePerk.Name: No Rest for the Wicked
AlternativePerk.StringId RogueryNoRestForTheWicked

Name: Two Faced
StringId: RogueryTwoFaced
Skill.Name: Roguery

Skill.Name: Roguery

AlternativePerk.Name: Deep Pockets
AlternativePerk.StringId RogueryDeepPockets

Name: Deep Pockets
StringId: RogueryDeepPockets
Skill.Name: Roguery

Skill.Name: Roguery

AlternativePerk.Name: Two Faced
AlternativePerk.StringId RogueryTwoFaced

Name: In Best Light
StringId: RogueryInBestLight
Skill.Name: Roguery

Skill.Name: Roguery

AlternativePerk.Name: Know-How
AlternativePerk.StringId RogueryKnowHow

Name: Know-How
StringId: RogueryKnowHow
Skill.Name: Roguery

Skill.Name: Roguery

AlternativePerk.Name: In Best Light
AlternativePerk.StringId RogueryInBestLight

Name: Promises
StringId: RogueryPromises
Skill.Name: Roguery

Skill.Name: Roguery

AlternativePerk.Name: Slave Trader
AlternativePerk.StringId RoguerySlaveTrader

Name: Slave Trader
StringId: RoguerySlaveTrader
Skill.Name: Roguery

Skill.Name: Roguery

AlternativePerk.Name: Promises
AlternativePerk.StringId RogueryPromises

Name: Scarface
StringId: RogueryScarface
Skill.Name: Roguery

Skill.Name: Roguery

AlternativePerk.Name: White Lies
AlternativePerk.StringId RogueryWhiteLies

Name: White Lies
StringId: RogueryWhiteLies
Skill.Name: Roguery

Skill.Name: Roguery

AlternativePerk.Name: Scarface
AlternativePerk.StringId RogueryScarface

Name: Smuggler Connections
StringId: RoguerySmugglerConnections
Skill.Name: Roguery

Skill.Name: Roguery

AlternativePerk.Name: Partners in Crime
AlternativePerk.StringId RogueryPartnersInCrime

Name: Partners in Crime
StringId: RogueryPartnersInCrime
Skill.Name: Roguery

Skill.Name: Roguery

AlternativePerk.Name: Smuggler Connections
AlternativePerk.StringId RoguerySmugglerConnections

Name: One of the Family
StringId: RogueryOneOfTheFamily
Skill.Name: Roguery

Skill.Name: Roguery

AlternativePerk.Name: Salt the Earth
AlternativePerk.StringId RoguerySaltTheEarth

Name: Salt the Earth
StringId: RoguerySaltTheEarth
Skill.Name: Roguery

Skill.Name: Roguery

AlternativePerk.Name: One of the Family
AlternativePerk.StringId RogueryOneOfTheFamily

Name: Carver
StringId: RogueryCarver
Skill.Name: Roguery

Skill.Name: Roguery

AlternativePerk.Name: Ransom Broker
AlternativePerk.StringId RogueryRansomBroker

Name: Ransom Broker
StringId: RogueryRansomBroker
Skill.Name: Roguery

Skill.Name: Roguery

AlternativePerk.Name: Carver
AlternativePerk.StringId RogueryCarver

Name: Arms Dealer
StringId: RogueryArmsDealer
Skill.Name: Roguery

Skill.Name: Roguery

AlternativePerk.Name: Dirty Fighting
AlternativePerk.StringId RogueryDirtyFighting

Name: Dirty Fighting
StringId: RogueryDirtyFighting
Skill.Name: Roguery

Skill.Name: Roguery

AlternativePerk.Name: Arms Dealer
AlternativePerk.StringId RogueryArmsDealer

Name: Dash and Slash
StringId: RogueryDashAndSlash
Skill.Name: Roguery

Skill.Name: Roguery

AlternativePerk.Name: Fleet Footed
AlternativePerk.StringId RogueryFleetFooted

Name: Fleet Footed
StringId: RogueryFleetFooted
Skill.Name: Roguery

Skill.Name: Roguery

AlternativePerk.Name: Dash and Slash
AlternativePerk.StringId RogueryDashAndSlash

Name: Rogue Extraordinaire
StringId: RogueryRogueExtraordinaire
Skill.Name: Roguery

Skill.Name: Roguery

Name: Combat Tips
StringId: LeadershipCombatTips
Skill.Name: Leadership

Skill.Name: Leadership

AlternativePerk.Name: Raise The Meek
AlternativePerk.StringId LeadershipRaiseTheMeek

Name: Raise The Meek
StringId: LeadershipRaiseTheMeek
Skill.Name: Leadership

Skill.Name: Leadership

AlternativePerk.Name: Combat Tips
AlternativePerk.StringId LeadershipCombatTips

Name: Fervent Attacker
StringId: LeadershipFerventAttacker
Skill.Name: Leadership

Skill.Name: Leadership

AlternativePerk.Name: Stout Defender
AlternativePerk.StringId LeadershipStoutDefender

Name: Stout Defender
StringId: LeadershipStoutDefender
Skill.Name: Leadership

Skill.Name: Leadership

AlternativePerk.Name: Fervent Attacker
AlternativePerk.StringId LeadershipFerventAttacker

Name: Authority
StringId: LeadershipAuthority
Skill.Name: Leadership

Skill.Name: Leadership

AlternativePerk.Name: Heroic Leader
AlternativePerk.StringId LeadershipHeroicLeader

Name: Heroic Leader
StringId: LeadershipHeroicLeader
Skill.Name: Leadership

Skill.Name: Leadership

AlternativePerk.Name: Authority
AlternativePerk.StringId LeadershipAuthority

Name: Loyalty and Honor
StringId: LeadershipLoyaltyAndHonor
Skill.Name: Leadership

Skill.Name: Leadership

AlternativePerk.Name: Famous Commander
AlternativePerk.StringId LeadershipFamousCommander

Name: Famous Commander
StringId: LeadershipFamousCommander
Skill.Name: Leadership

Skill.Name: Leadership

AlternativePerk.Name: Loyalty and Honor
AlternativePerk.StringId LeadershipLoyaltyAndHonor

Name: Presence
StringId: LeadershipPresence
Skill.Name: Leadership

Skill.Name: Leadership

AlternativePerk.Name: Leader of the Masses
AlternativePerk.StringId LeadershipLeaderOfMasses

Name: Leader of the Masses
StringId: LeadershipLeaderOfMasses
Skill.Name: Leadership

Skill.Name: Leadership

AlternativePerk.Name: Presence
AlternativePerk.StringId LeadershipPresence

Name: Veteran's Respect
StringId: LeadershipVeteransRespect
Skill.Name: Leadership

Skill.Name: Leadership

AlternativePerk.Name: Citizen Militia
AlternativePerk.StringId LeadershipCitizenMilitia

Name: Citizen Militia
StringId: LeadershipCitizenMilitia
Skill.Name: Leadership

Skill.Name: Leadership

AlternativePerk.Name: Veteran's Respect
AlternativePerk.StringId LeadershipVeteransRespect

Name: Inspiring Leader
StringId: LeadershipInspiringLeader
Skill.Name: Leadership

Skill.Name: Leadership

AlternativePerk.Name: Uplifting Spirit
AlternativePerk.StringId LeadershipUpliftingSpirit

Name: Uplifting Spirit
StringId: LeadershipUpliftingSpirit
Skill.Name: Leadership

Skill.Name: Leadership

AlternativePerk.Name: Inspiring Leader
AlternativePerk.StringId LeadershipInspiringLeader

Name: Make a Difference
StringId: LeadershipMakeADifference
Skill.Name: Leadership

Skill.Name: Leadership

AlternativePerk.Name: Lead by Example
AlternativePerk.StringId LeadershipLeadByExample

Name: Lead by Example
StringId: LeadershipLeadByExample
Skill.Name: Leadership

Skill.Name: Leadership

AlternativePerk.Name: Make a Difference
AlternativePerk.StringId LeadershipMakeADifference

Name: Trusted Commander
StringId: LeadershipTrustedCommander
Skill.Name: Leadership

Skill.Name: Leadership

AlternativePerk.Name: Great Leader
AlternativePerk.StringId LeadershipGreatLeader

Name: Great Leader
StringId: LeadershipGreatLeader
Skill.Name: Leadership

Skill.Name: Leadership

AlternativePerk.Name: Trusted Commander
AlternativePerk.StringId LeadershipTrustedCommander

Name: We Pledge our Swords
StringId: LeadershipWePledgeOurSwords
Skill.Name: Leadership

Skill.Name: Leadership

AlternativePerk.Name: Talent Magnet
AlternativePerk.StringId LeadershipTalentMagnet

Name: Talent Magnet
StringId: LeadershipTalentMagnet
Skill.Name: Leadership

Skill.Name: Leadership

AlternativePerk.Name: We Pledge our Swords
AlternativePerk.StringId LeadershipWePledgeOurSwords

Name: Ultimate Leader
StringId: LeadershipUltimateLeader
Skill.Name: Leadership

Skill.Name: Leadership

Name: Ice Breaker
StringId: CharmIceBreaker
Skill.Name: Charm

Skill.Name: Charm

AlternativePerk.Name: Diplomacy
AlternativePerk.StringId CharmDiplomacy

Name: Diplomacy
StringId: CharmDiplomacy
Skill.Name: Charm

Skill.Name: Charm

AlternativePerk.Name: Ice Breaker
AlternativePerk.StringId CharmIceBreaker

Name: Adventure Stories
StringId: CharmAdventureStories
Skill.Name: Charm

Skill.Name: Charm

AlternativePerk.Name: Show Your Scars
AlternativePerk.StringId CharmShowYourScars

Name: Show Your Scars
StringId: CharmShowYourScars
Skill.Name: Charm

Skill.Name: Charm

AlternativePerk.Name: Adventure Stories
AlternativePerk.StringId CharmAdventureStories

Name: Forgivable Grievances
StringId: CharmForgivableGrievances
Skill.Name: Charm

Skill.Name: Charm

AlternativePerk.Name: Meaningful Favors
AlternativePerk.StringId CharmMeaningfulFavors

Name: Meaningful Favors
StringId: CharmMeaningfulFavors
Skill.Name: Charm

Skill.Name: Charm

AlternativePerk.Name: Forgivable Grievances
AlternativePerk.StringId CharmForgivableGrievances

Name: In Bloom
StringId: CharmInBloom
Skill.Name: Charm

Skill.Name: Charm

AlternativePerk.Name: Young and Respectful
AlternativePerk.StringId CharmYoungAndRespectful

Name: Young and Respectful
StringId: CharmYoungAndRespectful
Skill.Name: Charm

Skill.Name: Charm

AlternativePerk.Name: In Bloom
AlternativePerk.StringId CharmInBloom

Name: Champion
StringId: CharmChampion
Skill.Name: Charm

Skill.Name: Charm

AlternativePerk.Name: Respectful Opposition
AlternativePerk.StringId CharmRespectfulOpposition

Name: Respectful Opposition
StringId: CharmRespectfulOpposition
Skill.Name: Charm

Skill.Name: Charm

AlternativePerk.Name: Champion
AlternativePerk.StringId CharmChampion

Name: Effort For The People
StringId: CharmEffortForThePeople
Skill.Name: Charm

Skill.Name: Charm

AlternativePerk.Name: Promoter
AlternativePerk.StringId CharmPromoter

Name: Promoter
StringId: CharmPromoter
Skill.Name: Charm

Skill.Name: Charm

AlternativePerk.Name: Effort For The People
AlternativePerk.StringId CharmEffortForThePeople

Name: Our Glorious Leader
StringId: CharmOurGloriousLeader
Skill.Name: Charm

Skill.Name: Charm

AlternativePerk.Name: Pro Familia
AlternativePerk.StringId CharmForTheFamilia

Name: Pro Familia
StringId: CharmForTheFamilia
Skill.Name: Charm

Skill.Name: Charm

AlternativePerk.Name: Our Glorious Leader
AlternativePerk.StringId CharmOurGloriousLeader

Name: Moral Leader
StringId: CharmMoralLeader
Skill.Name: Charm

Skill.Name: Charm

AlternativePerk.Name: Natural Leader
AlternativePerk.StringId CharmNaturalLeader

Name: Natural Leader
StringId: CharmNaturalLeader
Skill.Name: Charm

Skill.Name: Charm

AlternativePerk.Name: Moral Leader
AlternativePerk.StringId CharmMoralLeader

Name: Courtship
StringId: CharmCourtship
Skill.Name: Charm

Skill.Name: Charm

AlternativePerk.Name: Parade
AlternativePerk.StringId CharmParade

Name: Parade
StringId: CharmParade
Skill.Name: Charm

Skill.Name: Charm

AlternativePerk.Name: Courtship
AlternativePerk.StringId CharmCourtship

Name: Immortal Charm
StringId: CharmImmortalCharm
Skill.Name: Charm

Skill.Name: Charm

Name: Appraiser
StringId: TradeAppraiser
Skill.Name: Trade

Skill.Name: Trade

AlternativePerk.Name: Whole Seller
AlternativePerk.StringId TradeWholeSeller

Name: Whole Seller
StringId: TradeWholeSeller
Skill.Name: Trade

Skill.Name: Trade

AlternativePerk.Name: Appraiser
AlternativePerk.StringId TradeAppraiser

Name: Caravan Master
StringId: TradeCaravanMaster
Skill.Name: Trade

Skill.Name: Trade

AlternativePerk.Name: Market Dealer
AlternativePerk.StringId TradeMarketDealer

Name: Market Dealer
StringId: TradeMarketDealer
Skill.Name: Trade

Skill.Name: Trade

AlternativePerk.Name: Caravan Master
AlternativePerk.StringId TradeCaravanMaster

Name: Traveling Rumors
StringId: TradeTravelingRumors
Skill.Name: Trade

Skill.Name: Trade

AlternativePerk.Name: Local Connection
AlternativePerk.StringId TradeLocalConnection

Name: Local Connection
StringId: TradeLocalConnection
Skill.Name: Trade

Skill.Name: Trade

AlternativePerk.Name: Traveling Rumors
AlternativePerk.StringId TradeTravelingRumors

Name: Distributed Goods
StringId: TradeDistributedGoods
Skill.Name: Trade

Skill.Name: Trade

AlternativePerk.Name: Toll Gates
AlternativePerk.StringId TradeTollgates

Name: Toll Gates
StringId: TradeTollgates
Skill.Name: Trade

Skill.Name: Trade

AlternativePerk.Name: Distributed Goods
AlternativePerk.StringId TradeDistributedGoods

Name: Artisan Community
StringId: TradeArtisanCommunity
Skill.Name: Trade

Skill.Name: Trade

AlternativePerk.Name: Great Investor
AlternativePerk.StringId TradeGreatInvestor

Name: Great Investor
StringId: TradeGreatInvestor
Skill.Name: Trade

Skill.Name: Trade

AlternativePerk.Name: Artisan Community
AlternativePerk.StringId TradeArtisanCommunity

Name: Villager Connections
StringId: TradeVillagerConnections
Skill.Name: Trade

Skill.Name: Trade

AlternativePerk.Name: Content Trades
AlternativePerk.StringId TradeContentTrades

Name: Content Trades
StringId: TradeContentTrades
Skill.Name: Trade

Skill.Name: Trade

AlternativePerk.Name: Villager Connections
AlternativePerk.StringId TradeVillagerConnections

Name: Insurance Plans
StringId: TradeInsurancePlans
Skill.Name: Trade

Skill.Name: Trade

AlternativePerk.Name: Rapid Development
AlternativePerk.StringId TradeRapidDevelopment

Name: Rapid Development
StringId: TradeRapidDevelopment
Skill.Name: Trade

Skill.Name: Trade

AlternativePerk.Name: Insurance Plans
AlternativePerk.StringId TradeInsurancePlans

Name: Granary Accountant
StringId: TradeGranaryAccountant
Skill.Name: Trade

Skill.Name: Trade

AlternativePerk.Name: Tradeyard Foreman
AlternativePerk.StringId TradeTradeyardForeman

Name: Tradeyard Foreman
StringId: TradeTradeyardForeman
Skill.Name: Trade

Skill.Name: Trade

AlternativePerk.Name: Granary Accountant
AlternativePerk.StringId TradeGranaryAccountant

Name: Sword For Barter
StringId: TradeSwordForBarter
Skill.Name: Trade

Skill.Name: Trade

AlternativePerk.Name: Self Made Man
AlternativePerk.StringId TradeSelfMadeMan

Name: Self Made Man
StringId: TradeSelfMadeMan
Skill.Name: Trade

Skill.Name: Trade

AlternativePerk.Name: Sword For Barter
AlternativePerk.StringId TradeSwordForBarter

Name: Silver Tongue
StringId: TradeSilverTongue
Skill.Name: Trade

Skill.Name: Trade

AlternativePerk.Name: Spring of Gold
AlternativePerk.StringId TradeSpringOfGold

Name: Spring of Gold
StringId: TradeSpringOfGold
Skill.Name: Trade

Skill.Name: Trade

AlternativePerk.Name: Silver Tongue
AlternativePerk.StringId TradeSilverTongue

Name: Man of Means
StringId: TradeManOfMeans
Skill.Name: Trade

Skill.Name: Trade

AlternativePerk.Name: Trickle Down
AlternativePerk.StringId TradeTrickleDown

Name: Trickle Down
StringId: TradeTrickleDown
Skill.Name: Trade

Skill.Name: Trade

AlternativePerk.Name: Man of Means
AlternativePerk.StringId TradeManOfMeans

Name: Everything Has a Price
StringId: TradeEverythingHasAPrice
Skill.Name: Trade

Skill.Name: Trade

Name: Spartan
StringId: StewardSpartan
Skill.Name: Steward

Skill.Name: Steward

AlternativePerk.Name: Frugal
AlternativePerk.StringId StewardFrugal

Name: Frugal
StringId: StewardFrugal
Skill.Name: Steward

Skill.Name: Steward

AlternativePerk.Name: Spartan
AlternativePerk.StringId StewardSpartan

Name: Seven Veterans
StringId: StewardSevenVeterans
Skill.Name: Steward

Skill.Name: Steward

AlternativePerk.Name: Drill Sergeant
AlternativePerk.StringId StewardDrillSergant

Name: Drill Sergeant
StringId: StewardDrillSergant
Skill.Name: Steward

Skill.Name: Steward

AlternativePerk.Name: Seven Veterans
AlternativePerk.StringId StewardSevenVeterans

Name: Sweatshops
StringId: StewardSweatshops
Skill.Name: Steward

Skill.Name: Steward

AlternativePerk.Name: Stiff Upper Lip
AlternativePerk.StringId StewardStiffUpperLip

Name: Stiff Upper Lip
StringId: StewardStiffUpperLip
Skill.Name: Steward

Skill.Name: Steward

AlternativePerk.Name: Sweatshops
AlternativePerk.StringId StewardSweatshops

Name: Paid in Promise
StringId: StewardPaidInPromise
Skill.Name: Steward

Skill.Name: Steward

AlternativePerk.Name: Efficient Campaigner
AlternativePerk.StringId StewardEfficientCampaigner

Name: Efficient Campaigner
StringId: StewardEfficientCampaigner
Skill.Name: Steward

Skill.Name: Steward

AlternativePerk.Name: Paid in Promise
AlternativePerk.StringId StewardPaidInPromise

Name: Giving Hands
StringId: StewardForeseeableFuture
Skill.Name: Steward

Skill.Name: Steward

AlternativePerk.Name: Logistician
AlternativePerk.StringId StewardLogistician

Name: Logistician
StringId: StewardLogistician
Skill.Name: Steward

Skill.Name: Steward

AlternativePerk.Name: Giving Hands
AlternativePerk.StringId StewardForeseeableFuture

Name: Relocation
StringId: StewardRelocation
Skill.Name: Steward

Skill.Name: Steward

AlternativePerk.Name: Aid Corps
AlternativePerk.StringId StewardAidCorps

Name: Aid Corps
StringId: StewardAidCorps
Skill.Name: Steward

Skill.Name: Steward

AlternativePerk.Name: Relocation
AlternativePerk.StringId StewardRelocation

Name: Gourmet
StringId: StewardGourmet
Skill.Name: Steward

Skill.Name: Steward

AlternativePerk.Name: Sound Reserves
AlternativePerk.StringId StewardSoundReserves

Name: Sound Reserves
StringId: StewardSoundReserves
Skill.Name: Steward

Skill.Name: Steward

AlternativePerk.Name: Gourmet
AlternativePerk.StringId StewardGourmet

Name: Forced Labor
StringId: StewardForcedLabor
Skill.Name: Steward

Skill.Name: Steward

AlternativePerk.Name: Contractors
AlternativePerk.StringId StewardContractors

Name: Contractors
StringId: StewardContractors
Skill.Name: Steward

Skill.Name: Steward

AlternativePerk.Name: Forced Labor
AlternativePerk.StringId StewardForcedLabor

Name: Arenicos' Mules
StringId: StewardArenicosMules
Skill.Name: Steward

Skill.Name: Steward

AlternativePerk.Name: Arenicos' Horses
AlternativePerk.StringId StewardArenicosHorses

Name: Arenicos' Horses
StringId: StewardArenicosHorses
Skill.Name: Steward

Skill.Name: Steward

AlternativePerk.Name: Arenicos' Mules
AlternativePerk.StringId StewardArenicosMules

Name: Urban Developer
StringId: StewardUrbanDeveloper
Skill.Name: Steward

Skill.Name: Steward

AlternativePerk.Name: Master of Warcraft
AlternativePerk.StringId StewardMasterOfWarcraft

Name: Master of Warcraft
StringId: StewardMasterOfWarcraft
Skill.Name: Steward

Skill.Name: Steward

AlternativePerk.Name: Urban Developer
AlternativePerk.StringId StewardUrbanDeveloper

Name: Price of Loyalty
StringId: StewardPriceOfLoyalty
Skill.Name: Steward

Skill.Name: Steward

Name: Self Medication
StringId: MedicineSelfMedication
Skill.Name: Medicine

Skill.Name: Medicine

AlternativePerk.Name: Preventive Medicine
AlternativePerk.StringId MedicinePreventiveMedicine

Name: Preventive Medicine
StringId: MedicinePreventiveMedicine
Skill.Name: Medicine

Skill.Name: Medicine

AlternativePerk.Name: Self Medication
AlternativePerk.StringId MedicineSelfMedication

Name: Triage Tent
StringId: MedicineTriageTent
Skill.Name: Medicine

Skill.Name: Medicine

AlternativePerk.Name: Walk It Off
AlternativePerk.StringId MedicineWalkItOff

Name: Walk It Off
StringId: MedicineWalkItOff
Skill.Name: Medicine

Skill.Name: Medicine

AlternativePerk.Name: Triage Tent
AlternativePerk.StringId MedicineTriageTent

Name: Sledges
StringId: MedicineSledges
Skill.Name: Medicine

Skill.Name: Medicine

AlternativePerk.Name: Doctors Oath
AlternativePerk.StringId MedicineDoctorsOath

Name: Doctors Oath
StringId: MedicineDoctorsOath
Skill.Name: Medicine

Skill.Name: Medicine

AlternativePerk.Name: Sledges
AlternativePerk.StringId MedicineSledges

Name: Best Medicine
StringId: MedicineBestMedicine
Skill.Name: Medicine

Skill.Name: Medicine

AlternativePerk.Name: Good Lodging
AlternativePerk.StringId MedicineGoodLodging

Name: Good Lodging
StringId: MedicineGoodLodging
Skill.Name: Medicine

Skill.Name: Medicine

AlternativePerk.Name: Best Medicine
AlternativePerk.StringId MedicineBestMedicine

Name: Siege Medic
StringId: MedicineSiegeMedic
Skill.Name: Medicine

Skill.Name: Medicine

AlternativePerk.Name: Veterinarian
AlternativePerk.StringId MedicineVeterinarian

Name: Veterinarian
StringId: MedicineVeterinarian
Skill.Name: Medicine

Skill.Name: Medicine

AlternativePerk.Name: Siege Medic
AlternativePerk.StringId MedicineSiegeMedic

Name: Pristine Streets
StringId: MedicinePristineStreets
Skill.Name: Medicine

Skill.Name: Medicine

AlternativePerk.Name: Bush Doctor
AlternativePerk.StringId MedicineBushDoctor

Name: Bush Doctor
StringId: MedicineBushDoctor
Skill.Name: Medicine

Skill.Name: Medicine

AlternativePerk.Name: Pristine Streets
AlternativePerk.StringId MedicinePristineStreets

Name: Perfect Health
StringId: MedicinePerfectHealth
Skill.Name: Medicine

Skill.Name: Medicine

AlternativePerk.Name: Health Advice
AlternativePerk.StringId MedicineHealthAdvise

Name: Health Advice
StringId: MedicineHealthAdvise
Skill.Name: Medicine

Skill.Name: Medicine

AlternativePerk.Name: Perfect Health
AlternativePerk.StringId MedicinePerfectHealth

Name: Physician of People
StringId: MedicinePhysicianOfPeople
Skill.Name: Medicine

Skill.Name: Medicine

AlternativePerk.Name: Clean Infrastructure
AlternativePerk.StringId MedicineCleanInfrastructure

Name: Clean Infrastructure
StringId: MedicineCleanInfrastructure
Skill.Name: Medicine

Skill.Name: Medicine

AlternativePerk.Name: Physician of People
AlternativePerk.StringId MedicinePhysicianOfPeople

Name: Cheat Death
StringId: MedicineCheatDeath
Skill.Name: Medicine

Skill.Name: Medicine

AlternativePerk.Name: Fortitude Tonic
AlternativePerk.StringId MedicineFortitudeTonic

Name: Fortitude Tonic
StringId: MedicineFortitudeTonic
Skill.Name: Medicine

Skill.Name: Medicine

AlternativePerk.Name: Cheat Death
AlternativePerk.StringId MedicineCheatDeath

Name: Helping Hands
StringId: MedicineHelpingHands
Skill.Name: Medicine

Skill.Name: Medicine

AlternativePerk.Name: Battle Hardened
AlternativePerk.StringId MedicineBattleHardened

Name: Battle Hardened
StringId: MedicineBattleHardened
Skill.Name: Medicine

Skill.Name: Medicine

AlternativePerk.Name: Helping Hands
AlternativePerk.StringId MedicineHelpingHands

Name: Minister of Health
StringId: MedicineMinisterOfHealth
Skill.Name: Medicine

Skill.Name: Medicine

Name: Scaffolds
StringId: EngineeringScaffolds
Skill.Name: Engineering

Skill.Name: Engineering

AlternativePerk.Name: Torsion Engines
AlternativePerk.StringId EngineeringTorsionEngines

Name: Torsion Engines
StringId: EngineeringTorsionEngines
Skill.Name: Engineering

Skill.Name: Engineering

AlternativePerk.Name: Scaffolds
AlternativePerk.StringId EngineeringScaffolds

Name: Siegeworks
StringId: EngineeringSiegeWorks
Skill.Name: Engineering

Skill.Name: Engineering

AlternativePerk.Name: Prison Architect
AlternativePerk.StringId EngineeringPrisonArchitect

Name: Prison Architect
StringId: EngineeringPrisonArchitect
Skill.Name: Engineering

Skill.Name: Engineering

AlternativePerk.Name: Siegeworks
AlternativePerk.StringId EngineeringSiegeWorks

Name: Carpenters
StringId: EngineeringCarpenters
Skill.Name: Engineering

Skill.Name: Engineering

AlternativePerk.Name: Military Planner
AlternativePerk.StringId EngineeringMilitaryPlanner

Name: Military Planner
StringId: EngineeringMilitaryPlanner
Skill.Name: Engineering

Skill.Name: Engineering

AlternativePerk.Name: Carpenters
AlternativePerk.StringId EngineeringCarpenters

Name: Wall Breaker
StringId: EngineeringWallBreaker
Skill.Name: Engineering

Skill.Name: Engineering

AlternativePerk.Name: Dreadful Besieger
AlternativePerk.StringId EngineeringDreadfulSieger

Name: Dreadful Besieger
StringId: EngineeringDreadfulSieger
Skill.Name: Engineering

Skill.Name: Engineering

AlternativePerk.Name: Wall Breaker
AlternativePerk.StringId EngineeringWallBreaker

Name: Salvager
StringId: EngineeringSalvager
Skill.Name: Engineering

Skill.Name: Engineering

AlternativePerk.Name: Foreman
AlternativePerk.StringId EngineeringForeman

Name: Foreman
StringId: EngineeringForeman
Skill.Name: Engineering

Skill.Name: Engineering

AlternativePerk.Name: Salvager
AlternativePerk.StringId EngineeringSalvager

Name: Stonecutters
StringId: EngineeringStonecutters
Skill.Name: Engineering

Skill.Name: Engineering

AlternativePerk.Name: Siege Engineer
AlternativePerk.StringId EngineeringSiegeEngineer

Name: Siege Engineer
StringId: EngineeringSiegeEngineer
Skill.Name: Engineering

Skill.Name: Engineering

AlternativePerk.Name: Stonecutters
AlternativePerk.StringId EngineeringStonecutters

Name: Camp Building
StringId: EngineeringCampBuilding
Skill.Name: Engineering

Skill.Name: Engineering

AlternativePerk.Name: Battlements
AlternativePerk.StringId EngineeringBattlements

Name: Battlements
StringId: EngineeringBattlements
Skill.Name: Engineering

Skill.Name: Engineering

AlternativePerk.Name: Camp Building
AlternativePerk.StringId EngineeringCampBuilding

Name: Engineering Guilds
StringId: EngineeringEngineeringGuilds
Skill.Name: Engineering

Skill.Name: Engineering

AlternativePerk.Name: Apprenticeship
AlternativePerk.StringId EngineeringApprenticeship

Name: Apprenticeship
StringId: EngineeringApprenticeship
Skill.Name: Engineering

Skill.Name: Engineering

AlternativePerk.Name: Engineering Guilds
AlternativePerk.StringId EngineeringEngineeringGuilds

Name: Metallurgy
StringId: EngineeringMetallurgy
Skill.Name: Engineering

Skill.Name: Engineering

AlternativePerk.Name: Improved Tools
AlternativePerk.StringId EngineeringImprovedTools

Name: Improved Tools
StringId: EngineeringImprovedTools
Skill.Name: Engineering

Skill.Name: Engineering

AlternativePerk.Name: Metallurgy
AlternativePerk.StringId EngineeringMetallurgy

Name: Clockwork
StringId: EngineeringClockwork
Skill.Name: Engineering

Skill.Name: Engineering

AlternativePerk.Name: Architectural Commissions
AlternativePerk.StringId EngineeringArchitecturalCommissions

Name: Architectural Commissions
StringId: EngineeringArchitecturalCommissions
Skill.Name: Engineering

Skill.Name: Engineering

AlternativePerk.Name: Clockwork
AlternativePerk.StringId EngineeringClockwork

Name: Masterwork
StringId: EngineeringMasterwork
Skill.Name: Engineering

Skill.Name: Engineering






 */