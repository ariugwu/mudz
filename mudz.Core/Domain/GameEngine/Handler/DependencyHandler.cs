using mudz.Common.Domain.GameEngine;

namespace mudz.Core.Domain.GameEngine.Handler
{
    public class DependencyHandler : BaseHandler
    {
        public override ActionContext HandleRequest(ActionContext actionContext)
        {
            actionContext.Room = GetRoomByPlayerName(actionContext.Player);

            return actionContext;
        }
    }
}
