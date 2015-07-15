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
            yield return new TextResource() { TextResourceName = TextResourceNames.CannotRespondRoomMessage, Culture = "en-us", Content = "{0} begins to move and then collapses!" };
            yield return new TextResource() { TextResourceName = TextResourceNames.CannotRespondPlayerMessage, Culture = "en-us", Content = "You try to move and collapse. Perhaps you need rest?" };
            yield return new TextResource() { TextResourceName = TextResourceNames.CannotRespondTargetMessage, Culture = "en-us", Content = "" };

            //* NotEnoughStamina
            yield return new TextResource() { TextResourceName = TextResourceNames.NotEnoughStaminaRoomMessage, Culture = "en-us", Content = "{0} does not have enough stamina (turns) to complete this action!" };
            yield return new TextResource() { TextResourceName = TextResourceNames.NotEnoughStaminaPlayerMessage, Culture = "en-us", Content = "You do not have enough stamia (turns) to complete this action!" };
            yield return new TextResource() { TextResourceName = TextResourceNames.NotEnoughStaminaTargetMessage, Culture = "en-us", Content = "" };

            //* Fight
            yield return new TextResource() { TextResourceName = TextResourceNames.FightRoomMessage, Culture = "en-us", Content = "{0} attacks {1} for {2} damage!" };
            yield return new TextResource() { TextResourceName = TextResourceNames.FightPlayerMessage, Culture = "en-us", Content = "You attack {0} for {1} damage!" };
            yield return new TextResource() { TextResourceName = TextResourceNames.FightTargetMessage, Culture = "en-us", Content = "{0} attacks you for {1} damage!" };

            //* Heal
            yield return new TextResource() { TextResourceName = TextResourceNames.HealRoomMessage, Culture = "en-us", Content = "{0} heals {1} for {2} damage!" };
            yield return new TextResource() { TextResourceName = TextResourceNames.HealPlayerMessage, Culture = "en-us", Content = "You heal {0} for {1} damage!" };
            yield return new TextResource() { TextResourceName = TextResourceNames.HealTargetMessage, Culture = "en-us", Content = "{0} heals you for {1} damage!" };

            //* Repair
            yield return new TextResource() { TextResourceName = TextResourceNames.RepairRoomMessage, Culture = "en-us", Content = "{0} repairs {1} for {2} hit points!" };
            yield return new TextResource() { TextResourceName = TextResourceNames.RepairPlayerMessage, Culture = "en-us", Content = "You repair {0} for {1} hit points!" };
            yield return new TextResource() { TextResourceName = TextResourceNames.RepairTargetMessage, Culture = "en-us", Content = "{0} tries to wrap you in duct tape but you wiggle free!" };

            //* Negotiate
            yield return new TextResource() { TextResourceName = TextResourceNames.NegotiateRoomMessage, Culture = "en-us", Content = "{0} negotiates with {1} for {2} points!" };
            yield return new TextResource() { TextResourceName = TextResourceNames.NegotiatePlayerMessage, Culture = "en-us", Content = "You negotiate with {0} for {1} points!" };
            yield return new TextResource() { TextResourceName = TextResourceNames.NegotiateTargetMessage, Culture = "en-us", Content = "{0} negotiates with you for {1} points!" };

            //* Welcome
            yield return new TextResource() { TextResourceName = TextResourceNames.WelcomeRoomMessage, Culture = "en-us", Content = "{0} has entered the game!" };
            yield return new TextResource() { TextResourceName = TextResourceNames.WelcomePlayerMessage, Culture = "en-us", Content = "Welcome back {0}!" };
            yield return new TextResource() { TextResourceName = TextResourceNames.WelcomeTargetMessage, Culture = "en-us", Content = "" };

            //* Get (item)
            yield return new TextResource() { TextResourceName = TextResourceNames.GetItemRoomMessage, Culture = "en-us", Content = "{0} takes {1} and quickly hides it away." };
            yield return new TextResource() { TextResourceName = TextResourceNames.GetItemPlayerMessage, Culture = "en-us", Content = "You take {0} and quickly hides it away." };
            yield return new TextResource() { TextResourceName = TextResourceNames.GetItemTargetMessage, Culture = "en-us", Content = "" };

            //* Death
            yield return new TextResource() { TextResourceName = TextResourceNames.DeathRoomMessage, Culture = "en-us", Content = "{0} falls to the ground lifeless." };
            yield return new TextResource() { TextResourceName = TextResourceNames.DeathPlayerMessage, Culture = "en-us", Content = "You fall to the ground lifeless." };
            yield return new TextResource() { TextResourceName = TextResourceNames.DeathTargetMessage, Culture = "en-us", Content = "" };

            //* Look Around
            yield return new TextResource() { TextResourceName = TextResourceNames.LookAroundRoomMessage, Culture = "en-us", Content = "" };
            yield return new TextResource() { TextResourceName = TextResourceNames.LookAroundPlayerMessage, Culture = "en-us", Content = "" };
            yield return new TextResource() { TextResourceName = TextResourceNames.LookAroundTargetMessage, Culture = "en-us", Content = "" };

            ////* 
            //yield return new TextResource() { TextResourceName = TextResourceNames., Culture = "en-us", Content = "" };
            //yield return new TextResource() { TextResourceName = TextResourceNames., Culture = "en-us", Content = "" };
            //yield return new TextResource() { TextResourceName = TextResourceNames., Culture = "en-us", Content = "" };
        }

        public static Dictionary<TextResourceNames, string> TextResourceLookUpByCulture(string culture)
        {
            return GetResourcesByCulture(culture).ToList().ToDictionary(x => x.TextResourceName, x => x.Content);
        }

        public static IEnumerable<TextResource> GetResourcesByCulture(string culture)
        {
            return GetResources().Where(x => x.Culture.Equals(culture, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
