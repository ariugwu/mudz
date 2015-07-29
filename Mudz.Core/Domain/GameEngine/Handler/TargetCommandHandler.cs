using System;
using System.Linq;
using Mudz.Common.Domain;
using Mudz.Common.Domain.GameEngine;
using Mudz.Core.Domain.GameEngine.Extensions;
using Mudz.Data.Domain.GameEngine;
using Mudz.Data.Domain.Localization;

namespace Mudz.Core.Domain.GameEngine.Handler
{
    public class TargetCommandHandler : BaseHandler
    {
        public override IActionContext HandleRequest(IActionContext actionContext)
        {

            if (!actionContext.GameRequest.HasTarget ||
                (
                !actionContext.Target.GameObjectType.Equals(GameObjectType.Monster) && 
                !actionContext.Target.GameObjectType.Equals(GameObjectType.Player) &&
                !actionContext.Target.GameObjectType.Equals(GameObjectType.Npc)
                )
                )
            {
                return actionContext;
            }

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

            IActionResult actionResult = new ActionResult { GameAction = actionContext.GameRequest.GameAction };

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
