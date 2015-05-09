using System.Collections.Generic;
using mudz.Core.Model.Domain.Inventory;

namespace mudz.Core.Model.Domain.Player.Inventory.Item.Keepsake
{
    public class TestCharm : PlayerKeepsake
    {
        public TestCharm()
        {
            ActionEffect = new Dictionary<InventoryAugmentEffect, int> {{InventoryAugmentEffect.Attack, 3}};

        }

        public override sealed Dictionary<InventoryAugmentEffect, int> ActionEffect { get; set; }
    }
}
