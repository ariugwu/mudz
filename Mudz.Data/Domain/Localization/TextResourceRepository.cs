using System;
using System.Collections.Generic;
using System.Linq;
using Mudz.Data.Domain.Localization.Model;

namespace Mudz.Data.Domain.Localization
{
    //TODO: Future Session - Deep dive into the repository pattern.
    public static class TextResourceRepository
    {
        //TODO: Future Session - Deep dive into the iterator pattern
        public static IEnumerable<TextResource> GetResources()
        {
            //* CannotRespondRoom
            yield return new TextResource() { TextResourceName = TextResourceName.CannotRespondRoomMessage, Culture = "en-us", Content = "{0} begins to move and then collapses!" };
            yield return new TextResource() { TextResourceName = TextResourceName.CannotRespondPlayerMessage, Culture = "en-us", Content = "You try to move and collapse. Perhaps you need rest?" };
            yield return new TextResource() { TextResourceName = TextResourceName.CannotRespondTargetMessage, Culture = "en-us", Content = "" };

            //* NotEnoughStamina
            yield return new TextResource() { TextResourceName = TextResourceName.NotEnoughStaminaRoomMessage, Culture = "en-us", Content = "{0} does not have enough stamina (turns) to complete this action!" };
            yield return new TextResource() { TextResourceName = TextResourceName.NotEnoughStaminaPlayerMessage, Culture = "en-us", Content = "You do not have enough stamia (turns) to complete this action!" };
            yield return new TextResource() { TextResourceName = TextResourceName.NotEnoughStaminaTargetMessage, Culture = "en-us", Content = "" };

            //* Fight
            yield return new TextResource() { TextResourceName = TextResourceName.FightRoomMessage, Culture = "en-us", Content = "{0} attacks {1} for {2} damage!" };
            yield return new TextResource() { TextResourceName = TextResourceName.FightPlayerMessage, Culture = "en-us", Content = "You attack {0} for {1} damage!" };
            yield return new TextResource() { TextResourceName = TextResourceName.FightTargetMessage, Culture = "en-us", Content = "{0} attacks you for {1} damage!" };

            //* Heal
            yield return new TextResource() { TextResourceName = TextResourceName.HealRoomMessage, Culture = "en-us", Content = "{0} heals {1} for {2} damage!" };
            yield return new TextResource() { TextResourceName = TextResourceName.HealPlayerMessage, Culture = "en-us", Content = "You heal {0} for {1} damage!" };
            yield return new TextResource() { TextResourceName = TextResourceName.HealTargetMessage, Culture = "en-us", Content = "{0} heals you for {1} damage!" };

            //* Repair
            yield return new TextResource() { TextResourceName = TextResourceName.RepairRoomMessage, Culture = "en-us", Content = "{0} repairs {1} for {2} hit points!" };
            yield return new TextResource() { TextResourceName = TextResourceName.RepairPlayerMessage, Culture = "en-us", Content = "You repair {0} for {1} hit points!" };
            yield return new TextResource() { TextResourceName = TextResourceName.RepairTargetMessage, Culture = "en-us", Content = "{0} tries to wrap you in duct tape but you wiggle free!" };

            //* Negotiate
            yield return new TextResource() { TextResourceName = TextResourceName.NegotiateRoomMessage, Culture = "en-us", Content = "{0} negotiates with {1} for {2} points!" };
            yield return new TextResource() { TextResourceName = TextResourceName.NegotiatePlayerMessage, Culture = "en-us", Content = "You negotiate with {0} for {1} points!" };
            yield return new TextResource() { TextResourceName = TextResourceName.NegotiateTargetMessage, Culture = "en-us", Content = "{0} negotiates with you for {1} points!" };

            //* Welcome
            yield return new TextResource() { TextResourceName = TextResourceName.WelcomeRoomMessage, Culture = "en-us", Content = "{0} has entered the game!" };
            yield return new TextResource() { TextResourceName = TextResourceName.WelcomePlayerMessage, Culture = "en-us", Content = "Welcome back {0}!" };
            yield return new TextResource() { TextResourceName = TextResourceName.WelcomeTargetMessage, Culture = "en-us", Content = "" };

            //* Get (item)
            yield return new TextResource() { TextResourceName = TextResourceName.GetItemRoomMessage, Culture = "en-us", Content = "{0} takes {1} and quickly hides it away." };
            yield return new TextResource() { TextResourceName = TextResourceName.GetItemPlayerMessage, Culture = "en-us", Content = "You take {0} and quickly hides it away." };
            yield return new TextResource() { TextResourceName = TextResourceName.GetItemTargetMessage, Culture = "en-us", Content = "" };

            //* Death
            yield return new TextResource() { TextResourceName = TextResourceName.DeathRoomMessage, Culture = "en-us", Content = "{0} falls to the ground lifeless." };
            yield return new TextResource() { TextResourceName = TextResourceName.DeathPlayerMessage, Culture = "en-us", Content = "{0} falls to the ground lifeless." };
            yield return new TextResource() { TextResourceName = TextResourceName.DeathTargetMessage, Culture = "en-us", Content = "You fall to the ground lifeless." };

            //* Look Around
            yield return new TextResource() { TextResourceName = TextResourceName.LookAroundRoomMessage, Culture = "en-us", Content = "{0} looks around." };
            yield return new TextResource() { TextResourceName = TextResourceName.LookAroundPlayerMessage, Culture = "en-us", Content = "" };
            yield return new TextResource() { TextResourceName = TextResourceName.LookAroundTargetMessage, Culture = "en-us", Content = "{0} looks around." };

            //* See inventory
            yield return new TextResource() { TextResourceName = TextResourceName.SeeInventoryRoomMessage, Culture = "en-us", Content = "{0} searches through a small bag looking for something." };
            yield return new TextResource() { TextResourceName = TextResourceName.SeeInventoryPlayerMessage, Culture = "en-us", Content = "You search your belongings and find: {0}" };
            yield return new TextResource() { TextResourceName = TextResourceName.SeeInventoryTargetMessage, Culture = "en-us", Content = string.Empty };

            //* Equip Item
            yield return new TextResource() { TextResourceName = TextResourceName.EquipItemRoomMessage, Culture = "en-us", Content = "{0} equips {1}!" };
            yield return new TextResource() { TextResourceName = TextResourceName.EquipItemPlayerMessage, Culture = "en-us", Content = "You equip {0}!" };
            yield return new TextResource() { TextResourceName = TextResourceName.EquipItemTargetMessage, Culture = "en-us", Content = "" };

            ////* 
            //yield return new TextResource() { TextResourceName = TextResourceName., Culture = "en-us", Content = "" };
            //yield return new TextResource() { TextResourceName = TextResourceName., Culture = "en-us", Content = "" };
            //yield return new TextResource() { TextResourceName = TextResourceName., Culture = "en-us", Content = "" };
        }

        public static Dictionary<TextResourceName, string> TextResourceLookUpByCulture(string culture)
        {
            return GetResourcesByCulture(culture).ToList().ToDictionary(x => x.TextResourceName, x => x.Content);
        }

        public static IEnumerable<TextResource> GetResourcesByCulture(string culture)
        {
            return GetResources().Where(x => x.Culture.Equals(culture, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
