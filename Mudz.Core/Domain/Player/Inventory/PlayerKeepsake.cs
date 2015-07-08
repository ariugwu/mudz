using System;
using Mudz.Common.Domain.Inventory;

namespace Mudz.Core.Domain.Player.Inventory
{
    [Serializable]
    public abstract class PlayerKeepsake : PlayerInventoryItem
    {
        public override InventoryTypes InventoryType { get { return InventoryTypes.PlayerKeepsake; } }
    }
}
