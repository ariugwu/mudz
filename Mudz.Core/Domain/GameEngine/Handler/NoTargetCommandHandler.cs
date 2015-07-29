using System.Linq;
using Mudz.Common.Domain.GameEngine;
using Mudz.Core.Domain.GameEngine.Extensions;
using Mudz.Data.Domain.GameEngine;
using Mudz.Data.Domain.Localization;

namespace Mudz.Core.Domain.GameEngine.Handler
{
    public class NoTargetCommandHandler : BaseHandler
    {
        public override IActionContext HandleRequest(IActionContext actionContext)
        {
            if (actionContext.GameRequest.HasTarget)
            {
                return actionContext;
            }

            IActionResult actionResult = new ActionResult() { GameAction = actionContext.GameRequest.GameAction };

            switch (actionContext.GameRequest.GameAction)
            {
                case GameAction.LookAt:
                    actionResult.PlayerMessage = actionContext.Target.Description;
                    actionContext.ActionItems.Add(actionResult);
                    break;
                case GameAction.LookAround:
                    actionResult.Fill(actionContext, 0);
                    actionContext.ActionItems.Add(actionResult);
                    break;

                case GameAction.SeeInventory:
                    var inventoryNames = actionContext.Player.Inventory.Select(x => x.Name).ToList();
                    actionResult.GameAction = actionContext.GameRequest.GameAction;
                    actionResult.WasSuccessful = true;
                    actionResult.RoomMessage = string.Format(TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceName.SeeInventoryRoomMessage], string.Empty);
                    actionResult.PlayerMessage = string.Format(TextResourceRepository.TextResourceLookUpByCulture("en-us")[TextResourceName.SeeInventoryPlayerMessage], (inventoryNames.Any()) ? string.Join(",", inventoryNames) : "Nothing!");
                    actionContext.ActionItems.Add(actionResult);
                    break;
            }

            return PassToSucessor(actionContext);
        }
    }
}
