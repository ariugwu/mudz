using mudz.Core.Model.Domain.Inventory;

namespace mudz.Core.Model.Domain.Player.Inventory
{
    public abstract class PlayerWearable : PlayerInventoryItem
    {
        public override InventoryTypes InventoryType { get { return InventoryTypes.PlayerWearable; } }
        public abstract PlayerAnatomy Anatomy { get; }
    }
}
