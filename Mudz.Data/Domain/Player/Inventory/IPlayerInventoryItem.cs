using System.Collections.Generic;
using Mudz.Data.Domain.Inventory;

namespace Mudz.Data.Domain.Player.Inventory
{
    public interface IPlayerInventoryItem
    {
        InventoryTypes InventoryType { get; }

        bool IsDestructible { get; }

        bool IsAttainable { get; }

        Dictionary<InventoryAugmentEffect, int> ActionEffect { get; set; } 
    }
}
