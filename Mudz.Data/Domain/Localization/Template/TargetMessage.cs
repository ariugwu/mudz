using Mudz.Data.Domain.GameEngine;

namespace Mudz.Data.Domain.Localization.Template
{
    public class TargetMessage : GameMessage
    {
        public override string ParseResourceKey(ActionContext actionContext)
        {
            return string.Format("{0}TargetMessage", actionContext.GameRequest.GameAction.ToString());
        }

        public override string FormatMessage(ActionContext actionContext, int amount, string formatString)
        {
            return string.Format(formatString, actionContext.Player.Name, amount);
        }
    }
}
