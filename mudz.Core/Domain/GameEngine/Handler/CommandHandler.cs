using System;
using mudz.Common.Domain;
using mudz.Common.Domain.GameEngine;
using mudz.Common.Domain.Inventory;

namespace mudz.Core.Domain.GameEngine.Handler
{
	public class CommandHandler : BaseHandler
	{
		public override GameResponse HandleRequest(GameResponse gameResponse)
		{
			if (gameResponse.Request.GameAction == GameActions.Login)
				if (!gameResponse.WasSuccessful) return gameResponse;
				else
				{
					gameResponse.RoomContent = GetRoomByPlayerName(gameResponse.Player);
					return gameResponse;
				}

			var room = GetRoomByPlayerName(gameResponse.Player);

			if (gameResponse.Request.GameAction != GameActions.Login)
			{
				if (IsOutOfPlay(gameResponse.Request.Sender)) return OutOfPlayResponse(gameResponse.Request, gameResponse.Request.Sender);
				if (IsOutOfPlay(gameResponse.Request.Target)) return OutOfPlayResponse(gameResponse.Request, gameResponse.Request.Target);

				if (!IsTargetPresent(gameResponse.Request.RoomKey, gameResponse.Request.Target)) return NoTargetResponse(gameResponse.Request, gameResponse.Request.Target);
			}

			switch (gameResponse.Request.GameAction)
			{
				case GameActions.Heal:
					gameResponse = gameResponse.Request.Sender.ExecuteAction(gameResponse.Request);
					if (gameResponse.WasSuccessful) gameResponse.Request.Target.RestoreHealth(gameResponse.Amount);
					break;
				case GameActions.Fight:
					gameResponse = gameResponse.Request.Sender.ExecuteAction(gameResponse.Request);
					if (gameResponse.WasSuccessful) gameResponse.Request.Target.TakeDamage(gameResponse.Amount);
					break;
				case GameActions.Repair:
					gameResponse = gameResponse.Request.Sender.ExecuteAction(gameResponse.Request);
					if (gameResponse.WasSuccessful) gameResponse.Request.Target.Repair();
					break;
				case GameActions.Negotiate:
					gameResponse = gameResponse.Request.Sender.ExecuteAction(gameResponse.Request);
					if (gameResponse.WasSuccessful) gameResponse.Request.Target.Negotiate();
					break;
				case GameActions.LookAt:
					gameResponse = new GameResponse() { Message = gameResponse.Request.Target.Description, WasSuccessful = true, Request = gameResponse.Request };
					break;
				case GameActions.LookAround:
					gameResponse = new GameResponse() { Message = String.Format("{0} looks around.", gameResponse.Player.Name), WasSuccessful = false, Request = gameResponse.Request };
					break;
				case GameActions.Get:
					if (gameResponse.Request.Target.GameObjectType != GameObjectTypes.InventoryItem)
					{
						gameResponse = InvalidTargetResponse(gameResponse.Request, gameResponse.Request.Target);
						break;
					}

					var item = (IInventoryItem)(room.GetGameObject(gameResponse.Request.Target.GameObjectKey));
					gameResponse = gameResponse.Request.Sender.ProcessItem(item);

					if (gameResponse.WasSuccessful) room.GameObjects.Remove(item);

					break;
				case GameActions.None:
					gameResponse = new GameResponse()
					{
						Message = "Sorry, no command matched your request.",
						WasSuccessful = false,
						Request = new GameRequest() { GameAction = GameActions.None, Sender = gameResponse.Request.Sender, Target = null }
					};

					break;
				default:
					throw new NotImplementedException("The action requested is not available!");
			}

			return gameResponse;
		}
	}
}
