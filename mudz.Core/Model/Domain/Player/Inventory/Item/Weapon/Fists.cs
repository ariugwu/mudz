using System;
using System.Collections.Generic;
using mudz.Common.Domain.Inventory;

namespace mudz.Core.Model.Domain.Player.Inventory.Item.Weapon
{
    [Serializable]
    public class Fists : PlayerWeapon
    {
        public Fists()
        {
            Name = "Fists";
            ActionEffect = new Dictionary<InventoryAugmentEffect, int> { { InventoryAugmentEffect.Attack, 1 } };

        }

        public override sealed Dictionary<InventoryAugmentEffect, int> ActionEffect { get; set; }

    }
}
