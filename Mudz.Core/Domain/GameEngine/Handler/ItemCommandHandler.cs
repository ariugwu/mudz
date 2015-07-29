using Mudz.Common.Domain;
using Mudz.Common.Domain.GameEngine;
using Mudz.Common.Domain.Inventory;
using Mudz.Data.Domain.GameEngine;

namespace Mudz.Core.Domain.GameEngine.Handler
{
    public class ItemCommandHandler : BaseHandler
    {
        public override IActionContext HandleRequest(IActionContext actionContext)
        {
            if (!actionContext.GameRequest.HasTarget ||
                !actionContext.Target.GameObjectType.Equals(GameObjectType.InventoryItem))
            {
                return actionContext;
            }


            IActionResult actionResult = new ActionResult() { GameAction = actionContext.GameRequest.GameAction };
            IInventoryItem item;

            switch (actionContext.GameRequest.GameAction)
            {
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
                case GameAction.EquipItem:
                    item = (IInventoryItem)(actionContext.Room.GetGameObject(actionContext.Target.GameObjectKey));
                    actionResult = actionContext.Player.ProcessItem(actionContext, item);
                    actionContext.ActionItems.Add(actionResult);
                    break;
            }

            return PassToSucessor(actionContext);
        }
    }
}
