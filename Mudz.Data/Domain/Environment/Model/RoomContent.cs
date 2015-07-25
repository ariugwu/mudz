using System;
using System.Collections.Generic;
using System.Linq;
using Mudz.Common.Domain;
using Mudz.Common.Domain.Environment;

namespace Mudz.Data.Domain.Environment.Model
{
    [Serializable]
    public class RoomContent : IRoomContent
    {
        public RoomContent(RoomKey roomKey)
        {
            RoomKey = roomKey;
        }

        public IRoomKey RoomKey { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<IGameObject> GameObjects { get; set; }

        public IGameObject GetGameObject(Guid guid)
        {
            return GameObjects.First(x => x.GameObjectKey == guid);
        }
    }
}
