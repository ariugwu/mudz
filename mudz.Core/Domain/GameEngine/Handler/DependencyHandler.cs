using mudz.Common.Domain.GameEngine;

namespace mudz.Core.Domain.GameEngine.Handler
{
    public class DependencyHandler : BaseHandler
    {
        public override ActionContext HandleRequest(ActionContext actionContext)
        {
            actionContext.Room = GetRoomByPlayerName(actionContext.Player);

            if (actionContext.Room != null)
            {
                actionContext.Player = GetPlayerByName(actionContext.Room, actionContext.Player);
            }

            return PassToSucessor(actionContext);
        }
    }
}
