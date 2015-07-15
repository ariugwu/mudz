using System;
using System.Collections.Generic;
using System.Linq;
using Mudz.Common.Domain.Localization;

namespace Mudz.Data.Domain.Localization
{
    public static class TextResourceRepository
    {
        public static IEnumerable<TextResource> GetResources()
        {
            var resources = new List<TextResource>();

            //* CannotRespondRoom
            resources.Add(new TextResource() { TextResourceName = TextResourceNames.CannotRespondRoomMessage, Culture = "en-us", Content = "{0} begins to move and then collapses!" });
            resources.Add(new TextResource() { TextResourceName = TextResourceNames.CannotRespondPlayerMessage, Culture = "en-us", Content = "You try to move and collapse. Perhaps you need rest?" });
            resources.Add(new TextResource() { TextResourceName = TextResourceNames.CannotRespondTargetMessage, Culture = "en-us", Content = "" });

            //* NotEnoughStamina
            resources.Add(new TextResource() { TextResourceName = TextResourceNames.NotEnoughStaminaRoomMessage, Culture = "en-us", Content = "{0} does not have enough stamina (turns) to complete this action!" });
            resources.Add(new TextResource() { TextResourceName = TextResourceNames.NotEnoughStaminaPlayerMessage, Culture = "en-us", Content = "You do not have enough stamia (turns) to complete this action!" });
            resources.Add(new TextResource() { TextResourceName = TextResourceNames.NotEnoughStaminaTargetMessage, Culture = "en-us", Content = "" });

            //* Fight
            resources.Add(new TextResource() { TextResourceName = TextResourceNames.FightRoomMessage, Culture = "en-us", Content = "{0} attacks {1} for {2} damage!" });
            resources.Add(new TextResource() { TextResourceName = TextResourceNames.FightPlayerMessage, Culture = "en-us", Content = "You attack {0} for {1} damage!" });
            resources.Add(new TextResource() { TextResourceName = TextResourceNames.FightTargetMessage, Culture = "en-us", Content = "" });

            //* Heal
            resources.Add(new TextResource() { TextResourceName = TextResourceNames.HealRoomMessage, Culture = "en-us", Content = "" });
            resources.Add(new TextResource() { TextResourceName = TextResourceNames.HealPlayerMessage, Culture = "en-us", Content = "" });
            resources.Add(new TextResource() { TextResourceName = TextResourceNames.HealTargetMessage, Culture = "en-us", Content = "" });

            //* Repair
            resources.Add(new TextResource() { TextResourceName = TextResourceNames.RepairRoomMessage, Culture = "en-us", Content = "" });
            resources.Add(new TextResource() { TextResourceName = TextResourceNames.RepairPlayerMessage, Culture = "en-us", Content = "" });
            resources.Add(new TextResource() { TextResourceName = TextResourceNames.RepairTargetMessage, Culture = "en-us", Content = "" });

            //* Negotiate
            resources.Add(new TextResource() { TextResourceName = TextResourceNames.NegotiateRoomMessage, Culture = "en-us", Content = "" });
            resources.Add(new TextResource() { TextResourceName = TextResourceNames.NotEnoughStaminaPlayerMessage, Culture = "en-us", Content = "" });
            resources.Add(new TextResource() { TextResourceName = TextResourceNames.NegotiateTargetMessage, Culture = "en-us", Content = "" });

            //* Welcome
            resources.Add(new TextResource() { TextResourceName = TextResourceNames.WelcomeRoomMessage, Culture = "en-us", Content = "{0} has entered the game!" });
            resources.Add(new TextResource() { TextResourceName = TextResourceNames.WelcomePlayerMessage, Culture = "en-us", Content = "Welcome back {0}!" });
            resources.Add(new TextResource() { TextResourceName = TextResourceNames.WelcomeTargetMessage, Culture = "en-us", Content = "" });

            ////* 
            //resources.Add(new TextResource() { TextResourceName = TextResourceNames., Culture = "en-us", Content = "" });
            //resources.Add(new TextResource() { TextResourceName = TextResourceNames., Culture = "en-us", Content = "" });
            //resources.Add(new TextResource() { TextResourceName = TextResourceNames., Culture = "en-us", Content = "" });

            return resources;
        }

        public static Dictionary<TextResourceNames, string> TextResourceLookUpByCulture(string culture)
        {
            return GetResourcesByCulture(culture).ToDictionary(x => x.TextResourceName, x => x.Content);
        }

        public static IEnumerable<TextResource> GetResourcesByCulture(string culture)
        {
            return GetResources().Where(x => x.Culture.Equals(culture, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
