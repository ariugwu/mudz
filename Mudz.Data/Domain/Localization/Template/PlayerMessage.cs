using Mudz.Common.Domain.GameEngine;

namespace Mudz.Data.Domain.Localization.Template
{
    public class PlayerMessage : GameMessage
    {
        public override string ParseResourceKey(GameAction gameAction)
        {
            return string.Format("{0}PlayerMessage", gameAction.ToString());
        }

        public override string FormatMessage(IActionContext actionContext, int amount, string formatString)
        {
            return string.Format(formatString, (actionContext.Target != null)? actionContext.Target.Name : string.Empty, amount);
        }
    }
}
