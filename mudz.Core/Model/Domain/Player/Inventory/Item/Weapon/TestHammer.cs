using System.Collections.Generic;
using mudz.Core.Model.Domain.Inventory;

namespace mudz.Core.Model.Domain.Player.Inventory.Item.Weapon
{
    public class TestHammer : PlayerWeapon
    {
        public TestHammer()
        {
            ActionEffect = new Dictionary<InventoryAugmentEffect, double> { { InventoryAugmentEffect.Attack, 2 } };
        }

        public override sealed Dictionary<InventoryAugmentEffect, double> ActionEffect { get; set; }

    }
}
