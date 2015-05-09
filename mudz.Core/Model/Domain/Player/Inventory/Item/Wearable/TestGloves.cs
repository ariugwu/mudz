using System.Collections.Generic;
using mudz.Core.Model.Domain.Inventory;

namespace mudz.Core.Model.Domain.Player.Inventory.Item.Wearable
{
    public class TestGloves : PlayerWearable
    {
        public TestGloves()
        {
            ActionEffect = new Dictionary<InventoryAugmentEffect, int> { { InventoryAugmentEffect.Attack, 1 } };
        }

        public override sealed Dictionary<InventoryAugmentEffect, int> ActionEffect { get; set; }

        public override PlayerAnatomy Anatomy {get { return PlayerAnatomy.Hands; }}

    }
}
