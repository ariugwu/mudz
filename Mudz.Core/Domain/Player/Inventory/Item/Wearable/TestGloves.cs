using System;
using System.Collections.Generic;
using Mudz.Common.Domain.Inventory;
using Mudz.Common.Domain.Player;

namespace Mudz.Core.Domain.Player.Inventory.Item.Wearable
{
    [Serializable]
    public class TestGloves : PlayerWearable
    {
        public TestGloves()
        {
            Name = "TestGloves";
            ActionEffect = new Dictionary<InventoryAugmentEffect, int> { { InventoryAugmentEffect.Attack, 1 } };
        }

        public override sealed Dictionary<InventoryAugmentEffect, int> ActionEffect { get; set; }

        public override PlayerAnatomy Anatomy {get { return PlayerAnatomy.Hands; }}

    }
}
