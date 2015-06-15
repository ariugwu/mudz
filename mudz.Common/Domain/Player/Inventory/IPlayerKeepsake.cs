using mudz.Common.Domain.Inventory;

namespace mudz.Common.Domain.Player.Inventory
{
    public interface IPlayerKeepsake
    {
        InventoryTypes InventoryType { get; }
    }
}
