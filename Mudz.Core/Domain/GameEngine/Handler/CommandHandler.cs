using System;
using Mudz.Common.Domain;
using Mudz.Common.Domain.GameEngine;
using Mudz.Common.Domain.Inventory;
using Mudz.Core.Domain.GameEngine.Extensions;
using Mudz.Data.Domain.GameEngine;

namespace Mudz.Core.Domain.GameEngine.Handler
{
    public class CommandHandler : BaseHandler
    {
        public override IActionContext HandleRequest(IActionContext actionContext)
        {
            if (actionContext.GameRequest.GameAction == GameAction.Login)
            {
                return actionContext;
            }

            if (IsOutOfPlay(actionContext.Player))
            {
                actionContext.ActionItems.Add(OutOfPlayResult(actionContext.Player));
                return actionContext;
            }

            if (actionContext.Target != null && IsOutOfPlay(actionContext.Target))
            {
                actionContext.ActionItems.Add(OutOfPlayResult(actionContext.Target));
                return actionContext;
            }

            if (actionContext.Target != null && !IsTargetPresent(actionContext.Room.RoomKey, actionContext.Target))
            {
                actionContext.ActionItems.Add(NoTargetResponse(actionContext.Target));
                return actionContext;
            }

            IActionResult actionResult = new ActionResult() { GameAction = actionContext.GameRequest.GameAction };
            IInventoryItem item;

            switch (actionContext.GameRequest.GameAction)
            {
                case GameAction.Fight:
                    actionResult = actionContext.Player.ExecuteAction(actionContext);
                    
                    if (actionResult.WasSuccessful)
                    {
                        actionResult = actionContext.Target.RecieveGameActionResult(actionContext.GameRequest.GameAction, actionResult, actionContext.Player.Name);

                        actionContext.ActionItems.Add(actionResult);

                        if (actionContext.Target.HitPoints <= 0)
                        {
                            actionContext.GameRequest.GameAction = GameAction.Death;

                            var deathResult = new ActionResult();
                            deathResult.Fill(actionContext, 0);
                            actionContext.ActionItems.Add(deathResult);
                        }
                    }
                    else
                    {
                        actionContext.ActionItems.Add(actionResult);
                    }
                    break;
                case GameAction.Heal:
                case GameAction.Repair:
                case GameAction.Negotiate:
                    actionResult = actionContext.Player.ExecuteAction(actionContext);
                    if (actionResult.WasSuccessful)
                    {
                        actionResult = actionContext.Target.RecieveGameActionResult(actionContext.GameRequest.GameAction, actionResult, actionContext.Player.Name);
                    }

                    actionContext.ActionItems.Add(actionResult);
                    break;
                case GameAction.LookAt:
                    actionResult.PlayerMessage = actionContext.Target.Description;
                    actionContext.ActionItems.Add(actionResult);
                    break;
                case GameAction.LookAround:
                    actionResult.Fill(actionContext, 0);
                    actionContext.ActionItems.Add(actionResult);
                    break;
                case GameAction.Get:
                    if (actionContext.Target.GameObjectType != GameObjectType.InventoryItem)
                    {
                        actionResult = InvalidTargetResponse(actionContext.Target);
                        actionContext.ActionItems.Add(actionResult);
                        break;
                    }

                    item = (IInventoryItem)(actionContext.Room.GetGameObject(actionContext.Target.GameObjectKey));
                    actionResult = actionContext.Player.ProcessItem(actionContext, item);

                    if (actionResult.WasSuccessful) actionContext.Room.GameObjects.Remove(item);
                    actionResult.GameAction = actionContext.GameRequest.GameAction;
                    actionContext.ActionItems.Add(actionResult);
                    break;
                case GameAction.SeeInventory:
                    actionResult.Fill(actionContext, 0);
                    break;
                case GameAction.EquipItem:
                    item = (IInventoryItem)(actionContext.Room.GetGameObject(actionContext.Target.GameObjectKey));
                    actionResult = actionContext.Player.ProcessItem(actionContext, item);
                    actionContext.ActionItems.Add(actionResult);
                    break;
                case GameAction.None:
                    actionResult.PlayerMessage = "Sorry, no command matched your request.";
                    actionResult.WasSuccessful = false;
                    actionContext.ActionItems.Add(actionResult);
                    break;
                default:
                    throw new NotImplementedException("The action requested is not available!");
            }

            return PassToSucessor(actionContext);
        }
    }
}
