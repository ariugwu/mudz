namespace Mudz.Common.Domain.Inventory
{
    public interface IInventoryItem : IGameObject
    {
        InventoryType InventoryType { get; }
    }
}
