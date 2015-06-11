using System;
using mudz.Common.Domain.Environment.Map.Room;
using mudz.Common.Domain.Player;

namespace mudz.Common.Domain.GameEngine
{
    [Serializable]
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
