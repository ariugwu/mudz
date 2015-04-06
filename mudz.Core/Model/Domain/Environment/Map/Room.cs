using System.Collections.Generic;
using mudz.Core.Model.Domain.InventoryItem;
using mudz.Core.Model.Domain.Monster;
using mudz.Core.Model.Domain.Player;

namespace mudz.Core.Model.Domain.Environment.Map
{
    public class Room
    {
        public RoomKey RoomKey { get; set; }

        List<IPlayer> Players { get; set; }
        List<IMonster> Monsters { get; set; }
        List<IInventoryItem> Items { get; set; }
    }
}
