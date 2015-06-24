using mudz.Common.Domain.GameEngine;
using mudz.Common.Domain.Player;

namespace mudz.Core.Domain.GameEngine.Handler
{
    public class FinalizeHandler : BaseHandler
    {
        public override GameResponse HandleRequest(GameResponse gameResponse)
        {
            if (gameResponse.Request.GameAction == GameActions.Login) return gameResponse;

            gameResponse.Request.Sender.CheckState();

            if (gameResponse.Request.Target != null) gameResponse.Request.Target.CheckState();

            return gameResponse;
        }
    }
}
