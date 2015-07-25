using Mudz.Common.Domain.GameEngine;

namespace Mudz.Data.Domain.GameEngine
{
    public class GameEvent : IGameEvent
    {
        public IGameRequest GameRequest { get; set; }
        public IGameResponse GameResponse { get; set; }
    }
}
