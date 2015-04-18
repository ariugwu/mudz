using System.Collections.Generic;
using mudz.Core.Model.Domain.Inventory;

namespace mudz.Core.Model.Domain.Player.Inventory.Item.Wearable
{
    public class TestHat : PlayerWearable
    {

        public TestHat()
        {
            ActionEffect = new Dictionary<InventoryAugmentEffect, double> { { InventoryAugmentEffect.Attack, 1 } };
        }

        public override sealed Dictionary<InventoryAugmentEffect, double> ActionEffect { get; set; }

        public override PlayerAnatomy Anatomy { get { return PlayerAnatomy.Head; } }
    }
}
