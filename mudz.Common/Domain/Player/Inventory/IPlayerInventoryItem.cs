using System.Collections.Generic;
using mudz.Common.Domain.Inventory;

namespace mudz.Common.Domain.Player.Inventory
{
    public interface IPlayerInventoryItem
    {
        InventoryTypes InventoryType { get; }

        bool IsDestructible { get; }

        bool IsAttainable { get; }

        Dictionary<InventoryAugmentEffect, int> ActionEffect { get; set; } 
    }
}
