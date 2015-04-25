using System.Collections.Generic;
using mudz.Core.Model.Domain.Inventory;
using mudz.Core.Model.Domain.Monster;
using mudz.Core.Model.Domain.Npc;
using mudz.Core.Model.Domain.Player;

namespace mudz.Core.Model.Domain.Environment.Map.Room
{
    public class RoomContent
    {
        public RoomContent(RoomKey roomKey)
        {
            RoomKey = roomKey;
        }

        public RoomKey RoomKey { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<IGameObject> GameObjects { get; set; }
    }
}
