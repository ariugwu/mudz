using Mudz.Common.Domain.GameEngine;

namespace Mudz.Core.Domain.GameEngine.Handler
{
    public class DependencyHandler : BaseHandler
    {
        public override ActionContext HandleRequest(ActionContext actionContext)
        {
            actionContext.Room = GetRoomByPlayerName(actionContext.Player);

            actionContext.Player = actionContext.Room != null ? GetPlayerByName(actionContext.Room, actionContext.Player) : null; // Either we get the room...meaning we found the player. Or we set the player to null which singles a bad login/auth.

            if (actionContext.GameRequest.HasTarget)
            {
                actionContext.Target = GetTarget(actionContext.Room, actionContext.GameRequest.TargetName);
            }

            return PassToSucessor(actionContext);
        }
    }
}
