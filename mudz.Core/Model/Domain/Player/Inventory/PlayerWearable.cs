using System;
using mudz.Common.Domain.Inventory;
using mudz.Common.Domain.Player;

namespace mudz.Core.Model.Domain.Player.Inventory
{
    [Serializable]
    public abstract class PlayerWearable : PlayerInventoryItem
    {
        public override InventoryTypes InventoryType { get { return InventoryTypes.PlayerWearable; } }
        public abstract PlayerAnatomy Anatomy { get; }
    }
}
