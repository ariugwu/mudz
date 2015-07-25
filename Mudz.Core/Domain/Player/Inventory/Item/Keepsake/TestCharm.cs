using System;
using System.Collections.Generic;
using Mudz.Common.Domain.Inventory;

namespace Mudz.Core.Domain.Player.Inventory.Item.Keepsake
{
    [Serializable]
    public class TestCharm : PlayerKeepsake
    {
        public TestCharm()
        {
            Name = "TestCharm";
            ActionEffect = new Dictionary<InventoryAugmentEffect, int> {{InventoryAugmentEffect.Attack, 3}};

        }

        public override sealed Dictionary<InventoryAugmentEffect, int> ActionEffect { get; set; }
    }
}
