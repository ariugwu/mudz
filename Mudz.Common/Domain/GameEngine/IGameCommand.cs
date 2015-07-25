namespace Mudz.Common.Domain.GameEngine
{
    public interface IGameCommand
    {
        IActionResult ExecuteAction(IActionContext actionContext);
        IActionResult ProcessItem(IActionContext actionContext, Inventory.IInventoryItem item);
        void CheckState();
    }
}
