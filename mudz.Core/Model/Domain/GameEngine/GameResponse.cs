using mudz.Core.Model.Domain.Environment.Map.Room;
using mudz.Core.Model.Domain.Player;

namespace mudz.Core.Model.Domain.GameEngine
{
    public class GameResponse
    {
        public GameRequest Request { get; set; }

        public RoomContent RoomContent { get; set; }

        public IPlayer Player { get; set; }

        public bool WasSuccessful { get; set; }

        public string Message { get; set; }
        public int Amount { get; set; }
    }
}
