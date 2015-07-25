using System;
using System.Collections.Generic;
using Mudz.Common.Domain.Inventory;
using Mudz.Common.Domain.Player.Inventory;
using Mudz.Core.Domain.Inventory;

namespace Mudz.Core.Domain.Player.Inventory
{
    [Serializable]
    public abstract class PlayerInventoryItem : BaseInventoryItem, IPlayerInventoryItem
    {
        public override InventoryType InventoryType { get { return InventoryType.InventoryItem; } }

        public override bool IsDestructible { get { return false; } }

        public override bool IsAttainable { get { return true; } }

        public abstract Dictionary<InventoryAugmentEffect, int> ActionEffect { get; set; } 

    }
}
