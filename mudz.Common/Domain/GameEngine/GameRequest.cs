using System;
using mudz.Common.Domain.Environment.Map.Room;

namespace mudz.Common.Domain.GameEngine
{
    [Serializable]
    public class GameRequest
    {
        public GameActions GameAction { get; set; }
        public RoomKey RoomKey { get; set; }
        public IGameObject Sender { get; set; }
        public IGameObject Target { get; set; }
    }
}
