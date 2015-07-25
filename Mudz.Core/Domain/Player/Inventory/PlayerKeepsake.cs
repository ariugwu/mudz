using System;
using Mudz.Common.Domain.Inventory;

namespace Mudz.Core.Domain.Player.Inventory
{
    [Serializable]
    public abstract class PlayerKeepsake : PlayerInventoryItem
    {
        public override InventoryType InventoryType { get { return InventoryType.PlayerKeepsake; } }
    }
}
