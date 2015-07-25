using Mudz.Common;
using System;
using System.Linq;
using Mudz.Common.Domain;
using Mudz.Common.Domain.Environment;
using Mudz.Common.Domain.GameEngine;
using Mudz.Common.Domain.Player;
using Mudz.Data.Domain.Environment.Model;
using Mudz.Data.Domain.GameEngine;

namespace Mudz.Core.Domain.GameEngine.Handler
{
    public abstract class BaseHandler
    {
        protected BaseHandler Successor;

        public void SetSuccessor(BaseHandler successor)
        {
            this.Successor = successor;
        }

        public abstract IActionContext HandleRequest(IActionContext actionContext);

        public IActionContext Process(IActionContext actionContext)
        {
            // Do whatever internal logic is required. Each Call should also fire "PassToSuccessor" as it's final call.
            return HandleRequest(actionContext);
        }

        public IActionContext PassToSucessor(IActionContext actionContext)
        {
            // If there is a Successor set then fire that. Otherwise return the game response.
            return this.Successor != null ? this.Successor.HandleRequest(actionContext) : actionContext;
        }

		#region Helper Function(s)

		protected IPlayer GetPlayerByName(RoomContent room, IPlayer player)
		{
			return (room != null) ? room.GameObjects.OfType<IPlayer>().FirstMatching(player, PlayerEqualityComparer.Instance) : null;
		}

        protected IRoomContent GetRoomByPlayerName(IPlayer player)
        {
			return HiveMind.Instance.World.Rooms.Containing(player);
        }

        protected IRoomContent GetRoomByPlayerName(string playerName)
        {
            return HiveMind.Instance.World.Rooms.Containing(playerName);
        }

        protected IPlayer GetPlayerByRoom(IRoomContent room, string playerName)
        {
            return room.GameObjects.OfType<IPlayer>().First(x => x.Name.Equals(playerName, StringComparison.InvariantCultureIgnoreCase));
        }

        protected bool IsOutOfPlay(IGameObject gameObject)
        {
            return (gameObject.GameObjectState == GameObjectState.OutOfPlay);
        }

        protected bool IsTargetPresent(IRoomKey roomKey, IGameObject gameObject)
        {
            return HiveMind.Instance.World.Rooms[roomKey].GameObjects.Exists(x => x.GameObjectKey == gameObject.GameObjectKey);
        }

        protected IGameObject GetTarget(IRoomContent room, string targetName)
        {
            return room.GameObjects.First(x => x.Name.Trim().Equals(targetName, StringComparison.InvariantCultureIgnoreCase));
        }

        protected IActionResult OutOfPlayResult(IGameObject gameObject)
        {
            return new ActionResult()
            {
                WasSuccessful = false,
                PlayerMessage = string.Format("Sorry, {0} is out of play!", gameObject.Name)
            };
        }

        protected IActionResult NoTargetResponse(IGameObject gameObject)
        {
            return new ActionResult()
            {
                WasSuccessful = false,
                PlayerMessage = string.Format("Sorry, there doesn't seem to be '{0}' here.", gameObject.Name)
            };
        }

        protected IActionResult InvalidTargetResponse(IGameObject gameObject)
        {
            return new ActionResult()
            {
                WasSuccessful = false,
                PlayerMessage = string.Format("That doesn't make any sense. '{0}' is not a valid target for this command.", gameObject.Name)
            };
        }

        #endregion
    }
}
