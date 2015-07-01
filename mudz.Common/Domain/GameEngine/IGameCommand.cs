namespace mudz.Common.Domain.GameEngine
{
    public interface IGameCommand
    {
        ActionItem ExecuteAction(ActionContext actionContext);
        ActionItem ProcessItem(ActionContext actionContext, Inventory.IInventoryItem item);
        void CheckState();
    }
}
