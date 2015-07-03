using System;
using mudz.Common.Domain.Inventory;
using mudz.Common.Domain.Player.Inventory;

namespace mudz.Core.Domain.Player.Inventory
{
    [Serializable]
    public abstract class PlayerWeapon : PlayerInventoryItem, IPlayerWeapon
    {
        public override InventoryTypes InventoryType { get { return InventoryTypes.PlayerWeapon; } }
    }
}
