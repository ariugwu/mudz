using System.Linq;
using mudz.Common.Domain;
using mudz.Common.Domain.Environment.Map.Room;
using mudz.Common.Domain.GameEngine;
using mudz.Core.Model.Domain.GameEngine;

namespace mudz.Core.Domain.GameEngine.Handler
{
    public abstract class BaseHandler
    {
        protected BaseHandler Successor;

        public void SetSuccessor(BaseHandler successor)
        {
            this.Successor = successor;
        }

        public abstract GameResponse HandleRequest(GameResponse gameResponse);

        public GameResponse Process(GameResponse gameResponse)
        {
            // Do whatever internal logic is required.
            gameResponse = this.HandleRequest(gameResponse);

            // If there is a Successor set then fire that. Otherwise return the game response.
            return Successor != null ? Successor.HandleRequest(gameResponse) : gameResponse;
        }

        #region Helper Function(s)

        public IGameObject GetPlayerByName(string playerName)
        {
            var room = GetRoomByPlayerName(playerName);
            var player = (room != null) ? room.GameObjects.First(x => x.Name.ToLower().Equals(playerName.ToLower())) : null;

            return player;
        }

        public RoomContent GetRoomByPlayerName(string playerName)
        {
            return HiveMind.Instance.World.Rooms.FirstOrDefault(x => x.Value.GameObjects.Exists(y => y.Name.ToLower().Equals(playerName.ToLower()))).Value;
        }

        #endregion
    }
}
