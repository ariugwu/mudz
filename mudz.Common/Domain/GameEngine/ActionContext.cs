using System.Collections.Generic;
using mudz.Common.Domain.Environment.Map.Room;
using mudz.Common.Domain.Player;

namespace mudz.Common.Domain.GameEngine
{
    public class ActionContext
    {
        public IPlayer Player { get; set; }
        public IGameObject Target { get; set; }
        public RoomContent Room { get; set; }
        public List<ActionResult> ActionItems { get; set; }

        public GameActions CurrentAction { get; set; }
    }
}
