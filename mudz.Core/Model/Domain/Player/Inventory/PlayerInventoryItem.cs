using System.Collections.Generic;
using mudz.Core.Model.Domain.Inventory;

namespace mudz.Core.Model.Domain.Player.Inventory
{
    public abstract class PlayerInventoryItem : BaseInventoryItem
    {
        public override InventoryTypes InventoryType { get { return InventoryTypes.InventoryItem; } }

        public override bool IsDestructible { get { return false; } }

        public override bool IsAttainable { get { return true; } }

        public abstract Dictionary<InventoryAugmentEffect, double> ActionEffect { get; set; } 

    }
}
