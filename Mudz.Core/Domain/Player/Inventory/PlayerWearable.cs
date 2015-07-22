using System;
using Mudz.Data.Domain.Inventory;
using Mudz.Data.Domain.Player;

namespace Mudz.Core.Domain.Player.Inventory
{
    [Serializable]
    public abstract class PlayerWearable : PlayerInventoryItem
    {
        public override InventoryTypes InventoryType { get { return InventoryTypes.PlayerWearable; } }
        public abstract PlayerAnatomy Anatomy { get; }
    }
}
