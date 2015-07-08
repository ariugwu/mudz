namespace Mudz.Common.Domain.GameEngine
{
    public interface IGameCommand
    {
        ActionResult ExecuteAction(ActionContext actionContext);
        ActionResult ProcessItem(ActionContext actionContext, Inventory.IInventoryItem item);
        void CheckState();
    }
}
