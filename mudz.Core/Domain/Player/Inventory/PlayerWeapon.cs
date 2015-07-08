using System;
using Mudz.Common.Domain.Inventory;
using Mudz.Common.Domain.Player.Inventory;

namespace Mudz.Core.Domain.Player.Inventory
{
    [Serializable]
    public abstract class PlayerWeapon : PlayerInventoryItem, IPlayerWeapon
    {
        public override InventoryTypes InventoryType { get { return InventoryTypes.PlayerWeapon; } }
    }
}
