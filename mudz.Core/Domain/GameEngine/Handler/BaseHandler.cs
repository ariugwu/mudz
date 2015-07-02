﻿using mudz.Common;
using mudz.Common.Domain;
using mudz.Common.Domain.Environment.Map.Room;
using mudz.Common.Domain.GameEngine;
using mudz.Common.Domain.Player;
using mudz.Core.Model.Domain.GameEngine;
using System;
using System.Linq;

namespace mudz.Core.Domain.GameEngine.Handler
{
    public abstract class BaseHandler
    {
        protected BaseHandler Successor;

        public void SetSuccessor(BaseHandler successor)
        {
            Successor = successor;
        }

        public abstract ActionContext HandleRequest(ActionContext actionContext);

        public ActionContext Process(ActionContext actionContext)
        {
            // Do whatever internal logic is required.
            actionContext = HandleRequest(actionContext);

            // If there is a Successor set then fire that. Otherwise return the game response.
            return Successor != null ? Successor.HandleRequest(actionContext) : actionContext;
        }

		#region Helper Function(s)

		protected IPlayer GetPlayerByName(IPlayer player)
		{
			var room = GetRoomByPlayerName(player);
			return (room != null) ? room.GameObjects.OfType<IPlayer>().FirstMatching(player, PlayerEqualityComparer.Instance) : null;
		}

        protected RoomContent GetRoomByPlayerName(IPlayer player)
        {
			return HiveMind.Instance.World.Rooms.Containing(player);
        }

        protected bool IsOutOfPlay(IGameObject gameObject)
        {
            return (gameObject.GameObjectState == GameObjectStates.OutOfPlay);
        }

        protected bool IsTargetPresent(RoomKey roomKey, IGameObject gameObject)
        {
            return HiveMind.Instance.World.Rooms[roomKey].GameObjects.Exists(x => x.GameObjectKey == gameObject.GameObjectKey);
        }

        protected ActionResult OutOfPlayResult(IGameObject gameObject)
        {
            return new ActionResult()
            {
                WasSuccessful = false,
                Message = String.Format("Sorry, {0} is out of play!", gameObject.Name)
            };
        }

        protected ActionResult NoTargetResponse(IGameObject gameObject)
        {
            return new ActionResult()
            {
                WasSuccessful = false,
                Message = String.Format("Sorry, there doesn't seem to be '{0}' here.", gameObject.Name)
            };
        }

        protected ActionResult InvalidTargetResponse(IGameObject gameObject)
        {
            return new ActionResult()
            {
                WasSuccessful = false,
                Message = String.Format("That doesn't make any sense. '{0}' is not a valid target for this command.", gameObject.Name)
            };
        }

        #endregion
    }
}
