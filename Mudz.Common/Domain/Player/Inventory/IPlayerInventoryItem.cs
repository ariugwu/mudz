using System.Collections.Generic;
using Mudz.Common.Domain.Inventory;

namespace Mudz.Common.Domain.Player.Inventory
{
    public interface IPlayerInventoryItem
    {
        InventoryTypes InventoryType { get; }

        bool IsDestructible { get; }

        bool IsAttainable { get; }

        Dictionary<InventoryAugmentEffect, int> ActionEffect { get; set; } 
    }
}
