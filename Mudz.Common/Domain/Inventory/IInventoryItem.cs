namespace Mudz.Common.Domain.Inventory
{
    public interface IInventoryItem : IGameObject
    {
        InventoryTypes InventoryType { get; }
    }
}
