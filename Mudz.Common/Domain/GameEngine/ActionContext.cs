using System.Collections.Generic;
using Mudz.Common.Domain.Environment.Map.Room;
using Mudz.Common.Domain.Player;

namespace Mudz.Common.Domain.GameEngine
{
    public class ActionContext
    {
        public GameRequest GameRequest { get; set; }

        public IPlayer Player { get; set; }
        public IGameObject Target { get; set; }
        public RoomContent Room { get; set; }
        public List<ActionResult> ActionItems { get; set; }
    }
}
