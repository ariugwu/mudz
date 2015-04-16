using System.Collections.Generic;
using mudz.Core.Model.Domain.Player.Inventory;

namespace mudz.Core.Model.Domain.Player
{
    public interface IPlayer : IActor
    {
        PlayerTypes PlayerType { get; set; }

        int Experience { get; set; }

        int Level { get; set; }

        double Repair();

        double Negotiate();

        IList<PlayerInventoryItem> Inventory { get; }

        void AddInventoryItem(PlayerInventoryItem item);

        void RemoveInventoryItem(int index);

        void EquipWeapon(PlayerWeapon weapon);

        void EquipWearable(PlayerWearable wearable);

    }
}
