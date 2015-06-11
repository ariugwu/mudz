namespace mudz.Common.Domain.Inventory
{
    public interface IInventoryItem : IGameObject
    {
        InventoryTypes InventoryType { get; }
    }
}
