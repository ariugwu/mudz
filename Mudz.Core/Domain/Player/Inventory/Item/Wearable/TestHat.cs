﻿using System;
using System.Collections.Generic;
using Mudz.Common.Domain.Inventory;
using Mudz.Common.Domain.Player;

namespace Mudz.Core.Domain.Player.Inventory.Item.Wearable
{
    [Serializable]
    public class TestHat : PlayerWearable
    {
        public TestHat()
        {
            Name = "TestHat";
            ActionEffect = new Dictionary<InventoryAugmentEffect, int> { { InventoryAugmentEffect.Attack, 1 } };
        }

        public override sealed Dictionary<InventoryAugmentEffect, int> ActionEffect { get; set; }

        public override PlayerAnatomy Anatomy { get { return PlayerAnatomy.Head; } }
    }
}
