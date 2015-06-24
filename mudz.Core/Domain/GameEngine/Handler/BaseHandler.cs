using System;
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

        protected IGameObject GetPlayerByName(string playerName)
        {
            var room = GetRoomByPlayerName(playerName);
            var player = (room != null) ? room.GameObjects.First(x => x.Name.ToLower().Equals(playerName.ToLower())) : null;

            return player;
        }

        protected RoomContent GetRoomByPlayerName(string playerName)
        {
            return HiveMind.Instance.World.Rooms.FirstOrDefault(x => x.Value.GameObjects.Exists(y => y.Name.ToLower().Equals(playerName.ToLower()))).Value;
        }

        protected bool IsOutOfPlay(IGameObject gameObject)
        {
            return (gameObject.GameObjectState == GameObjectStates.OutOfPlay);
        }

        protected bool IsTargetPresent(RoomKey roomKey, IGameObject gameObject)
        {
            return HiveMind.Instance.World.Rooms[roomKey].GameObjects.Exists(x => x.GameObjectKey == gameObject.GameObjectKey);
        }

        protected GameResponse OutOfPlayResponse(GameRequest request, IGameObject gameObject)
        {
            return new GameResponse()
            {
                Request = request,
                WasSuccessful = false,
                Message = String.Format("Sorry, {0} is out of play!", gameObject.Name)
            };
        }

        protected GameResponse NoTargetResponse(GameRequest request, IGameObject gameObject)
        {
            return new GameResponse()
            {
                Request = request,
                WasSuccessful = false,
                Message = String.Format("Sorry, there doesn't seem to be '{0}' here.", gameObject.Name)
            };
        }

        protected GameResponse InvalidTargetResponse(GameRequest request, IGameObject gameObject)
        {
            return new GameResponse()
            {
                Request = request,
                WasSuccessful = false,
                Message = String.Format("That doesn't make any sense. '{0}' is not a valid target for this command.", gameObject.Name)
            };
        }
        #endregion
    }
}
