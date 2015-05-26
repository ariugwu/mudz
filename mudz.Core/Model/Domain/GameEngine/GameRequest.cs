using mudz.Core.Model.Domain.Environment.Map.Room;

namespace mudz.Core.Model.Domain.GameEngine
{
    public class GameRequest
    {
        public GameActions GameAction { get; set; }
        public RoomKey RoomKey { get; set; }
        public IGameObject Sender { get; set; }
        public IGameObject Target { get; set; }

    }
}
