using System.Collections.Generic;
using mudz.Core.Model.Domain.Inventory;

namespace mudz.Core.Model.Domain.Player.Inventory.Item.Weapon
{
    public class Fists : PlayerWeapon
    {
        public Fists()
        {
            ActionEffect = new Dictionary<InventoryAugmentEffect, double> { { InventoryAugmentEffect.Attack, 1 } };

        }

        public override sealed Dictionary<InventoryAugmentEffect, double> ActionEffect { get; set; }

    }
}
