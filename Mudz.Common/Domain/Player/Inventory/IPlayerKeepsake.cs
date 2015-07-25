using Mudz.Common.Domain.Inventory;

namespace Mudz.Common.Domain.Player.Inventory
{
    public interface IPlayerKeepsake
    {
        InventoryType InventoryType { get; }
    }
}
