using System;
using mudz.Common.Domain;
using mudz.Common.Domain.GameEngine;
using mudz.Common.Domain.Inventory;

namespace mudz.Core.Domain.GameEngine.Handler
{
	public class CommandHandler : BaseHandler
	{
		public override ActionContext HandleRequest(ActionContext actionContext)
		{

		    if (actionContext.CurrentAction == GameActions.Login)
		    {
                return actionContext;
		    }

		    if (IsOutOfPlay(actionContext.Player))
		    {
		        actionContext.ActionItems.Add(OutOfPlayResult(actionContext.Player));
		        return actionContext;
		    }

		    if (IsOutOfPlay(actionContext.Target))
		    {
		        actionContext.ActionItems.Add(OutOfPlayResult(actionContext.Target));
                return actionContext;
		    }

		    if (!IsTargetPresent(actionContext.Room.RoomKey, actionContext.Target))
		    {
		        actionContext.ActionItems.Add(NoTargetResponse(actionContext.Target));
                return actionContext;
		    }

		    var actionResult = new ActionResult();

			switch (actionContext.CurrentAction)
			{
				case GameActions.Heal:
			        actionResult = actionContext.Player.ExecuteAction(actionContext);
					if (actionResult.WasSuccessful) actionContext.Target.RestoreHealth(actionResult.Amount);
                    actionContext.ActionItems.Add(actionResult);
					break;
				case GameActions.Fight:
                    actionResult = actionContext.Player.ExecuteAction(actionContext);
					if (actionResult.WasSuccessful) actionContext.Target.TakeDamage(actionResult.Amount);
                    actionContext.ActionItems.Add(actionResult);
					break;
				case GameActions.Repair:
                    actionResult = actionContext.Player.ExecuteAction(actionContext);
					if (actionResult.WasSuccessful) actionContext.Target.Repair();
                    actionContext.ActionItems.Add(actionResult);
					break;
				case GameActions.Negotiate:
                    actionResult = actionContext.Player.ExecuteAction(actionContext);
					if (actionResult.WasSuccessful) actionContext.Target.Negotiate();
                    actionContext.ActionItems.Add(actionResult);
					break;
				case GameActions.LookAt:
			        actionResult.Message = actionContext.Target.Description;
			        actionResult.WasSuccessful = true;
					break;
				case GameActions.LookAround:
			        actionResult.Message = String.Format("{0} looks around.", actionContext.Player.Name);
                    actionResult.WasSuccessful = true;
					break;
				case GameActions.Get:
					if (actionContext.Target.GameObjectType != GameObjectTypes.InventoryItem)
					{
						actionResult = InvalidTargetResponse(actionContext.Target);
                        actionContext.ActionItems.Add(actionResult);
						break;
					}

					var item = (IInventoryItem)(actionContext.Room.GetGameObject(actionContext.Target.GameObjectKey));
                    actionContext.ActionItems.Add(actionContext.Player.ProcessItem(actionContext, item));

					if (actionResult.WasSuccessful) actionContext.Room.GameObjects.Remove(item);
                    actionContext.ActionItems.Add(actionResult);
					break;
				case GameActions.None:
			        actionResult.Message = "Sorry, no command matched your request.";
			        actionResult.WasSuccessful = false;
                    actionContext.ActionItems.Add(actionResult);
					break;
				default:
					throw new NotImplementedException("The action requested is not available!");
			}

			return actionContext;
		}
	}
}
