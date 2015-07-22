using System;
using Mudz.Data.Domain.Inventory;
using Mudz.Data.Domain.Player.Inventory;

namespace Mudz.Core.Domain.Player.Inventory
{
    [Serializable]
    public abstract class PlayerWeapon : PlayerInventoryItem, IPlayerWeapon
    {
        public override InventoryTypes InventoryType { get { return InventoryTypes.PlayerWeapon; } }
    }
}
