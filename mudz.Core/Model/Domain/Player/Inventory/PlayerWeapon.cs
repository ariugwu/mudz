using mudz.Core.Model.Domain.Inventory;

namespace mudz.Core.Model.Domain.Player.Inventory
{
    public abstract class PlayerWeapon : PlayerInventoryItem
    {
        public override InventoryTypes InventoryType { get { return InventoryTypes.PlayerWeapon; } }
    }
}
