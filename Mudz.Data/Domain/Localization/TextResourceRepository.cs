﻿using System;
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
            resources.Add(new TextResource() { TextResourceName = TextResourceNames.FightRoomMessage, Culture = "en-us", Content = "" });
            resources.Add(new TextResource() { TextResourceName = TextResourceNames.FightPlayerMessage, Culture = "en-us", Content = "" });
            resources.Add(new TextResource() { TextResourceName = TextResourceNames.FightTargetMessage, Culture = "en-us", Content = "" });

            ////* 
            //resources.Add(new TextResource() { TextResourceName = TextResourceNames., Culture = "en-us", Content = "" });
            //resources.Add(new TextResource() { TextResourceName = TextResourceNames., Culture = "en-us", Content = "" });
            //resources.Add(new TextResource() { TextResourceName = TextResourceNames., Culture = "en-us", Content = "" });

            return resources;
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
