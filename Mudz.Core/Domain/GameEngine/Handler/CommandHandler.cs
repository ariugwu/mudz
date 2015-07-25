using System;
using Mudz.Common.Domain;
using Mudz.Common.Domain.GameEngine;
using Mudz.Common.Domain.Inventory;
using Mudz.Data.Domain.GameEngine;
using Mudz.Data.Domain.Localization;

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
                            var deathResult = new ActionResult()
                            {
                                GameAction = GameAction.Die,
                                RoomMessage =
                                    string.Format(TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceNames.DeathRoomMessage], actionContext.Target.Name),
                                PlayerMessage = string.Format(TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceNames.DeathPlayerMessage], actionContext.Target.Name),
                                WasSuccessful = true
                            };
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
                    actionResult.WasSuccessful = true;
                    actionContext.ActionItems.Add(actionResult);
                    break;
                case GameAction.LookAround:
                    actionResult.RoomMessage = string.Format("{0} looks around.", actionContext.Player.Name);
                    actionResult.WasSuccessful = true;
                    actionContext.ActionItems.Add(actionResult);
                    break;
                case GameAction.Get:
                    if (actionContext.Target.GameObjectType != GameObjectType.InventoryItem)
                    {
                        actionResult = InvalidTargetResponse(actionContext.Target);
                        actionContext.ActionItems.Add(actionResult);
                        break;
                    }

                    var item = (IInventoryItem)(actionContext.Room.GetGameObject(actionContext.Target.GameObjectKey));
                    actionResult = actionContext.Player.ProcessItem(actionContext, item);

                    if (actionResult.WasSuccessful) actionContext.Room.GameObjects.Remove(item);
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
