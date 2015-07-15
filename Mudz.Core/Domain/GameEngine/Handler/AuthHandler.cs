using System;
using Mudz.Common.Domain;
using Mudz.Common.Domain.GameEngine;

namespace Mudz.Core.Domain.GameEngine.Handler
{
    public class AuthHandler : BaseHandler
    {
        public override ActionContext HandleRequest(ActionContext actionContext)
        {
            var actionResult = new ActionResult() { GameAction = actionContext.GameRequest.GameAction};

            if (actionContext.Player == null && actionContext.GameRequest.GameAction == GameActions.Login)
            {
                actionResult.PlayerMessage = "Sorry. No Player by that name!";
                actionResult.WasSuccessful = false;

                actionContext.ActionItems.Add(actionResult);
            }
            else if (actionContext.Player != null && actionContext.GameRequest.GameAction == GameActions.Login)
            {
                actionContext.Player.GameObjectState = GameObjectStates.InPlay; // Remember we're using the flyweight pattern so even here we're still making changes to the object in the Hivemind dictionary. This is true until it's returned to the client.
                actionResult.PlayerMessage = String.Format("Welcome back {0}!", actionContext.Player.Name);
                actionResult.RoomMessage = String.Format("{0} enters the game!", actionContext.Player.Name);
                actionResult.WasSuccessful = true;

                actionContext.ActionItems.Add(actionResult);
            }

            return PassToSucessor(actionContext);
        }
    }
}
