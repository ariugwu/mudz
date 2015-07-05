using mudz.Common.Domain.GameEngine;

namespace mudz.Core.Domain.GameEngine.Handler
{
    public class AuthHandler : BaseHandler
    {
        public override ActionContext HandleRequest(ActionContext actionContext)
        {
            
            var actionResult = new ActionResult(){ GameAction = actionContext.CurrentAction};

            if (actionContext.Player == null && actionContext.CurrentAction == GameActions.Login)
            {
                actionResult.Message = "Sorry. No Player by that name!";
                actionResult.WasSuccessful = false;

                actionContext.ActionItems.Add(actionResult);
            }
            else if (actionContext.Player != null && actionContext.CurrentAction == GameActions.Login)
            {
                actionResult.Message = "Welcome back!";
                actionResult.WasSuccessful = true;

                actionContext.ActionItems.Add(actionResult);
            }

            return PassToSucessor(actionContext);
        }
    }
}
