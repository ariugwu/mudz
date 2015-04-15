using System.Collections.Generic;
using mudz.Core.Model.Domain.Player.Inventory;

namespace mudz.Core.Model.Domain.Player
{
    public interface IPlayer : IActor
    {
        PlayerTypes PlayerType { get; set; }

        int Experience { get; set; }

        int Level { get; set; }

        void Repair();

        void Negotiate();

        IList<PlayerInventoryItem> Inventory { get; }

        void AddInventoryItem(PlayerInventoryItem item);
    }
}
