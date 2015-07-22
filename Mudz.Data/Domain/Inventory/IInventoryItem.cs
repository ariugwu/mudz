namespace Mudz.Data.Domain.Inventory
{
    public interface IInventoryItem : IGameObject
    {
        InventoryTypes InventoryType { get; }
    }
}
