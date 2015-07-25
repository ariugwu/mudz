using System;
using Mudz.Common.Domain.Inventory;
using Mudz.Data.Domain.Player.Inventory;

namespace Mudz.Core.Domain.Player.Inventory
{
    [Serializable]
    public abstract class PlayerWeapon : PlayerInventoryItem, IPlayerWeapon
    {
        public override InventoryType InventoryType { get { return InventoryType.PlayerWeapon; } }
    }
}
