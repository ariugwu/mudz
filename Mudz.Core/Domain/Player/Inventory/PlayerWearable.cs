using System;
using Mudz.Common.Domain.Inventory;
using Mudz.Common.Domain.Player;
using Mudz.Data.Domain.Player;

namespace Mudz.Core.Domain.Player.Inventory
{
    [Serializable]
    public abstract class PlayerWearable : PlayerInventoryItem
    {
        public override InventoryType InventoryType { get { return InventoryType.PlayerWearable; } }
        public abstract PlayerAnatomy Anatomy { get; }
    }
}
