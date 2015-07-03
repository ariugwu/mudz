using System;
using System.Collections.Generic;
using mudz.Common.Domain.Inventory;
using mudz.Common.Domain.Player.Inventory;
using mudz.Core.Model.Domain.Inventory;

namespace mudz.Core.Domain.Player.Inventory
{
    [Serializable]
    public abstract class PlayerInventoryItem : BaseInventoryItem, IPlayerInventoryItem
    {
        public override InventoryTypes InventoryType { get { return InventoryTypes.InventoryItem; } }

        public override bool IsDestructible { get { return false; } }

        public override bool IsAttainable { get { return true; } }

        public abstract Dictionary<InventoryAugmentEffect, int> ActionEffect { get; set; } 

    }
}
