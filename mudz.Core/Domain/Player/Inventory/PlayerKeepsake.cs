using System;
using mudz.Common.Domain.Inventory;

namespace mudz.Core.Model.Domain.Player.Inventory
{
    [Serializable]
    public abstract class PlayerKeepsake : PlayerInventoryItem
    {
        public override InventoryTypes InventoryType { get { return InventoryTypes.PlayerKeepsake; } }
    }
}
