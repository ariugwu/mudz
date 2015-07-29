using System.Collections.Generic;
using Mudz.Common.Domain.Inventory;

namespace Mudz.Common.Domain.Player.Inventory
{
    public interface IPlayerInventoryItem : IGameObject
    {
        InventoryType InventoryType { get; }

        Dictionary<InventoryAugmentEffect, int> ActionEffect { get; set; } 
    }
}
