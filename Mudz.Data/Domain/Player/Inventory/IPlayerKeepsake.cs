using Mudz.Data.Domain.Inventory;

namespace Mudz.Data.Domain.Player.Inventory
{
    public interface IPlayerKeepsake
    {
        InventoryTypes InventoryType { get; }
    }
}
