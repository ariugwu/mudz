using Mudz.Common.Domain.GameEngine;

namespace Mudz.Core.Domain.GameEngine.Handler
{
    public class DependencyHandler : BaseHandler
    {
        public override IActionContext HandleRequest(IActionContext actionContext)
        {
            actionContext.Room = GetRoomByPlayerName(actionContext.GameRequest.PlayerName);

            actionContext.Player = actionContext.Room != null ? GetPlayerByRoom(actionContext.Room, actionContext.GameRequest.PlayerName) : null; // Either we get the room...meaning we found the player. Or we set the player to null which singles a bad login/auth.

            if (actionContext.GameRequest.HasTarget)
            {
                actionContext.Target = GetTarget(actionContext.Room, actionContext.GameRequest.TargetName);
            }

            return PassToSucessor(actionContext);
        }
    }
}
