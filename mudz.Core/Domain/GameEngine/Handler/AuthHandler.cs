using mudz.Common.Domain.GameEngine;

namespace mudz.Core.Domain.GameEngine.Handler
{
    public class AuthHandler : BaseHandler
    {
        public override ActionContext HandleRequest(ActionContext actionContext)
        {
            var player = GetPlayerByName(actionContext.Player);
            var actionResult = new ActionResult();

            if (player == null)
            {
                actionResult.Message = "Sorry. No Player by that name!";
                actionResult.WasSuccessful = false;
            }
            else
            {
                actionContext.Player = player;
                actionResult.Message = "Welcome back!";
                actionResult.WasSuccessful = true;
            }

            actionContext.ActionItems.Add(actionResult);
            return actionContext;
        }
    }
}
