using mudz.Common.Domain.GameEngine;
using mudz.Common.Domain.Player;

namespace mudz.Core.Domain.GameEngine.Handler
{
    public class AuthHandler : BaseHandler
    {
        public override GameResponse HandleRequest(GameResponse gameResponse)
        {
            var player = GetPlayerByName(gameResponse.Request.Sender.Name);

            if (player == null)
            {
                gameResponse.Message = "Sorry. No Player by that name!";
                gameResponse.WasSuccessful = false;
            }
            else
            {
                gameResponse.Player = (IPlayer) player;
                gameResponse.WasSuccessful = true;
            }

            return gameResponse;
        }
    }
}
