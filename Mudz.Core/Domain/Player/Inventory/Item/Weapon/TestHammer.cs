using System;
using System.Collections.Generic;
using Mudz.Data.Domain.Inventory;

namespace Mudz.Core.Domain.Player.Inventory.Item.Weapon
{
    [Serializable]
    public class TestHammer : PlayerWeapon
    {
        public TestHammer()
        {
            Name = "TestHammer";
            ActionEffect = new Dictionary<InventoryAugmentEffect, int> { { InventoryAugmentEffect.Attack, 2 } };
        }

        public override sealed Dictionary<InventoryAugmentEffect, int> ActionEffect { get; set; }

    }
}
