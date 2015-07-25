using System;
using System.Linq;
using Mudz.Common.Domain.GameEngine;

namespace Mudz.Data.Domain.Localization.Template
{
    public abstract class GameMessage
    {
        public abstract string ParseResourceKey(IActionContext actionContext);

        /// <summary>
        /// The Format message assumes that the format string is in a particular parameter order.
        /// </summary>
        /// <param name="actionContext">The</param>
        /// <param name="amount"></param>
        /// <param name="formatString"></param>
        /// <returns>The appropriate formatted text resource</returns>
        public abstract string FormatMessage(IActionContext actionContext, int amount, string formatString);

        public string GetResource(IActionContext actionContext, int amount)
        {
            // Parse the key: FightRoomMessage
            var textResourceNameAsString = ParseResourceKey(actionContext);

            // Get the format string: "{0} sends a room message";
            var formatString = TextResourceRepository.GetResources()
                    .First(
                        x =>
                            x.TextResourceName.ToString()
                                .Equals(textResourceNameAsString, StringComparison.InvariantCultureIgnoreCase))
                    .Content;


            // Combine and return
            return FormatMessage(actionContext, amount, formatString);

        }
    }
}
