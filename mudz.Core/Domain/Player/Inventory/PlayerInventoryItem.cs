using System;
using System.Collections.Generic;
using Mudz.Common.Domain.Inventory;
using Mudz.Common.Domain.Player.Inventory;
using Mudz.Core.Model.Domain.Inventory;

namespace Mudz.Core.Domain.Player.Inventory
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
