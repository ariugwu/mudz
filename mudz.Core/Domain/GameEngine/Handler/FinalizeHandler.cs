using mudz.Common.Domain.GameEngine;

namespace mudz.Core.Domain.GameEngine.Handler
{
    public class FinalizeHandler : BaseHandler
    {
        public override ActionContext HandleRequest(ActionContext actionContext)
        {
            if (actionContext.CurrentAction == GameActions.Login) return actionContext;

            actionContext.Player.CheckState();

            if (actionContext.Target != null) actionContext.Target.CheckState();

            return actionContext;
        }
    }
}
