using Mudz.Common;
using Mudz.Common.Domain;
using Mudz.Common.Domain.Environment.Map.Room;
using Mudz.Common.Domain.GameEngine;
using Mudz.Common.Domain.Player;
using System;
using System.Linq;

namespace Mudz.Core.Domain.GameEngine.Handler
{
    public abstract class BaseHandler
    {
        protected BaseHandler Successor;

        public void SetSuccessor(BaseHandler successor)
        {
            this.Successor = successor;
        }

        public abstract ActionContext HandleRequest(ActionContext actionContext);

        public ActionContext Process(ActionContext actionContext)
        {
            // Do whatever internal logic is required. Each Call should also fire "PassToSuccessor" as it's final call.
            return HandleRequest(actionContext);
        }

        public ActionContext PassToSucessor(ActionContext actionContext)
        {
            // If there is a Successor set then fire that. Otherwise return the game response.
            return this.Successor != null ? this.Successor.HandleRequest(actionContext) : actionContext;
        }

		#region Helper Function(s)

		protected IPlayer GetPlayerByName(RoomContent room, IPlayer player)
		{
			return (room != null) ? room.GameObjects.OfType<IPlayer>().FirstMatching(player, PlayerEqualityComparer.Instance) : null;
		}

        protected RoomContent GetRoomByPlayerName(IPlayer player)
        {
			return HiveMind.Instance.World.Rooms.Containing(player);
        }

        protected RoomContent GetRoomByPlayerName(string playerName)
        {
            return HiveMind.Instance.World.Rooms.Containing(playerName);
        }

        protected IPlayer GetPlayerByRoom(RoomContent room, string playerName)
        {
            return room.GameObjects.OfType<IPlayer>().First(x => x.Name.Equals(playerName, StringComparison.InvariantCultureIgnoreCase));
        }

        protected bool IsOutOfPlay(IGameObject gameObject)
        {
            return (gameObject.GameObjectState == GameObjectStates.OutOfPlay);
        }

        protected bool IsTargetPresent(RoomKey roomKey, IGameObject gameObject)
        {
            return HiveMind.Instance.World.Rooms[roomKey].GameObjects.Exists(x => x.GameObjectKey == gameObject.GameObjectKey);
        }

        protected IGameObject GetTarget(RoomContent room, string targetName)
        {
            return room.GameObjects.First(x => x.Name.Trim().Equals(targetName, StringComparison.InvariantCultureIgnoreCase));
        }

        protected ActionResult OutOfPlayResult(IGameObject gameObject)
        {
            return new ActionResult()
            {
                WasSuccessful = false,
                PlayerMessage = String.Format("Sorry, {0} is out of play!", gameObject.Name)
            };
        }

        protected ActionResult NoTargetResponse(IGameObject gameObject)
        {
            return new ActionResult()
            {
                WasSuccessful = false,
                PlayerMessage = String.Format("Sorry, there doesn't seem to be '{0}' here.", gameObject.Name)
            };
        }

        protected ActionResult InvalidTargetResponse(IGameObject gameObject)
        {
            return new ActionResult()
            {
                WasSuccessful = false,
                PlayerMessage = String.Format("That doesn't make any sense. '{0}' is not a valid target for this command.", gameObject.Name)
            };
        }

        #endregion
    }
}
