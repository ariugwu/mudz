using System;
using System.Collections.Generic;
using System.Linq;

namespace Mudz.Common.Domain.Environment.Map.Room
{
    [Serializable]
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

        public IGameObject GetGameObject(Guid guid)
        {
            return GameObjects.First(x => x.GameObjectKey == guid);
        }
    }
}
