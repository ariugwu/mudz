using System;
using mudz.Common.Domain.Environment.Map.Room;
using mudz.Common.Domain.Player;

namespace mudz.Common.Domain.GameEngine
{
    [Serializable]
    public class GameRequest
    {
        public GameActions GameAction { get; set; }
        public RoomKey RoomKey { get; set; }
        public IPlayer Sender { get; set; }
        public IGameObject Target { get; set; }
    }
}
